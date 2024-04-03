using System.Collections.Generic;
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

    [Fact]
    public void BaseFormatDecorator_AddsFormatSuccessfully()
    {
        BaseFormatDecorator sampleDecorator = new(_sampleText);
        sampleDecorator.AddFormat(new BoldDecorator());

        Assert.Equal(1, sampleDecorator.DecoratorsCount);

    }

    [Fact]
    public void BaseFormatDecorator_Print_ReturnsTrue()
    {
        BaseFormatDecorator sampleDecorator = new(_sampleText);
        sampleDecorator.AddFormat(new BoldDecorator());
        var result = sampleDecorator.Print();

        Assert.True(result);

    }

    [Fact]
    public void TextFormatter_Methods_ReturnCorrectStrings()
    {
        List<string> expected = [" [bold]", " [italic]", " [color]", " [strikethrough]", " [underline]"];
        List<string> result = [];
        TextFormatter sampleFormatter = new();

        result.Add(sampleFormatter.Bold());
        result.Add(sampleFormatter.Italic());
        result.Add(sampleFormatter.Color());
        result.Add(sampleFormatter.Strikethrough());
        result.Add(sampleFormatter.Underline());

        Assert.Equal(expected, result);

    }
}