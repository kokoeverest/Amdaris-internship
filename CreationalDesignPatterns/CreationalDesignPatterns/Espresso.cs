namespace CreationalDesignPatterns
{
    public class Espresso(ICoffee coffeeType) : CoffeeType(coffeeType), ICoffeeType
    {
        public override string ToString()
        {
            return $"Espresso";
        }
    }
}
