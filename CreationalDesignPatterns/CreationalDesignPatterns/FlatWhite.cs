namespace CreationalDesignPatterns
{
    public class FlatWhite(ICoffee coffeeType, IIngredient milkType) : Cappuccino(coffeeType, milkType), ICoffeeType
    {
        public override string ToString()
        {
            return $"Flat White";
        }
    }
}
