using System.Text.RegularExpressions;

string text = @"In object-oriented programming, encapsulation is a fundamental principle that involves bundling data and methods that operate on that data within a single unit or class. This concept allows for the hiding of implementation details from the outside world and exposing only the necessary interfaces for interacting with the object. By encapsulating data and methods together, we promote code reusability, maintainability, and flexibility.One of the key benefits of encapsulation is the ability to enforce access control on the members of a class. This means we can specify which parts of the class are accessible to the outside world and which are not. By using access modifiers such as public, private, and protected, we can control the visibility of members, ensuring that they are only accessed in appropriate ways. For example, we may have a class representing a bank account with properties such as balance and methods for depositing and withdrawing funds. By making the balance property private and providing public methods for depositing and withdrawing funds, we encapsulate the internal state of the account and ensure that it can only be modified in a controlled manner. Encapsulation also allows us to enforce data validation and maintain invariants within our classes. By providing controlled access to data through methods, we can ensure that it is always in a valid state. For instance, when setting the balance of a bank account, we can check that the new balance is not negative before updating the internal state of the object. Overall, encapsulation is a powerful concept in object-oriented programming that promotes modularity, reusability, and maintainability. By bundling data and methods together within a class and controlling access to them, we can create more robust and flexible software systems.";

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
    char firstLetter = text[text.Length - 1];
    int start = 0;
    int end = text.Length - 1;
    string otherLetters = "";
    if (start < end)
    {
        otherLetters = text.Substring(start, end);
    }
    return firstLetter + ReverseString(otherLetters);
}

Console.WriteLine($"This is a reversed text:\n\n{ReverseString(text)}\n");


//- In the given string, replace all occurances of "object-oriented programming" with "OOP" and display the new string

Console.WriteLine($"Replacing the 'object-oriented programming' with 'OOP':\n\n{text.Replace("object-oriented programming", "OOP")}");

// Examples for practicing DateTime suggested by ChatGPT

// 1.Calculating Age:

//Use DateTime to capture birth dates and calculate age using DateTime.Now.
//Utilize TimeSpan to calculate the difference between birth dates and the current date.

// 2.Working with Time Zones:

//Convert a DateTime from one time zone to another using TimeZoneInfo and DateTimeOffset.
//Display the current time in different time zones using TimeZoneInfo.

// 3.Formatting Date and Time:

//Format a DateTime object into a string representation using various custom format strings.
//Utilize CultureInfo to format dates and times based on different cultures.

// 4.Date and Time Arithmetic:

//Add or subtract TimeSpan intervals to DateTime objects to perform date and time arithmetic.

// 5.Handling Daylight Saving Time (DST):

//Convert between DateTime and DateTimeOffset to handle DST transitions accurately.

// 6.Scheduling Tasks:

//Implement a simple task scheduler that uses DateTime and TimeSpan to schedule and execute tasks at specific times.

// 7.Working with Durations:

//Calculate the total duration of a series of time intervals using TimeSpan.
//Display durations in a user-friendly format (e.g., "2 hours and 30 minutes").

// 8.Parsing Date and Time Strings:

//Parse date and time strings in different formats using DateTime.ParseExact and DateTimeOffset.ParseExact.

// 9.Time Span Conversion:

//Convert time spans to different units (e.g., days, hours, minutes) using properties like Days, Hours, and Minutes.

// 10.Internationalization and Localization:

//Use CultureInfo to format dates and times according to the user's preferred culture and language.
//Display dates and times in different formats based on the selected culture.