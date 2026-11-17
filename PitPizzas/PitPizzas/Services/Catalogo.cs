using PitPizzas.Models;

namespace PitPizzas.Services;

public static class Catalogo
{
    public static readonly IReadOnlyList<Massa> Massas =
    [
        new(1, "Tradicional",     "Macia e fofinha", 30.00m),
        new(2, "Fina e crocante", "Estilo italiano", 32.00m),
        new(3, "Integral",        "Mais leve",       35.00m),
    ];

    public static readonly IReadOnlyList<Ingrediente> Ingredientes =
    [
        new(1,  "Molho de tomate", "🍅", 0.00m),
        new(2,  "Mussarela",       "🧀", 5.00m),
        new(3,  "Calabresa",       "🌭", 6.00m),
        new(4,  "Tomate fatiado",  "🍅", 3.00m),
        new(5,  "Manjericão",      "🌿", 2.00m),
        new(6,  "Cebola",          "🧅", 2.00m),
        new(7,  "Azeitona",        "🫒", 3.00m),
        new(8,  "Presunto",        "🥓", 6.00m),
        new(9,  "Frango",          "🍗", 7.00m),
        new(10, "Catupiry",        "🥛", 6.00m),
        new(11, "Bacon",           "🥓", 8.00m),
        new(12, "Milho",           "🌽", 2.50m),
    ];

    public static readonly IReadOnlyList<Adicional> Adicionais =
    [
        new(1, "Borda de catupiry", "Borda recheada",  8.00m),
        new(2, "Borda de cheddar",  "Borda recheada",  8.00m),
        new(3, "Queijo extra",      "Dobro de queijo", 10.00m),
        new(4, "Refrigerante 2L",   "Gelado",          12.00m),
    ];

    // Receitas prontas (as "Sugestões do Pit")
    public static readonly Dictionary<string, Estado> Sugestoes = new()
    {
        ["margherita"] = new() { MassaId = 1, Ingredientes = [1, 2, 4, 5] },
        ["calabresa"]  = new() { MassaId = 1, Ingredientes = [1, 2, 3, 6, 7] },
        ["frango"]     = new() { MassaId = 2, Ingredientes = [1, 2, 9, 10, 12] },
    };
}
