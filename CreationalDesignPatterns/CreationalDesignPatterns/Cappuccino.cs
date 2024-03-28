namespace CreationalDesignPatterns
{
    public class Cappuccino(ICoffee coffeeType, IIngredient milkType) : CoffeeType(coffeeType), ICoffeeType 
    {
        public IIngredient Milk { get; set; } = milkType;
        
        public override string ToString()
        {
            return $"Cappuccino";
        }
    }
}
