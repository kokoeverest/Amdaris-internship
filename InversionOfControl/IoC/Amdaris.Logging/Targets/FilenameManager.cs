using Amdaris.Logging.Abstractions;

namespace Amdaris.Logging.Targets;
internal class FilenameManager : IFilenameManager
{
    public string CreateFileName()
    {
        return $"Logs_{DateTime.Now.ToString("yyyyMMdd")}.txt";
    }
}
