using CreationalDesignPatterns.Coffee.Interfaces;

namespace CreationalDesignPatterns.Coffee.Sorts
{
    public class ArabicCoffee : ICoffee
    {
        public override string ToString()
        {
            return "Arabica coffee";
        }
    }
}
