namespace StructuralDesignPatterns
{
    public class TextFormatter : ITextFormatter
    {
        public string Bold()
        {
            return " [Bold]";
        }

        public string Color()
        {
            return " [Color]";
        }

        public string Italic()
        {
            return " [Italic]";
        }

        public string Strikethrough()
        {
            return " [Strikethrough]";
        }

        public string Underline()
        {
            return " [Italic]";
        }
    }
}
