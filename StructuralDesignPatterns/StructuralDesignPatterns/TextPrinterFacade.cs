using System.Text;

namespace StructuralDesignPatterns
{
    public class TextPrinterFacade : TextFormatter
    {
        public string PrintText(string text)
        {
            return RemoveFormatting(text);
        }

        public string PrintText(string text, char[] formatOptions)
        {
            text = RemoveFormatting(text);

            HashSet<char> formatsWithoutDuplicates = new(formatOptions);
            StringBuilder stringBuilder = new(text);

            
            foreach (char option in formatsWithoutDuplicates)
            {
                if (option == 'b')
                {
                    stringBuilder.Append(Bold());
                }
                else if (option == 'i')
                {
                    stringBuilder.Append(Italic());
                }
                else if (option == 'u')
                {
                    stringBuilder.Append(Underline());
                }
                else if (option == 's')
                {
                    stringBuilder.Append(Strikethrough());
                }
                else if (option == 'c')
                {
                    stringBuilder.Append(Color());
                }

            }
            return stringBuilder.ToString();
        }

        public string RemoveFormatting(string text)
        {
            StringBuilder stringBuilder = new(text);
            stringBuilder.Replace(Bold(), "");
            stringBuilder.Replace(Italic(), "");
            stringBuilder.Replace(Strikethrough(), "");
            stringBuilder.Replace(Color(), "");
            stringBuilder.Replace(Underline(), "");

            return stringBuilder.ToString();
        }
    }
}
