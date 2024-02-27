using NUnit.Framework;

using System;
using System.Text;

namespace TestApp.Tests;

public class CountRealNumbersTests
{    
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] numbers = new int[] { };

        // Act
        string result = CountRealNumbers.Count(numbers);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] numbers = new int[] { 1 };

        // Act
        string result = CountRealNumbers.Count(numbers);


        // Assert
        Assert.That(result, Is.EqualTo("1 -> 1"));

    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] numbers = new int[] { 1, 2, 3 };
        StringBuilder sb = new();

        sb.AppendLine("1 -> 1");
        sb.AppendLine("2 -> 1");
        sb.AppendLine("3 -> 1");       

        string expected = sb.ToString().Trim();

        // Act
        string result = CountRealNumbers.Count(numbers);


        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] numbers = new int[] { -1, -2, -3, -1 };

        StringBuilder sb = new();

        sb.AppendLine("-3 -> 1");
        sb.AppendLine("-2 -> 1");
        sb.AppendLine("-1 -> 2");
        

        string expected = sb.ToString().Trim();

        // Act
        string result = CountRealNumbers.Count(numbers);


        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {

        // Arrange
        int[] numbers = new int[] { 0, 0, 0, 0, 0 };
        

        // Act
        string result = CountRealNumbers.Count(numbers);


        // Assert
        Assert.That(result, Is.EqualTo("0 -> 5"));
    }
}
