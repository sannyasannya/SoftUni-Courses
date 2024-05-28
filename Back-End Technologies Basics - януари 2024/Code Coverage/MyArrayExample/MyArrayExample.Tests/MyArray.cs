namespace MyArrayExample.Tests
{
    public class MyArrayTests
    {  
        [Test]
        public void Replace_ShouldReplace_IfPositionIsValid()
        {
            // Arrange
            var myArray = new MyArray(20);

            // Act
            var result = myArray.Replace(0, 100);

            // Assert
            Assert.IsTrue(result);
            Assert.That(myArray.Array[0], Is.EqualTo(100));
        }

        [Test]
        public void Replace_ShouldNotReplace_IfPositionIsLessThanZero()
        {
            // Arrange
            var myArray = new MyArray(20);

            // Act and assert
            Assert.Throws<ArgumentException>(() => myArray.Replace(-20, 2));

            // Assert
        }

        [Test]
        public void Replace_ShouldNotReplace_IfPositionIsBiggerThanTheSizeOfTheArray()
        {
            // Arrange
            var myArray = new MyArray(20);

            // Act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => myArray.Replace(100, 2));

            // Assert
        }

        [Test]
        public void FindMax_ShouldReturnMaxValueInArray()
        {
            // Arrange
            var myArray = new MyArray(20);

            // Act 
            var result = myArray.FindMax();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(19));
        }

        [Test]
        public void FindMax_ShouldThrowInvalidOperationException_IfArrayIsEmpty()
        {
            // Arrange
            var myArray = new MyArray(0);

            // Act and assert
            Assert.Throws<InvalidOperationException>(() =>  myArray.FindMax());
        }
    }
}