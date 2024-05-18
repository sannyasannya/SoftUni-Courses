using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MoviesLibraryAPI.Controllers;
using MoviesLibraryAPI.Controllers.Contracts;
using MoviesLibraryAPI.Data.Models;
using MoviesLibraryAPI.Services;
using MoviesLibraryAPI.Services.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibraryAPI.Tests
{
    [TestFixture]
    public class NUnitIntegrationTests
    {
        private MoviesLibraryNUnitTestDbContext _dbContext;
        private IMoviesLibraryController _controller;
        private IMoviesRepository _repository;
        IConfiguration _configuration;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        [SetUp]
        public async Task Setup()
        {
            string dbName = $"MoviesLibraryTestDb_{Guid.NewGuid()}";
            _dbContext = new MoviesLibraryNUnitTestDbContext(_configuration, dbName);

            _repository = new MoviesRepository(_dbContext.Movies);
            _controller = new MoviesLibraryController(_repository);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dbContext.ClearDatabaseAsync();
        }

        [Test]
        public async Task AddMovieAsync_WhenValidMovieProvided_ShouldAddToDatabase()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            // Act
            await _controller.AddAsync(movie);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == movie.Title).FirstOrDefaultAsync();
            Assert.IsNotNull(resultMovie);
        }

        [Test]
        public async Task AddMovieAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var invalidMovie = new Movie
            {
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
                // Provide an invalid movie object, for example, missing required fields like 'Title'
                // Assuming 'Title' is a required field, do not set it
            };

            // Act and Assert
            // Expect a ValidationException because the movie is missing a required field
            var exception = Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
        }

        [Test]
        public async Task DeleteAsync_WhenValidTitleProvided_ShouldDeleteMovie()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie2",
                Director = "Test Director2",
                YearReleased = 2021,
                Genre = "Love",
                Duration = 88,
                Rating = 7.5
            };
            await _controller.AddAsync(movie);

            // Act
            await _controller.DeleteAsync(movie.Title);

            // Assert
            // The movie should no longer exist in the database
            var result = await _dbContext.Movies.Find(m => m.Title == movie.Title).FirstOrDefaultAsync();
            Assert.IsNull(result);
        }


        [Test]
        public async Task DeleteAsync_WhenTitleIsNull_ShouldThrowArgumentException()
        {
            // Act and Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(null));
            Assert.That(exception.Message, Is.EqualTo("Title cannot be empty."));
        }

        [Test]
        public async Task DeleteAsync_WhenTitleIsEmpty_ShouldThrowArgumentException()
        {
            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(""));
            //Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(string.Empty));
        }

        [Test]
        public async Task DeleteAsync_WhenTitleDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Act and Assert
            var exception = Assert.ThrowsAsync<InvalidOperationException>(() => _controller.DeleteAsync("kamen"));
            Assert.That(exception.Message, Is.EqualTo($"Movie with title 'kamen' not found."));           
            
        }

        [Test]
        public async Task GetAllAsync_WhenNoMoviesExist_ShouldReturnEmptyList()
        {
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetAllAsync_WhenMoviesExist_ShouldReturnAllMovies()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie2",
                Director = "Test Director2",
                YearReleased = 2021,
                Genre = "Love",
                Duration = 88,
                Rating = 7.5
            };
            await _controller.AddAsync(movie);

            var movie2 = new Movie
            {
                Title = "Test Movie3",
                Director = "Test Director3",
                YearReleased = 2020,
                Genre = "Action",
                Duration = 88,
                Rating = 7.5
            };
            await _controller.AddAsync(movie2);

            // Act
            var allMovies = await _controller.GetAllAsync();

            // Assert
            // Ensure that all movies are returned
            Assert.IsNotEmpty(allMovies);
            Assert.That(allMovies.Count, Is.EqualTo(2));

            var hasFirstMovie = allMovies.Any(x => x.Title == movie.Title);
            Assert.IsTrue(hasFirstMovie);
        }

        [Test]
        public async Task GetByTitle_WhenTitleExists_ShouldReturnMatchingMovie()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Love Family",
                Director = "Love Director",
                YearReleased = 2021,
                Genre = "Love",
                Duration = 88,
                Rating = 7.5
            };
            await _controller.AddAsync(movie);

            // Act
            var exception = await _controller.GetByTitle(movie.Title);

            // Assert
            Assert.IsNotNull(exception);
            Assert.That(exception.Title, Is.EqualTo(movie.Title));
            Assert.That(exception.Director, Is.EqualTo(movie.Director));
            Assert.That(exception.Genre, Is.EqualTo(movie.Genre));
            Assert.That(exception.YearReleased, Is.EqualTo(movie.YearReleased));
            Assert.That(exception.Duration, Is.EqualTo(movie.Duration));
            Assert.That(exception.Rating, Is.EqualTo(movie.Rating));
        }

        [Test]
        public async Task GetByTitle_WhenTitleDoesNotExist_ShouldReturnNull()
        {
            // Act
            var resultMovie = await _controller.GetByTitle("Bye");               

            // Assert
            Assert.IsNull(resultMovie);
        }


        [Test]
        public async Task SearchByTitleFragmentAsync_WhenTitleFragmentExists_ShouldReturnMatchingMovies()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie2",
                Director = "Test Director2",
                YearReleased = 2021,
                Genre = "Love",
                Duration = 88,
                Rating = 7.5
            };
            await _controller.AddAsync(movie);

            var movie2 = new Movie
            {
                Title = "Test Movie3",
                Director = "Test Director3",
                YearReleased = 2020,
                Genre = "Action",
                Duration = 88,
                Rating = 7.5
            };
            await _controller.AddAsync(movie2);
            //await _dbContext.Movies.InsertManyAsync(new[] { movie, movie2 });

            // Act
            var result = await _controller.SearchByTitleAsync("Test");

            // Assert 
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(2));

            var resultMovie = result.First();
            Assert.AreEqual(movie.Title, resultMovie.Title);
            Assert.AreEqual(movie.YearReleased, resultMovie.YearReleased);

        }

        [Test]
        public async Task SearchByTitleFragmentAsync_WhenNoMatchingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert           
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => _controller.SearchByTitleAsync("hey"));
            Assert.That(exception.Message, Is.EqualTo("No movies found."));

        }

        [Test]
        public async Task UpdateAsync_WhenValidMovieProvided_ShouldUpdateMovie()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie2",
                Director = "Test Director2",
                YearReleased = 2021,
                Genre = "Love",
                Duration = 88,
                Rating = 7.5
            };
            await _controller.AddAsync(movie);

            // Modify the movie
            movie.Title = "haha";
            movie.Rating = 10;

            // Act
            await _controller.UpdateAsync(movie);

            // Assert
            var result = await _dbContext.Movies.Find(x => x.Title == movie.Title).FirstOrDefaultAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(movie.Title, result.Title);
            Assert.AreEqual(movie.Rating, result.Rating);
        }

        [Test]
        public async Task UpdateAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            // Movie without required fields
            var invalidMovie = new Movie
            {
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };            

            // Act and Assert
            var exception = Assert.ThrowsAsync<ValidationException>(() => _controller.UpdateAsync(invalidMovie));
            Assert.That(exception.Message, Is.EqualTo("Movie is not valid."));                

        }


        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _dbContext.ClearDatabaseAsync();
        }
    }
}
