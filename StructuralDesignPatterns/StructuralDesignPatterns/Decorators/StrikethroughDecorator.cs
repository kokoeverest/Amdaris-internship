namespace StructuralDesignPatterns.Decorators
{
    public class StrikethroughDecorator : Decorator
    {
        internal override string Decorate(string text)
        {
            return $"{text} [strikethrough]";
        }
    }
}