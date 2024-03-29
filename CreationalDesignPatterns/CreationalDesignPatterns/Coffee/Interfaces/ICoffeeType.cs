using System.Text;

namespace CreationalDesignPatterns.Coffee.Interfaces
{
    public interface ICoffeeType
    {
        public ICoffee Coffee { get; set; }
        public void MakeCoffee(List<IIngredient> additions) { }

    }
}
