namespace CreationalDesignPatterns
{
    public class EspressoMachine(ICoffee coffeeType) : ICoffeeMachine
    {
        public ICoffee Coffee { get; set; } = coffeeType;

        public override string ToString()
        {
            return $"Espresso machine prepares {Coffee}";
        }
    }
}
