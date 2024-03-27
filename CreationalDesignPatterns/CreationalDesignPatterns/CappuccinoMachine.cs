namespace CreationalDesignPatterns
{
    public class CappuccinoMachine(ICoffee coffeeType, IIngredient milkType) : ICoffeeMachine 
    {
        public ICoffee Coffee { get; set; } = coffeeType;
        public IIngredient Milk { get; set; } = milkType;
        public override string ToString()
        {
            return $"Cappuccino machine prepares {Coffee} + {Milk}";
        }
    }
}
