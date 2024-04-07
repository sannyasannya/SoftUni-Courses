using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> firstDictionary = new();
        Dictionary<string, int> secondDictionary = new();

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstDictionary, secondDictionary);

        // Assert       
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> firstDictionary = new()
        {
            {"one", 1},
            {"two", 2}
        };

        Dictionary<string, int> secondDictionary = new();

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstDictionary, secondDictionary);

        // Assert       
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> firstDictionary = new()
        {
            {"one", 1},
            {"two", 2}
        };

        Dictionary<string, int> secondDictionary = new()
        {
            { "three", 3 },
            { "four", 4 }
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstDictionary, secondDictionary);

        // Assert       
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange
        Dictionary<string, int> firstDictionary = new()
        {
            {"one", 1},
            {"two", 2}
        };

        Dictionary<string, int> secondDictionary = new()
        {
            { "one", 1 },
            { "two", 2 },
            { "four", 4 }
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstDictionary, secondDictionary);

        // Assert       
        Assert.AreEqual(2, result.Count);

        Assert.IsTrue(result.ContainsKey("one"));
        Assert.AreEqual(1, result["one"]);

        Assert.IsTrue(result.ContainsKey("two"));
        Assert.AreEqual(2, result["two"]);

        Assert.IsFalse(result.ContainsKey("four"));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> firstDictionary = new()
        {
            {"one", 1},
            {"two", 2}
        };

        Dictionary<string, int> secondDictionary = new()
        {
            { "one", 10 },
            { "two", 20 }           
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(firstDictionary, secondDictionary);

        // Assert
        Assert.AreEqual(0, result.Count);
        Assert.IsTrue(!result.Any());
    }
}
