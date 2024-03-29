using CreationalDesignPatterns.Coffee.Interfaces;

namespace CreationalDesignPatterns.Coffee
{
    public class Cappuccino(ICoffee coffeeType, IIngredient milkType) : CoffeeType(coffeeType)
    {
        public IIngredient Milk { get; set; } = milkType;

        public override string ToString()
        {
            return $"Cappuccino";
        }
    }
}
