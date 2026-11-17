namespace PitPizzas.Models;

// Escolhas do usuário (apenas IDs). É o que fica guardado na Session.
public record Estado
{
    public int? MassaId { get; init; }
    public List<int> Ingredientes { get; init; } = [];
    public List<int> Adicionais { get; init; } = [];
}
