using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        string productName = "Banana";
        double productPrice = 100;
        int productQuantity = 10;

        string expectedInventory = $"Product Inventory:{Environment.NewLine}" +
            $"{productName} - Price: ${productPrice:f2} - Quantity: {productQuantity}";

        // Act
        this._inventory.AddProduct(productName, productPrice, productQuantity);

        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expectedInventory));
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange
        string expected = "Product Inventory:";

        // Act
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        string firstProduct = "Tuna";
        double firstProductPrice = 100;
        int firstProductQuantity = 10;

        string secondProduct = "Rice";
        double secondProductPrice = 10;
        int secondProductQuantity = 5;

        string expectedOutput = $"Product Inventory:{Environment.NewLine}" +
            $"{firstProduct} - Price: ${firstProductPrice:f2} - Quantity: {firstProductQuantity}{Environment.NewLine}" +
            $"{secondProduct} - Price: ${secondProductPrice:f2} - Quantity: {secondProductQuantity}";

        // Act
        this._inventory.AddProduct(firstProduct, firstProductPrice, firstProductQuantity);
        this._inventory.AddProduct(secondProduct, secondProductPrice, secondProductQuantity);

        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Arrange

        // Act
        double result = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange
        string firstProductName = "Kiwi";
        double firstProductPrice = 20;
        int firstProductQuantity = 5;

        string secondProductName = "Orange";
        double secondProductPrice = 30;
        int secondProductQuantity = 10;

        double expected = 400;
        
        // Act
        this._inventory.AddProduct(firstProductName, firstProductPrice, firstProductQuantity);
        this._inventory.AddProduct(secondProductName, secondProductPrice, secondProductQuantity);

        double result = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
