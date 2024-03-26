using Amdaris.Logging.Abstractions;

namespace Amdaris.Logging.Targets;
internal class FileLogger : IAmdarisLogger
{
    private readonly IFilenameManager _filenameManager;
    public FileLogger(IFilenameManager filenameManager)
    {
        _filenameManager = filenameManager;
    }
    public void Log(string message)
    {
        File.WriteAllText(_filenameManager.CreateFileName(), message);
    }
}
