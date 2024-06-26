﻿namespace StructuralDesignPatterns.Decorators
{
    public class UnderlineDecorator : Decorator
    {
        internal override string Decorate(string text)
        {
            return $"{text} [underline]";
        }
    }
}