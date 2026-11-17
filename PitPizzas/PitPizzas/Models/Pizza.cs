namespace PitPizzas.Models;

// Produto final construído pelo Builder
public class Pizza
{
    private readonly List<Ingrediente> _ingredientes = [];
    private readonly List<Adicional> _adicionais = [];

    public Massa? Massa { get; private set; }
    public IReadOnlyList<Ingrediente> Ingredientes => _ingredientes;
    public IReadOnlyList<Adicional> Adicionais => _adicionais;

    public decimal Total =>
        (Massa?.Preco ?? 0) + _ingredientes.Sum(i => i.Preco) + _adicionais.Sum(a => a.Preco);

    public void DefinirMassa(Massa massa) => Massa = massa;
    public void AdicionarIngrediente(Ingrediente ingrediente) => _ingredientes.Add(ingrediente);
    public void AdicionarAdicional(Adicional adicional) => _adicionais.Add(adicional);

    public string GetResumo() =>
        $"Massa: {Massa?.Nome ?? "nenhuma"} | " +
        $"Ingredientes: {string.Join(", ", _ingredientes.Select(i => i.Nome))} | " +
        $"Adicionais: {string.Join(", ", _adicionais.Select(a => a.Nome))}";
}
