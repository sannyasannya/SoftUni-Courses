using Eventmi.Core.Models.Event;
using RestSharp;


namespace Eventmi.Tests
{
    public class Tests
    {
        private RestClient _client;
        private string _baseUrl = "https://localhost:7236";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(_baseUrl);
        }

        [Test]
        public async Task GetAllEvents_ReturnsSuccessStatusCode()
        {
            // Arrange
            var request = new RestRequest("/Event/All", Method.Get);

            // Act
            var response = await _client.ExecuteAsync(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Add_GetRequest_ReturnsAddView()
        {
            // Arrange
            var request = new RestRequest("/Event/Add", Method.Get);

            // Act
            var response = await _client.ExecuteAsync(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Add_PostRequest_AddsNewEventAndRedirects()
        {
            // Arrange
            var input = new EventFormModel()
            {
                Name = "Soft Uni Conf",
                Place = "SoftUni",
                Start = new DateTime(2024, 12, 12, 12, 0, 0)
            };

            // Act

            // Assert
        }
    }
}