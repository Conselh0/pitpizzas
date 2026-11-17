using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PitPizzas.Models;
using PitPizzas.Patterns.Builder;
using PitPizzas.Services;
using PitPizzas.ViewModels;

namespace PitPizzas.Controllers;

public class PizzaController : Controller
{
    private const string Chave = "historico";
    private const int LimiteDesfazer = 30;
    private static readonly CultureInfo PtBr = new("pt-BR");

    private readonly Diretor _diretor;

    public PizzaController(Diretor diretor) => _diretor = diretor;

    public IActionResult Index()
    {
        var historico = Carregar();
        return View(new PizzaViewModel
        {
            Massas = Catalogo.Massas,
            Ingredientes = Catalogo.Ingredientes,
            Adicionais = Catalogo.Adicionais,
            Pizza = Construir(historico[^1]),
            PodeDesfazer = historico.Count > 1,
            Mensagem = TempData["Mensagem"] as string
        });
    }

    [HttpPost]
    public IActionResult DefinirMassa(int id) =>
        Montar(e => e with { MassaId = id });

    [HttpPost]
    public IActionResult AlternarIngrediente(int id) =>
        Montar(e => e with { Ingredientes = Alternar(e.Ingredientes, id) });

    [HttpPost]
    public IActionResult AlternarAdicional(int id) =>
        Montar(e => e with { Adicionais = Alternar(e.Adicionais, id) });

    [HttpPost]
    public IActionResult Sugestao(string nome) =>
        Montar(e => Catalogo.Sugestoes.GetValueOrDefault(nome, e));

    [HttpPost]
    public IActionResult Limpar() =>
        Montar(_ => new Estado());

    [HttpPost]
    public IActionResult Desfazer()
    {
        var historico = Carregar();
        if (historico.Count > 1) historico.RemoveAt(historico.Count - 1);
        Salvar(historico);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Finalizar()
    {
        var pizza = Construir(Carregar()[^1]);
        if (pizza.Massa == null || pizza.Ingredientes.Count == 0)
        {
            TempData["Mensagem"] = "Escolha uma massa e pelo menos um ingrediente!";
            return RedirectToAction(nameof(Index));
        }

        TempData["Mensagem"] = $"Pedido confirmado! Total: {pizza.Total.ToString("C", PtBr)}. Obrigado por escolher a Pit Pizzas! 🍕";
        HttpContext.Session.Remove(Chave);
        return RedirectToAction(nameof(Index));
    }

    // ---------- helpers ----------

    // Aplica uma mudança sobre o estado atual e guarda o novo estado no histórico
    private IActionResult Montar(Func<Estado, Estado> mudanca)
    {
        var historico = Carregar();
        historico.Add(mudanca(historico[^1]));
        if (historico.Count > LimiteDesfazer + 1) historico.RemoveAt(0);
        Salvar(historico);
        return RedirectToAction(nameof(Index));
    }

    // Converte os IDs do estado em objetos e pede ao Diretor para montar a Pizza
    private Pizza Construir(Estado e) => _diretor.MontarPizza(
        Catalogo.Massas.FirstOrDefault(m => m.Id == e.MassaId),
        e.Ingredientes.Select(id => Catalogo.Ingredientes.First(i => i.Id == id)),
        e.Adicionais.Select(id => Catalogo.Adicionais.First(a => a.Id == id)));

    // Remove o id se já estiver na lista; senão, adiciona no fim
    private static List<int> Alternar(List<int> ids, int id) =>
        ids.Contains(id) ? ids.Where(x => x != id).ToList() : [.. ids, id];

    // O histórico sempre começa com um estado vazio; o último item é o estado atual
    private List<Estado> Carregar()
    {
        var json = HttpContext.Session.GetString(Chave);
        return json == null ? [new Estado()] : JsonSerializer.Deserialize<List<Estado>>(json)!;
    }

    private void Salvar(List<Estado> historico) =>
        HttpContext.Session.SetString(Chave, JsonSerializer.Serialize(historico));
}
