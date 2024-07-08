using IdeaAPITesting.Models;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace IdeaAPITesting
{
    public class IdeaApiTests
    {
        private RestClient client;
        private const string BASEURL = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:84";
        private const string EMAIL = "sanya@test.bg";
        private const string PASSWORD = "123456";

        private static string lastIdeaId;

        [OneTimeSetUp]
        public void Setup()
        {
            string jwtToken = GetJwtToken(EMAIL, PASSWORD);

            var options = new RestClientOptions(BASEURL)
            {
                Authenticator = new JwtAuthenticator(jwtToken)
            };

            client = new RestClient(options);
        }

        private string GetJwtToken(string email, string password)
        {
            RestClient authClient = new RestClient(BASEURL);

            var request = new RestRequest("/api/User/Authentication", Method.Post);
            request.AddJsonBody(new
            {
                email,
                password
            });

            var response = authClient.Execute(request);

            if(response.StatusCode == HttpStatusCode.OK)
            {
                var content = JsonSerializer.Deserialize<JsonElement>(response.Content);
                var token = content.GetProperty("accessToken").GetString();

                if(string.IsNullOrWhiteSpace(token))
                {
                    throw new InvalidOperationException("Access Token is null or empty.");
                }
                return token;
            }
            else
            {
                throw new InvalidOperationException($"Unexpected response type {response.StatusCode} with data {response.Content}");
            }
        }

        [Test, Order(1)]
        public void CreateNewIdea_WithCorrectData_ShouldSucceed()
        {
            var requestData = new IdeaDTO
            {
                Title = "TestTitle",
                Url = "",
                Description = "TestDescription"
            };

            var request = new RestRequest($"{BASEURL}/api/Idea/Create", Method.Post);
            //request.AddJsonBody(requestData, "application/json");
            request.AddJsonBody(requestData);

            var response = client.Execute(request);
            var responseData = JsonSerializer.Deserialize<ApiResponseDTO>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseData.Msg, Is.EqualTo("Successfully created!"));
        }

        [Test, Order(2)]
        public void GetAllIdeas_ShouldReturnNonEmptyArray()
        {  
            var request = new RestRequest($"/api/Idea/All");

            var response = client.Execute(request, Method.Get);  
            var responseDataArray = JsonSerializer.Deserialize<ApiResponseDTO[]>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseDataArray.Length, Is.GreaterThan(0));

            //lastIdeaId = responseDataArray[responseDataArray.Length - 1].IdeaId;
            lastIdeaId = responseDataArray.LastOrDefault()?.IdeaId;

        }

        [Test, Order(3)]
        public void EditAnIdea_WithCorrectData_ShouldSucceed()
        {
            var requestData = new IdeaDTO()
            {
                Title = "EditedTestTitle",
                Url = "",
                Description = "TestDescription with Edits",
            };

            var request = new RestRequest("/api/Idea/Edit", Method.Put);
            request.AddQueryParameter("ideaId", lastIdeaId);
            request.AddJsonBody(requestData);

            var response = client.Execute(request);
            var responseData = JsonSerializer.Deserialize<ApiResponseDTO>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseData.Msg, Is.EqualTo("Edited successfully"));
        }

        [Test, Order(4)]
        public void DeleteIdea_ShouldSucceed()
        {
            var request = new RestRequest("/api/Idea/Delete");
            request.AddQueryParameter("ideaId", lastIdeaId);           

            var response = client.Execute(request, Method.Delete);            

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Does.Contain("The idea is deleted!"));
        }

        [Test, Order(5)]
        public void CreateNewIdea_WithoutCorrectData_ShouldFail()
        {
            var requestData = new IdeaDTO
            {
                Title = "TestTitle",                
            };

            var request = new RestRequest("/api/Idea/Create", Method.Post);
            
            request.AddJsonBody(requestData);

            var response = client.Execute(request);
            var responseData = JsonSerializer.Deserialize<ApiResponseDTO>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            
        }

        [Test, Order(6)]
        public void EditAnIdea_WithWrongId_ShouldFail()
        {
            var requestData = new IdeaDTO()
            {
                Title = "EditedTestTitle",               
                Description = "TestDescription with Edits",
            };

            var request = new RestRequest("/api/Idea/Edit");
            request.AddQueryParameter("ideaId", "112233");
            request.AddJsonBody(requestData);

            var response = client.Execute(request, Method.Put);
           

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Does.Contain("There is no such idea!"));
        }

        [Test, Order(7)]
        public void DeleteIdea_WithWrongId_ShouldFail()
        {
            var request = new RestRequest("/api/Idea/Delete");
            request.AddQueryParameter("ideaId", "1122333");

            var response = client.Execute(request, Method.Delete);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Does.Contain("There is no such idea!"));
        }
    }
}