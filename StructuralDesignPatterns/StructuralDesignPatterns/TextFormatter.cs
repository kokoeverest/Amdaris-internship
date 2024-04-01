namespace StructuralDesignPatterns
{
    public class TextFormatter : ITextFormatter
    {
        public string Bold()
        {
            return " [bold]";
        }

        public string Color()
        {
            return " [color]";
        }

        public string Italic()
        {
            return " [italic]";
        }

        public string Strikethrough()
        {
            return " [strikethrough]";
        }

        public string Underline()
        {
            return " [underline]";
        }
    }
}
