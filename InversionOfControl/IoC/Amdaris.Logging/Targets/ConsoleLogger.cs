using Amdaris.Logging.Abstractions;

namespace Amdaris.Logging.Targets;
internal class ConsoleLogger : IAmdarisLogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
