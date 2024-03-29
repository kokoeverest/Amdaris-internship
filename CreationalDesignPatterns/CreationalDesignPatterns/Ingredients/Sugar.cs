using CreationalDesignPatterns.Coffee.Interfaces;

namespace CreationalDesignPatterns.Ingredients
{
    public class Sugar : IIngredient
    {
        public override string ToString()
        {
            return "Sugar";
        }
    }
}
