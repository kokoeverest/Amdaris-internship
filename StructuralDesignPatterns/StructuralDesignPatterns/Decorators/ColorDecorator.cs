namespace StructuralDesignPatterns.Decorators
{
    internal class ColorDecorator : Decorator
    {
        internal override string Decorate(string text)
        {
            return $"{text} [color]";
        }
    }
}