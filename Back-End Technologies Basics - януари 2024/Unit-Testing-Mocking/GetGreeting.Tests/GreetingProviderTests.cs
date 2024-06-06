using GetGreeting;
using Moq;

namespace GetGreeting.Tests
{
    public class GreetingProviderTest
    {
        private GreetingProvider _greetingProvider;
        private Mock<ITimeProvider> _mockedTimeProvider;

        [SetUp]
        public void SetUp()
        {
            _mockedTimeProvider = new Mock<ITimeProvider>(); // create ITimeprovider
            _greetingProvider = new GreetingProvider(_mockedTimeProvider.Object); // create a fake and take fake dependency inside
        }

        [Test]
        public void GetGreeting_ShouldReturnAMorningMessage_WhenItIsMorning()
        {
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2000, 5, 20, 9, 9, 9)); // control above mocked Time Provider
            
            var result = _greetingProvider.GetGreeting();
            
            Assert.That(result, Is.EqualTo("Good morning!"));
            _mockedTimeProvider.Verify(x => x.GetCurrentTime(), Times.Once);
        }

        [Test]
        public void GetGreeting_ShouldReturnAnAfternoonMessage_WhenItIsAfternoon()
        {
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2020, 5, 18, 15, 10, 10));

            var result = _greetingProvider.GetGreeting();

            Assert.That(result, Is.EqualTo("Good afternoon!"));
        }

        [Test]
        public void GetGreeting_ShouldReturnAnEveningMessage_WhenItIsEvening()
        {
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2020, 5, 18, 20, 10, 10));

            var result = _greetingProvider.GetGreeting();

            Assert.That(result, Is.EqualTo("Good evening!"));
        }

        [Test]
        public void GetGreeting_ShouldReturnANightMessage_WhenItIsNight()
        {
            //Arrange
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2020, 5, 18, 23, 10, 10));

            //Act
            var result = _greetingProvider.GetGreeting();


            //Assert
            Assert.That(result, Is.EqualTo("Good night!"));
        }

        
        [TestCase("Good morning!", 10)]
        [TestCase("Good afternoon!", 14)]
        [TestCase("Good evening!", 20)]
        [TestCase("Good night!", 4)]
        [TestCase("Good night!", 3)]

        public void GetGreeting_ShouldReturnACoorectMessage_WhenTimeIsCorrect(string expectedMessage, int currentTime)
        {
            //Arrange
            _mockedTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(2020, 5, 18, currentTime, 10, 10));

            //Act
            var result = _greetingProvider.GetGreeting();


            //Assert
            Assert.That(result, Is.EqualTo(expectedMessage));
        }
    }
}