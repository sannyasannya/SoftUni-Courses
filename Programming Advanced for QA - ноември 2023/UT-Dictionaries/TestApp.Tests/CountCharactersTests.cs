using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }
    
    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new() { "", "", "" };

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "aaa", "aa", "a" };

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo("a -> 6"));
    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "phone", "phon" };

        StringBuilder sb = new();
        sb.AppendLine("p -> 2");
        sb.AppendLine("h -> 2");
        sb.AppendLine("o -> 2");
        sb.AppendLine("n -> 2");
        sb.AppendLine("e -> 1");

        string expected = sb.ToString().Trim();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "!p!hone!" };

        StringBuilder sb = new();

        sb.AppendLine("! -> 3");
        sb.AppendLine("p -> 1");
        sb.AppendLine("h -> 1");
        sb.AppendLine("o -> 1");
        sb.AppendLine("n -> 1");
        sb.AppendLine("e -> 1");

        string expected = sb.ToString().Trim();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithUpperCaseAndNumberChars_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new() { "San1A235" };

        StringBuilder sb = new();

        sb.AppendLine("S -> 1");
        sb.AppendLine("a -> 1");
        sb.AppendLine("n -> 1");
        sb.AppendLine("1 -> 1");
        sb.AppendLine("A -> 1");
        sb.AppendLine("2 -> 1");
        sb.AppendLine("3 -> 1");
        sb.AppendLine("5 -> 1");

        string expected = sb.ToString().Trim();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
