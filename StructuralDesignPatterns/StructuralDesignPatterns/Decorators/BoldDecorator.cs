namespace StructuralDesignPatterns.Decorators
{
    internal class BoldDecorator : Decorator
    {
        internal override string Decorate(string text)
        {
            return $"{text} [bold]";
        }
    }
}
