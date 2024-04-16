using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class GradesTests
{
    [Test]
    public void Test_GetBestStudents_ReturnsBestThreeStudents()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            ["Sanya"] = 5,
            ["Kamen"] = 3,
            ["Vladislav"] = 4,
            ["Nikol"] = 6,
            ["Deni"] = 2

        };

        // Act
        string result = Grades.GetBestStudents(grades);
        string expected = $"Nikol with average grade 6.00{Environment.NewLine}Sanya with average grade 5.00{Environment.NewLine}" +
            $"Vladislav with average grade 4.00";

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
           
        };

        // Act
        string result = Grades.GetBestStudents(grades);
        string expected = "";

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            ["Sanya"] = 5,
            ["Kamen"] = 3          

        };

        // Act
        string result = Grades.GetBestStudents(grades);
        string expected = $"Sanya with average grade 5.00{Environment.NewLine}Kamen with average grade 3.00";          

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
    {
        // Arrange
        Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            ["Sanya"] = 5,
            ["Kamen"] = 5,
            ["Vladislav"] = 5,
            ["Nikol"] = 5,
            ["Deni"] = 5

        };

        // Act
        string result = Grades.GetBestStudents(grades);
        string expected = $"Deni with average grade 5.00{Environment.NewLine}Kamen with average grade 5.00{Environment.NewLine}" +
            $"Nikol with average grade 5.00";

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
