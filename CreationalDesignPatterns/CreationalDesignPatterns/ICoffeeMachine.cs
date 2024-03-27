using System.Text;

namespace CreationalDesignPatterns
{
    public interface ICoffeeMachine
    {
        public ICoffee Coffee { get; set; }
        public void MakeCoffee(List<IIngredient> additions)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{this}");
            foreach ( var addition in additions )
            {
                builder.Append($" + {addition}");
            }
            Console.WriteLine(builder);
        }
        public string ToString();
    }
}
