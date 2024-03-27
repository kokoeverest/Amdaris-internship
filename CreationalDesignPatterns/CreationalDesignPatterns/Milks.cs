namespace CreationalDesignPatterns
{
    public class OatMilk : IIngredient
    {
        public override string ToString()
        {
            return "Oat milk";
        }
    }

    public class CowMilk : IIngredient
    {
        public override string ToString()
        {
            return "Cow milk";
        }
    }

    public class SoyMilk : IIngredient
    {
        public override string ToString()
        {
            return "Soy milk";
        }
    }
}
