//Assignment requirements
//You are tasked with designing and implementing a text formatting tool that allows users to
//apply various formatting options to text, such as bold, italic, underline, and color.
//Your implementation should focus on applying the appropiate design patterns for this task. 

//Scenario: The text formatting tool needs to support multiple formatting options and provide
//a unified interface for users to apply formatting to text.The system should allow users to apply
//formatting options in any order and combine multiple formatting options as needed.

//Functional Requirements:

// 1. Implement multiple text formatting options such as bold, italic, underline, and color.
// 2. Allow users to apply formatting options to text strings.
// 3. Provide options for users to combine multiple formatting options and apply them to text.
// 4. Ensure that the system can remove applied formatting options from text.


//You don't have to actually print the text with the chosen formats. You can simulate this by just printing in
//the console something like "This is a white text on black background with italic and bold"

using StructuralDesignPatterns;

string text = "The quick brown fox jumps over the lazy dog [italic]";
TextPrinterFacade printer = new();

printer.PrintText(text);

printer.PrintText(text, []);

printer.PrintText(text, ['b', 'i', 'b']);

printer.PrintText(text, ['u', 's']);
