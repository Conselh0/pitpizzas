using PitPizzas.Models;

namespace PitPizzas.ViewModels;

public class PizzaViewModel
{
    public IReadOnlyList<Massa> Massas { get; init; } = [];
    public IReadOnlyList<Ingrediente> Ingredientes { get; init; } = [];
    public IReadOnlyList<Adicional> Adicionais { get; init; } = [];
    public Pizza Pizza { get; init; } = new();
    public bool PodeDesfazer { get; init; }
    public string? Mensagem { get; init; }
}
