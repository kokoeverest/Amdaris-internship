namespace StructuralDesignPatterns.Decorators
{
    internal class StrikethroughDecorator : Decorator
    {
        internal override string Decorate(string text)
        {
            return $"{text} [strikethrough]";
        }
    }
}