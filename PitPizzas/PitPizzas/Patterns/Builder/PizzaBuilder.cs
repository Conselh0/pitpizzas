using PitPizzas.Models;

namespace PitPizzas.Patterns.Builder;

// Builder concreto: monta a Pizza passo a passo
public class PizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new();

    public void DefinirMassa(Massa massa) => _pizza.DefinirMassa(massa);
    public void AdicionarIngrediente(Ingrediente ingrediente) => _pizza.AdicionarIngrediente(ingrediente);
    public void AdicionarAdicional(Adicional adicional) => _pizza.AdicionarAdicional(adicional);

    public Pizza ConstruirPizza()
    {
        var pronta = _pizza;
        _pizza = new Pizza();   // o builder fica limpo para a próxima pizza
        return pronta;
    }
}
