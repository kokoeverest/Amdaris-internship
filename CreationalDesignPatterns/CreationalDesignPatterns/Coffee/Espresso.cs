using CreationalDesignPatterns.Coffee.Interfaces;

namespace CreationalDesignPatterns.Coffee
{
    public class Espresso(ICoffee coffeeType) : CoffeeType(coffeeType)
    {
        public override string ToString()
        {
            return $"Espresso";
        }
    }
}
