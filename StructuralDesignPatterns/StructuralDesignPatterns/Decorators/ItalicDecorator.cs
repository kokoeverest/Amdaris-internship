namespace StructuralDesignPatterns.Decorators
{
    public class ItalicDecorator : Decorator
    {
        internal override string Decorate(string text)
        {
            return $"{text} [italic]";
        }
    }
}
