namespace StructuralDesignPatterns.Decorators
{
    public class ColorDecorator : Decorator
    {
        internal override string Decorate(string text)
        {
            return $"{text} [color]";
        }
    }
}