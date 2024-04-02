using StructuralDesignPatterns;

namespace StructuralDesignPatternsTests;

public class StructuralDesignPatternsTests
{

    private readonly TextPrinterFacade _printer = new();
    private readonly string _sampleText = "This is a sample message";

    [Fact]
    public void PrintText_WithoutArguments_ReturnsTrue()
    {

        Assert.True(_printer.PrintText(_sampleText));   
    }

    [Fact]
    public void PrintText_WithEmptyArgumentsList_ReturnsTrue()
    {

        Assert.True(_printer.PrintText(_sampleText, []));   
    }

    [Fact]
    public void PrintText_WithArgumentsList_ReturnsTrue()
    {

        Assert.True(_printer.PrintText(_sampleText, ['b', 'i']));   
    }

    [Fact]
    public void RemoveFormatting_ReturnsOriginalText()
    {
        var result = _printer.RemoveFormatting(_sampleText);

        Assert.Equal("This is a sample message",  result);   
    }


    [Theory]
    [InlineData("This is a sample message", "This is a sample message")]
    [InlineData("This is a sample message [bold] [italic]", "This is a sample message")]
    [InlineData("This is a sample message [bold] [italic] [underline]", "This is a sample message")]
    public void RemoveFormatting_ReturnsFormattedText(string text, string formattedText)
    {
        var result = _printer.RemoveFormatting(text);

        Assert.Equal(formattedText, result);   
    }
}