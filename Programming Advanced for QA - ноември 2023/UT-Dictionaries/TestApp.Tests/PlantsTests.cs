using NUnit.Framework;

using System;
using System.Text;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] plants = { };

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.Empty);
    }
    
    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] plants = { "@--\\-" };

        StringBuilder sb = new();

        sb.AppendLine("Plants with 5 letters:");
        sb.AppendLine("@--\\-");
       

        string expected = sb.ToString().Trim();
       

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] plants = { "rose", "lily", "dracaena", "lavender" };

        StringBuilder sb = new();

        sb.AppendLine("Plants with 4 letters:");
        sb.AppendLine("rose");
        sb.AppendLine("lily");
        sb.AppendLine("Plants with 8 letters:");
        sb.AppendLine("dracaena");
        sb.AppendLine("lavender");


        string expected = sb.ToString().Trim();

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] plants = { "rOse", "liLy", "aBcde", "Fdgre"};

        StringBuilder sb = new();

        sb.AppendLine("Plants with 4 letters:");
        sb.AppendLine("rOse");
        sb.AppendLine("liLy");
        sb.AppendLine("Plants with 5 letters:");
        sb.AppendLine("aBcde");
        sb.AppendLine("Fdgre");


        string expected = sb.ToString().Trim();


        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
   
}
