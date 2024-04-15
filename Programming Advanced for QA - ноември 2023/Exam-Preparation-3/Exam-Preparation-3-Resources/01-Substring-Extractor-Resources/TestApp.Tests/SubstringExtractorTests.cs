using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class SubstringExtractorTests
{
    [Test]
    public void Test_ExtractSubstringBetweenMarkers_SubstringFound_ReturnsExtractedSubstring()
    {
        // Arrange
        string input = "aaa bbb ccc";
        string startMarker = "aaa";
        string endMarker = "ccc";

        // Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.That(result, Is.EqualTo(" bbb "));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartMarkerNotFound_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "aaa bbb ccc";
        string startMarker = "ooo";
        string endMarker = "ccc";

        // Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.That(result, Is.EqualTo("Substring not found"));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_EndMarkerNotFound_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "aaa bbb ccc";
        string startMarker = "aaa";
        string endMarker = "sss";

        // Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.That(result, Is.EqualTo("Substring not found"));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersNotFound_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "aaa bbb ccc";
        string startMarker = "m";
        string endMarker = "n";

        // Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.That(result, Is.EqualTo("Substring not found"));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_EmptyInput_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "";
        string startMarker = "aaa";
        string endMarker = "sss";

        // Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.That(result, Is.EqualTo("Substring not found"));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersOverlapping_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "aabb";
        string startMarker = "aa";
        string endMarker = "ab";

        // Act
        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        // Assert
        Assert.That(result, Is.EqualTo("Substring not found"));
    }
}
