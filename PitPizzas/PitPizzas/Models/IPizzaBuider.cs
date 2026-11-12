namespace PitPizzas.Models
{
    public interface IPizzaBuider
    {
        void DefinirMassa(string massa);
        void AdicionarIngrediente(string ingrediente);
        void AdicionarAdicional(string adicional);
        Pizza ConstruirPizza();
    }
}
