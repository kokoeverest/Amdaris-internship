namespace StructuralDesignPatterns.Decorators
{
    internal class ItalicDecorator : Decorator
    {
        internal override string Decorate(string text)
        {
            return $"{text} [italic]";
        }
    }
}
