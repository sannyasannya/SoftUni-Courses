using MongoDB.Driver;
using MoviesLibraryAPI.Controllers;
using MoviesLibraryAPI.Controllers.Contracts;
using MoviesLibraryAPI.Data.Models;
using MoviesLibraryAPI.Services;
using MoviesLibraryAPI.Services.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibraryAPI.XUnitTests
{
    public class XUnitIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly MoviesLibraryXUnitTestDbContext _dbContext;
        private readonly IMoviesLibraryController _controller;
        private readonly IMoviesRepository _repository;

        public XUnitIntegrationTests(DatabaseFixture fixture)
        {
            _dbContext = fixture.DbContext;
            _repository = new MoviesRepository(_dbContext.Movies);
            _controller = new MoviesLibraryController(_repository);

            InitializeDatabaseAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeDatabaseAsync()
        {
            await _dbContext.ClearDatabaseAsync();
        }

        [Fact]
        public async Task AddMovieAsync_WhenValidMovieProvided_ShouldAddToDatabase()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            // Act
            await _controller.AddAsync(movie);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == "Test Movie").FirstOrDefaultAsync();
            Xunit.Assert.NotNull(resultMovie);
            Xunit.Assert.Equal("Test Movie", resultMovie.Title);
            Xunit.Assert.Equal("Test Director", resultMovie.Director);
            Xunit.Assert.Equal(2022, resultMovie.YearReleased);
            Xunit.Assert.Equal("Action", resultMovie.Genre);
            Xunit.Assert.Equal(120, resultMovie.Duration);
            Xunit.Assert.Equal(7.5, resultMovie.Rating);
        }

        [Fact]
        public async Task AddMovieAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var invalidMovie = new Movie
            {
                // Provide an invalid movie object, e.g., without a title or other required fields
                Genre = "Action",
                Duration = 12,
                Rating = 5
            };

            // Act and Assert
            var exception = await Xunit.Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
            Xunit.Assert.Equal("Movie is not valid.", exception.Message);
        }

        [Fact]
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
            Xunit.Assert.Null(result);
        }


        [Fact]
        public async Task DeleteAsync_WhenTitleIsNull_ShouldThrowArgumentException()
        {
            // Act and Assert
            var result = await Xunit.Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(null));
            Xunit.Assert.Equal("Title cannot be empty.", result.Message);
        }

        [Fact]
        public async Task DeleteAsync_WhenTitleIsEmpty_ShouldThrowArgumentException()
        {
            // Act and Assert
            var result = await Xunit.Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(string.Empty));
            Xunit.Assert.Equal("Title cannot be empty.", result.Message);
        }

        [Fact]
        public async Task DeleteAsync_WhenTitleDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Act and Assert
            var result = await Xunit.Assert.ThrowsAsync<InvalidOperationException>(() => _controller.DeleteAsync("bbb"));
            Xunit.Assert.Equal($"Movie with title 'bbb' not found.", result.Message);
        }

        [Fact]
        public async Task GetAllAsync_WhenNoMoviesExist_ShouldReturnEmptyList()
        {
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Xunit.Assert.Empty(result);
        }

        [Fact]
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
            //await _dbContext.Movies.InsertManyAsync(new[] { movie, movie2 });

            // Act
            var result = _controller.GetAllAsync();

            // Assert
            // Ensure that all movies are returned
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(2, result.Result.Count());
        }

        [Fact]
        public async Task GetByTitle_WhenTitleExists_ShouldReturnMatchingMovie()
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
            var result = await _controller.GetByTitle(movie.Title);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(result.Title, movie.Title);
            Xunit.Assert.Equal(result.Director, movie.Director);
            Xunit.Assert.Equal(result.YearReleased, movie.YearReleased);
            Xunit.Assert.Equal(result.Genre, movie.Genre);
            Xunit.Assert.Equal(result.Duration, movie.Duration);
            Xunit.Assert.Equal(result.Rating, movie.Rating);
        }

        [Fact]
        public async Task GetByTitle_WhenTitleDoesNotExist_ShouldReturnNull()
        {
            // Act
            var resultMovie = await _controller.GetByTitle("Bye");

            // Assert
            Xunit.Assert.Null(resultMovie);
        }


        [Fact]
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

            // Assert // Should return one matching movie
            Assert.NotNull(result);
            Xunit.Assert.Equal(2, result.Count());

            var resultMovie = result.First();
            Xunit.Assert.Equal(movie.Title, resultMovie.Title);
            Xunit.Assert.Equal(movie.YearReleased, resultMovie.YearReleased);
        }

        [Fact]
        public async Task SearchByTitleFragmentAsync_WhenNoMatchingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => _controller.SearchByTitleAsync("hey"));
            Xunit.Assert.Equal("No movies found.", exception.Result.Message);

        }

        [Fact]
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
            movie.Title = "Hello";
            movie.Rating = 9;

            // Act
            await _controller.UpdateAsync(movie);

            // Assert
            var result = await _dbContext.Movies.Find(x => x.Title == movie.Title).FirstOrDefaultAsync();
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(movie.Title, result.Title);
            Xunit.Assert.Equal(movie.Rating, result.Rating);
        }

        [Fact]
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
            Xunit.Assert.Equal("Movie is not valid.", exception.Result.Message);
        }
    }
}
