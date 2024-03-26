using Amdaris.Logging.Abstractions;

namespace Amdaris.Logging.Formatters;
internal class ExceptionLogFormatter : ILogFormatter
{
    public string FormatMessage(string rawMessage)
    {
        return $"[CRITICAL] - {DateTime.Now.ToShortDateString()} - {rawMessage}";
    }
}
