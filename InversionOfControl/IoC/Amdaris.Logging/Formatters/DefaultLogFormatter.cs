using Amdaris.Logging.Abstractions;

namespace Amdaris.Logging.Formatters;
internal class DefaultLogFormatter : ILogFormatter
{
    public string FormatMessage(string rawMessage)
    {
        return $"{DateTime.Now.ToShortDateString()} - {rawMessage}";
    }
}
