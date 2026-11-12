using PitPizzas.Models;

namespace PitPizzas.Builders
{
    public interface IPizzaBuilder
    {
        void DefinirMassa(string massa);
        void AdicionarIngrediente(string ingrediente);
        void AdicionarAdicional(string adicional);
        Pizza ConstruirPizza();
    }
}