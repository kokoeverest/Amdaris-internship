namespace StructuralDesignPatterns.Decorators
{
    internal class UnderlineDecorator : Decorator
    {
        internal override string Decorate(string text)
        {
            return $"{text} [underline]";
        }
    }
}