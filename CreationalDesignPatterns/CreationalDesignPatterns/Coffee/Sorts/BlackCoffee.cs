using CreationalDesignPatterns.Coffee.Interfaces;

namespace CreationalDesignPatterns.Coffee.Sorts
{
    public class BlackCoffee : ICoffee
    {
        public override string ToString()
        {
            return "Black coffee";
        }
    }
}
