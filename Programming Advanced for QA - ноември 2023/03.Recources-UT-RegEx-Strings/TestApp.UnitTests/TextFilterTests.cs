﻿using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string text = "The quick brown fox jumps over the lazy dog";
        string[] bannedWord = new string[] { "bear" };
        // Act
        string result = TextFilter.Filter(bannedWord, text);

        // Assert
        Assert.That(result, Is.EqualTo(text));
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        string text = "The quick brown fox jumps over the lazy dog";
        string[] bannedWord = new[] {"quick"};
        string expected = "The ***** brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(bannedWord, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        // Arrange
        string text = "The quick brown fox jumps over the lazy dog";
        string[] bannedWord = Array.Empty<string> ();
        // Act
        string result = TextFilter.Filter(bannedWord, text);

        // Assert
        Assert.That(result, Is.EqualTo(text));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        string text = "The quick brown fox jumps over the lazy dog";
        string[] bannedWord = new[] { "quick brown", "dog" };
        string expected = "The *********** fox jumps over the lazy ***";

        // Act
        string result = TextFilter.Filter(bannedWord, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
