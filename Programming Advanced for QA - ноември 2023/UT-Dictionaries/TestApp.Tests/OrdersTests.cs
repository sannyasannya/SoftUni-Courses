using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = new string[0];

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new[] 
        { 
            "apple 0.50 1",
            "banana 0.75 2",
            "banana 0.75 3",
            "orange 0.99 2",
            "apple 1.99 2"
        };

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo($"apple -> 5.97{Environment.NewLine}banana -> 3.75{Environment.NewLine}orange -> 1.98"));
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        string[] input = new[] 
        { 
            "apple 0.50 1",
            "banana 0.7500002 2",
            "banana 0.75000005 3",
            "orange 0.989999999 2",
            "apple 1.99000000001 2"
        };

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo($"apple -> 5.97{Environment.NewLine}banana -> 3.75{Environment.NewLine}orange -> 1.98"));
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new[]
        {
            "apple 2.00 4.5",
            "banana 3.00 2.5",           
            "orange 1.00 3.5"            
        };

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo($"apple -> 9.00{Environment.NewLine}banana -> 7.50{Environment.NewLine}orange -> 3.50"));
    }

    [Test]
    public void Test_Order_WithWrongArrangement_ShouldThrowException()
    {
        // Arrange
        string[] input = new[]
        {
            "2.00 apple 4.5",
            "banana 3.00 2.5",
            "orange 1.00 3.5"
        };

        // Act & Assert
        Assert.That(() => Orders.Order(input), Throws.Exception);


    }
}
