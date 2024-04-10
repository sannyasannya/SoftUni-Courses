using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringRotatorTests
{
    [Test]
    public void Test_RotateRight_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;
        int position = 1;

        // Act
        string result = StringRotator.RotateRight(input, position);

        // Assert
        Assert.That(result, Is.Empty);

    }

    [Test]
    public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
    {
        // Arrange
        string input = "hello";
        int rotation = 0;

        // Act
        string result = StringRotator.RotateRight(input, rotation);

        // Assert
        Assert.That(result, Is.EqualTo("hello"));
    }

    [Test]
    public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "notebook";
        int rotation = 5;

        // Act
        string result = StringRotator.RotateRight(input, rotation);

        // Assert
        Assert.That(result, Is.EqualTo("ebooknot"));
    }

    [Test]
    public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "notebook";
        int rotation = -4;

        // Act
        string result = StringRotator.RotateRight(input, rotation);

        // Assert
        Assert.That(result, Is.EqualTo("booknote"));
    }

    [Test]
    public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
    {

        // Arrange
        string input = "notebook";
        int rotation = 15;

        // Act
        string result = StringRotator.RotateRight(input, rotation);

        // Assert
        Assert.That(result, Is.EqualTo("otebookn"));
    }
}
