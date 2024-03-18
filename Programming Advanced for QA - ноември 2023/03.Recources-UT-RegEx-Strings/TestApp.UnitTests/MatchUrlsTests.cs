using NUnit.Framework;

using System.Collections.Generic;
using System.Net;

namespace TestApp.UnitTests;

public class MatchUrlsTests
{
        [Test]
    public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
    {
        // Arrange
        string text = "";
        List<string> expected = new List<string>();

        // Act
       List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }
   
    [Test]
    public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
    {
        // Arrange
        string text = "No valid URLs";
        List<string> expected = new List<string>();

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        CollectionAssert.AreEqual (expected, result);
    }

    [Test]
    public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
    {

        // Arrange
        string text = "Single URL: https://softuni.bg";
        List<string> expected = new() { "https://softuni.bg" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
    {

        // Arrange
        string text = "Multiple URLs: https://www.softuni.bg, https://digital.softuni.bg, https://creative.softuni.bg";
        List<string> expected = new() { "https://www.softuni.bg", "https://digital.softuni.bg", "https://creative.softuni.bg" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
    {

        // Arrange
        string text = "Single URL: \"https://softuni.bg/about\"";
        List<string> expected = new() { "https://softuni.bg" };

        // Act
        List<string> result = MatchUrls.ExtractUrls(text);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }
}
