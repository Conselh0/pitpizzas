using PitPizzas.Models;

namespace PitPizzas.Patterns.Builder;

public interface IPizzaBuilder
{
    void DefinirMassa(Massa massa);
    void AdicionarIngrediente(Ingrediente ingrediente);
    void AdicionarAdicional(Adicional adicional);
    Pizza ConstruirPizza();
}
