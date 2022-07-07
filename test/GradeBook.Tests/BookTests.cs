using System;
using Xunit;

namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void BasicMathTest()
    {
        // arrange
        var x = 5;
        var y = 2;
        var expected = 7;
        // act
        var actual = x + y;
        // assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
        // arrange
        var book = new Book("");  // <- is this legal with empty string? verify with BA
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);
        // act
        var result = book.GetStats();  // Going to build an OBJECT with Average, Max, Min Keys


        // assert
        Assert.Equal(85.6, result.Average, 1);
        Assert.Equal(90.5, result.High, 1);
        Assert.Equal(77.3, result.Low, 1);
        Assert.Equal('B', result.Letter);

    }
    [Fact]
    public void AddGradeAcceptsCorrectValue()
    {
        var book = new Book("");
        book.AddGrade(105);
        var result = book.GetCount();
        Console.WriteLine($"GetCount result = {result}");

        Assert.Equal(0, result);
    }
}