using System.Text;

namespace CreationalDesignPatterns
{
    public abstract class CoffeeType(ICoffee coffeeType) : ICoffeeType
    {
        public ICoffee Coffee { get; set; } = coffeeType;
        public void MakeCoffee(List<IIngredient> additions) 
        {
            StringBuilder builder = new ();
            builder.Append($"{this}");
            foreach ( var addition in additions )
            {
                builder.Append($" + {addition}");
            }
            Console.WriteLine("Preparing coffee...\n");
            Thread.Sleep(5000);
            Console.WriteLine(builder);
        }

        public override string ToString() => $"{this}";
    }
}
