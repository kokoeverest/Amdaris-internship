using System.Globalization;
using System.Text.RegularExpressions;

string text = @"In object-oriented programming, encapsulation is a fundamental principle that involves bundling data and methods that operate on that data within a single unit or class. This concept allows for the hiding of implementation details from the outside world and exposing only the necessary interfaces for interacting with the object. By encapsulating data and methods together, we promote code reusability, maintainability, and flexibility.One of the key benefits of encapsulation is the ability to enforce access control on the members of a class. This means we can specify which parts of the class are accessible to the outside world and which are not. By using access modifiers such as public, private, and protected, we can control the visibility of members, ensuring that they are only accessed in appropriate ways. For example, we may have a class representing a bank account with properties such as balance and methods for depositing and withdrawing funds. By making the balance property private and providing public methods for depositing and withdrawing funds, we encapsulate the internal state of the account and ensure that it can only be modified in a controlled manner. Encapsulation also allows us to enforce data validation and maintain invariants within our classes. By providing controlled access to data through methods, we can ensure that it is always in a valid state. For instance, when setting the balance of a bank account, we can check that the new balance is not negative before updating the internal state of the object. Overall, encapsulation is a powerful concept in object-oriented programming that promotes modularity, reusability, and maintainability. By bundling data and methods together within a class and controlling access to them, we can create more robust and flexible software systems.";

void StringExamples(string text)

{
    //- Display the word count of this string
    string newText = text.Replace("-", " ");
    Console.WriteLine($"The word count of the text, split by whitespace only is: {text.Split().Length}\n");

    Console.WriteLine($"The word count after replacing the '-' with a whitespace: {newText.Split().Length}\n");

    //- Display the sentence count of this string

    Console.WriteLine($"Sentence count in the text: {text.Split(".").Length} \n");

    //- Display how often the word "encapsulation" appears in this string

    string pattern = $@"\b{Regex.Escape("encapsulation")}\b";

    Regex regex = new(pattern);
    MatchCollection matches = regex.Matches(text);

    Console.WriteLine($"Using Regex, the word encapsulation appears {matches.Count()} times in the text\n");

    int counter = 0;
    foreach (string word in text.Split())
    {
        if (word.Equals("encapsulation", StringComparison.CurrentCultureIgnoreCase))
            counter++;
    }

    Console.WriteLine($"Using StringComparison.CurrentCultureIgnoreCase, the word encapsulation appears {counter} times in the text\n");

    //- Display this string in reverse, without using any C# language feature. (Create your own algorith)

    string ReverseString(string text)
    {
        if (text == "")
        {
            return "";
        }
        int endIndex = text.Length - 1;
        int startIndex = 0;
        char firstLetter = text[endIndex];
        string otherLetters = "";
        if (startIndex < endIndex)
        {
            otherLetters = text.Substring(startIndex, endIndex);
        }
        return firstLetter + ReverseString(otherLetters);
    }

    Console.WriteLine($"This is a reversed text:\n\n{ReverseString(text)}\n");


    //- In the given string, replace all occurances of "object-oriented programming" with "OOP" and display the new string

    Console.WriteLine($"Replacing the 'object-oriented programming' with 'OOP':\n\n{text.Replace("object-oriented programming", "OOP")}");
}

void DateTimeExamples()
{

// Examples for practicing DateTime suggested by ChatGPT

// 1.Calculating Age:
//Use DateTime to capture birth dates and calculate age using DateTime.Now.
//Utilize TimeSpan to calculate the difference between birth dates and the current date.

DateTime birthDay= DateTime.Parse("30/09/1983");

DateTime today = DateTime.Now;
TimeSpan age = today.Subtract(birthDay);
Console.WriteLine($"\nToday I'm {(int)(age.TotalDays / 365)} years old :)\n");

// 2.Working with Time Zones:
//Convert a DateTime from one time zone to another using TimeZoneInfo and DateTimeOffset.
//Display the current time in different time zones using TimeZoneInfo.

var zoneInfo = TimeZoneInfo.GetSystemTimeZones();
var span = new TimeSpan(0, 4, 0, 0);
string spanString = $"(UTC+0{span.TotalHours}:00)";

DateTimeOffset newOffset = DateTime.Now.Add(span).ToUniversalTime();
string template = "{0, -35} {1, 45} UTC";

foreach (TimeZoneInfo zone in zoneInfo)
{
    if (zone.ToString().StartsWith(spanString))
    {
        Console.WriteLine(string.Format(template, zone.DisplayName, newOffset.ToUniversalTime()));
    }
}

// 3.Formatting Date and Time:
//Format a DateTime object into a string representation using various custom format strings.
//Utilize CultureInfo to format dates and times based on different cultures.
CultureInfo invariant = CultureInfo.InvariantCulture;
Console.WriteLine($"\nDateTime format with invariant CultureInfo: {today.ToString(invariant)}");
Console.WriteLine($"DateTime format with CurrentCulture: {today.ToString(CultureInfo.CurrentCulture)}\n");

// 4.Date and Time Arithmetic:
//Add or subtract TimeSpan intervals to DateTime objects to perform date and time arithmetic.
Console.WriteLine($"UtcNow: {DateTime.UtcNow.TimeOfDay}");
Console.WriteLine($"UtcNow + {span} hours: {DateTime.UtcNow.Add(span).TimeOfDay}");
Console.WriteLine($"UtcNow - {span} hours: {DateTime.UtcNow.Subtract(span).TimeOfDay}\n");

// 5.Parsing Date and Time Strings:
//Parse date and time strings in different formats using DateTime.ParseExact and DateTimeOffset.ParseExact.
string ayaBirthDay = "Thu 31 Jul 2008 8:30 AM +00:00";
string example2 = "12/04/2028";

DateTime ayaBirthDayDateTime = DateTime.ParseExact(ayaBirthDay, "ddd dd MMM yyyy h:mm tt zzz", invariant);
DateTime dateTimeExample2 = DateTime.ParseExact(example2, "d", invariant);
Console.WriteLine(ayaBirthDayDateTime);
Console.WriteLine(dateTimeExample2);

// 6.Time Span Conversion:
//Convert time spans to different units (e.g., days, hours, minutes) using properties like Days, Hours, and Minutes.
TimeSpan ayaAge = today.Subtract(ayaBirthDayDateTime);
Console.WriteLine($"\nAya age is: {ayaAge.TotalDays / 365:N2} years");
}


void OptionalAssignment(string line)
{
    string startTag = "<app>";
    string endTag = "</app>";
    List<string> tagsStack = [];

    while (line != "")
    {
        if (line.StartsWith(startTag))
        {
            tagsStack.Add(startTag); 
            line = line.Substring(5);
        }
        else if (line.StartsWith(endTag))
        {
            if (tagsStack.Count > 0 && tagsStack.Last() == startTag)
            {
                tagsStack.RemoveAt(tagsStack.Count - 1);
                line = line.Substring(6);
            }
            else
            {
                tagsStack.Add(endTag);
                line = line.Substring(6);
            }
        }
    }
    Console.WriteLine(tagsStack.Count);
}

StringExamples(text);
DateTimeExamples();
OptionalAssignment("<app><app><app></app></app>");
OptionalAssignment("<app></app></app><app><app>");
OptionalAssignment("</app><app><app></app></app>");
OptionalAssignment("<app><app><app></app></app></app>");
OptionalAssignment("</app></app></app><app><app><app>");
OptionalAssignment("");