using CreationalDesignPatterns.Coffee.Interfaces;

namespace CreationalDesignPatterns.Coffee
{
    public class FlatWhite(ICoffee coffeeType, IIngredient milkType) : Cappuccino(coffeeType, milkType)
    {
        public override string ToString()
        {
            return $"Flat White";
        }
    }
}
