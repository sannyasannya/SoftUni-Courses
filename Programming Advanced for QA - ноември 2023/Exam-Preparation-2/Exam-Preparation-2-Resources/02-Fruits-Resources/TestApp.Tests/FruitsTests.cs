using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>()
        {
            ["kiwi"] = 10,
            ["apple"] = 20
        };
        string currentFruit = "kiwi";

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, currentFruit);


        // Assert
        Assert.That(result, Is.EqualTo(10));
        
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>()
        {
            ["kiwi"] = 10,
            ["apple"] = 20
        };
        string currentFruit = "orange";

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, currentFruit);


        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>();
        
        string currentFruit = "orange";

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, currentFruit);


        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int>? fruitDictionary = null;

        string currentFruit = "orange";

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, currentFruit);


        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> fruitDictionary = new Dictionary<string, int>()
        {
            ["kiwi"] = 10,
            ["apple"] = 20
        };
        string? currentFruit = null;

        // Act
        int result = Fruits.GetFruitQuantity(fruitDictionary, currentFruit);


        // Assert
        Assert.That(result, Is.EqualTo(0));
    }
}
