using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class NumberFrequencyTests
{
    [Test]
    public void Test_CountDigits_ZeroNumber_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<int, int> digitFrequancy = new();
        int number = 0;


        // Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(number);

        // Assert
        Assert.That(result, Is.EqualTo(digitFrequancy));
    }

    [Test]
    public void Test_CountDigits_SingleDigitNumber_ReturnsDictionaryWithSingleEntry()
    {
        // Arrange
        Dictionary<int, int> digitFrequancy = new()
        {
            { 1, 1 }
        };

        int number = 1;

        // Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(number);

        // Assert
        Assert.That(result, Is.EqualTo(digitFrequancy));
    }

    [Test]
    public void Test_CountDigits_MultipleDigitNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        // Arrange
        Dictionary<int, int> digitFrequancy = new()
        {
            { 1, 3 },
            { 2, 3 }            
        };

        int number = 121212;

        // Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(number);

        // Assert
        Assert.That(result, Is.EqualTo(digitFrequancy));
    }

    [Test]
    public void Test_CountDigits_NegativeNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        // Arrange
        Dictionary<int, int> digitFrequancy = new()
        {
            { 1, 3 },
            { 2, 3 }
        };

       

        int number = -121212;

        // Act
        Dictionary<int, int> result = NumberFrequency.CountDigits(number);

        // Assert
        Assert.That(result, Is.EqualTo(digitFrequancy));
    }
}
