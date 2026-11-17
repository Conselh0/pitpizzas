using PitPizzas.Models;

namespace PitPizzas.Patterns.Builder;

// Diretor: define a sequência de construção usando qualquer IPizzaBuilder
public class Diretor
{
    private IPizzaBuilder _builder;

    public Diretor(IPizzaBuilder builder) => _builder = builder;

    public void SetBuilder(IPizzaBuilder builder) => _builder = builder;

    public Pizza MontarPizza(Massa? massa, IEnumerable<Ingrediente> ingredientes, IEnumerable<Adicional> adicionais)
    {
        if (massa != null) _builder.DefinirMassa(massa);
        foreach (var i in ingredientes) _builder.AdicionarIngrediente(i);
        foreach (var a in adicionais) _builder.AdicionarAdicional(a);
        return _builder.ConstruirPizza();
    }
}
