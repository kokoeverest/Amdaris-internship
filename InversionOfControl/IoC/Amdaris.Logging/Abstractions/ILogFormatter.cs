
namespace Amdaris.Logging.Abstractions;
public interface ILogFormatter
{
    string FormatMessage(string rawMessage);
}
