using StructuralDesignPatterns.Decorators;
using System.Text;

namespace StructuralDesignPatterns
{
    public class TextPrinterFacade : TextFormatter
    {
        public bool PrintText(string text)
        {
            text = RemoveFormatting(text);
            BaseFormatDecorator decorator = new(text);
            return decorator.Print();
        }

        public bool PrintText(string text, char[] formatOptions)
        {
            HashSet<char> formatsWithoutDuplicates = new(formatOptions);
            BaseFormatDecorator decorator = new(text);
            
            foreach (char option in formatsWithoutDuplicates)
            {
                if (option == 'b' && !text.Contains(" [bold]"))
                {
                    decorator.AddFormat(new BoldDecorator());
                }
                else if (option == 'i' && !text.Contains(" [italic]"))
                {
                    decorator.AddFormat(new ItalicDecorator());
                }
                else if (option == 'u' && !text.Contains(" [underline]"))
                {
                    decorator.AddFormat(new UnderlineDecorator());
                }
                else if (option == 's' && !text.Contains(" [strikethrough]"))
                {
                    decorator.AddFormat(new StrikethroughDecorator());
                }
                else if (option == 'c' && !text.Contains(" [color]"))
                {
                    decorator.AddFormat(new ColorDecorator());
                }
            }
            return decorator.Print();
        }

        public string RemoveFormatting(string text)
        {
            StringBuilder stringBuilder = new(text);
            stringBuilder.Replace(Bold(), string.Empty);
            stringBuilder.Replace(Italic(), string.Empty);
            stringBuilder.Replace(Strikethrough(), string.Empty);
            stringBuilder.Replace(Color(), string.Empty);
            stringBuilder.Replace(Underline(), string.Empty);

            return stringBuilder.ToString();
        }
    }
}
