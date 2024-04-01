using FileSystemsAndStreams;


//In your internship project:

//1.Implement logging to filesystem in all your business logic methods.

//2. Each time your method gets called you should add a log to your log file. Your log file should contain: the name of the method, Date and Time the method was called, outcome of the method (either "success" or "failure" if the method threw an exception)

//3. Each log should be written on a dedicated line

//4. Use async operations for writing and reading information from your log file

//5. The name of the log file should be "Logs_{date}"

//6. Each day, the system should generate a new log file containing the current date. All logs generated during a day should be placed in the log file with the appropriate date

//7. When you're ready, anser this question with the word "Done".

//8. Check with your mentor for feedback

List<int> numbers = [1, 2, 3, 4, 5, 6];
async Task<bool> SumNumbers(List<int> numbers)
{
    Logger currentLog = new("SumNumbers", true);
    try
    {
        var result = numbers.Aggregate((agg, num) => agg + num);
        await currentLog.LogMessage(currentLog);
        Console.WriteLine(result);
        return true;

    }
    catch (InvalidOperationException)
    {
        currentLog.Success = false;
        await currentLog.LogMessage(currentLog);
        return false;
    }
}


await SumNumbers(numbers);
