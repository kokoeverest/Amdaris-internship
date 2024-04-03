namespace StructuralDesignPatterns.Decorators
{
    public class BoldDecorator : Decorator
    {
        internal override string Decorate(string text)
        {
            return $"{text} [bold]";
        }
    }
}
