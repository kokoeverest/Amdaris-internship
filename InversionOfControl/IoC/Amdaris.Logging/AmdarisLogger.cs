using Amdaris.Logging.Abstractions;
using Amdaris.Logging.Formatters;
using Amdaris.Logging.Targets;

namespace Amdaris.Logging;
public class AmdarisLogger
{
    private readonly IAmdarisLogger[] _loggers;
    private readonly ILogFormatter[] _formatters;

    public AmdarisLogger(IFilenameManager filenameManager)
    {
        _loggers =
        [
            new ConsoleLogger(),
            new FileLogger(filenameManager)
        ];
        _formatters =
        [
            new DefaultLogFormatter(),
            new ExceptionLogFormatter()
        ];  
    }

    public void LogMessage(string message, bool isException = false)
    {
        ILogFormatter activeFormatter = isException ? _formatters[1] : _formatters[0];
        var formatted = activeFormatter.FormatMessage(message);
        foreach (var logger in _loggers)
        {
            logger.Log(formatted);
        }
    }
}
