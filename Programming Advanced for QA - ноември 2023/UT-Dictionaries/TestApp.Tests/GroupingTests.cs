using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TestApp.Tests;

public class GroupingTests
{   
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> list = new List<int>() {};

        // Act
        string result = Grouping.GroupNumbers(list);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> numbers = new List<int>() { 1, 2, 3, 4 };
        StringBuilder sb = new();

        sb.AppendLine("Odd numbers: 1, 3");
        sb.AppendLine("Even numbers: 2, 4");

        string expected = sb.ToString().Trim();

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> numbers = new List<int>() { 2, 4, 6, 8 };
        StringBuilder sb = new();
        
        sb.AppendLine("Even numbers: 2, 4, 6, 8");

        string expected = sb.ToString().Trim();

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> numbers = new List<int>() { 1, 3, 5, 7 };
        StringBuilder sb = new();

        sb.AppendLine("Odd numbers: 1, 3, 5, 7");

        string expected = sb.ToString().Trim();

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> numbers = new List<int>() { -1, -3, -4, -6 };
        StringBuilder sb = new();

        sb.AppendLine("Odd numbers: -1, -3");
        sb.AppendLine("Even numbers: -4, -6");

        string expected = sb.ToString().Trim();

        // Act
        string result = Grouping.GroupNumbers(numbers);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
