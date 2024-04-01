
namespace FileSystemsAndStreams
{
    public class Logger(string methodName, bool success)
    {
        public string BaseFolder = @"C:\Users\user\Kofe\Internship Project\Internship Project\Logs";
        public string Method = methodName;
        public DateTime Date = DateTime.Now;
        public bool Success = success;

        public async Task LogMessage(Logger log)
        {
            string fileName = @$"{BaseFolder}\Logs_{Date.Day}.{Date.Month}.{Date.Year}.txt";
            string lineToLog = $"{log.Method} {log.Date} {log.Success}";
           
            if (!File.Exists(fileName))
            {
                File.CreateText(fileName);
            }
            
            try
            {
                using StreamWriter writer = new(path: fileName, append: true);
                await writer.WriteLineAsync(lineToLog);
                
                await Console.Out.WriteLineAsync("Content was appended to the file!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error: {ex.Message}");
            }
        }
    }
}
