namespace CreationalDesignPatterns
{
    public class FlatWhiteCoffeeMachine(ICoffee coffeeType, IIngredient milkType) : CappuccinoMachine(coffeeType, milkType), ICoffeeMachine
    {
        public new ICoffee Coffee { get; set; } = coffeeType;

        public override string ToString()
        {
            return $"Flat White machine prepares {Coffee} + {base.Coffee} + {base.Milk}";
        }
    }
}
