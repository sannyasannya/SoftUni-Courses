using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibroConsoleAPI.IntegrationTests
{
    public class IntegrationTests : IClassFixture<BookManagerFixture>, IAsyncLifetime
    {
        private readonly IBookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public IntegrationTests(BookManagerFixture fixture)
        {
            _bookManager = fixture.BookManager;
            _dbContext = fixture.DbContext;
        }

        // Implement IAsyncLifetime interface
        public async Task InitializeAsync()
        {
            // additional setup code before each test (if needed)
        }

        public async Task DisposeAsync()
        {
            // Clean up resources after each test
            if (_dbContext != null)
            {
                // Delete all records from the database
                _dbContext.Books.RemoveRange(_dbContext.Books);
                await _dbContext.SaveChangesAsync();
            }
        }


        [Fact]
        public async Task AddBookAsync_ShouldAddBook()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act
            await _bookManager.AddAsync(newBook);

            // Assert
            var bookInDb = await _dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == newBook.ISBN);
            Assert.NotNull(bookInDb);
            Assert.Equal("Test Book", bookInDb.Title);
            Assert.Equal("John Doe", bookInDb.Author);
            //Assert.Equal(newBook.Title, bookInDb.Title);
            //Assert.Equal(newBook.Author, bookInDb.Author);            
            
        }

        [Fact]
        public async Task AddBookAsync_WhenPassInvalidTitle_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = new string('A', 500),
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));

            // Assert
            Assert.Equal("Book is invalid.", exception.Result.Message);
        }

        [Fact]
        public async Task AddBookAsync_TryToAddBookWithInvalidISBN_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Some interesting book",
                Author = "John Doe",
                ISBN = "abcde",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(() => _bookManager.AddAsync(newBook));

            // Assert
            Assert.Equal("Book is invalid.", exception.Result.Message);
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == newBook.ISBN);
            Assert.Null(book);
        }

        [Fact]
        public async Task DeleteBookAsync_ShouldRemoveBook()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "The Catcher in the Rye",
                Author = "J.D. Salinger",
                ISBN = "9780330258644",
                YearPublished = 1951,
                Genre = "Novel",
                Pages = 277,
                Price = 8.99
            };
            await _bookManager.AddAsync(newBook);


            // Act
            await _bookManager.DeleteAsync("9780330258644");
            //await _bookManager.DeleteAsync(newBook.ISBN);

            // Assert
            var bookInDb = _dbContext.Books.FirstOrDefault(b => b.ISBN == newBook.ISBN);
            Assert.Null(bookInDb);
        }



        [Fact]
        public async Task DeleteBookAsync_WithValidISBN_ShouldRemoveBookFromDb()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Hello",
                Author = "J.D. Salin",
                ISBN = "9780330258645",
                YearPublished = 1941,
                Genre = "Novel",
                Pages = 280,
                Price = 18.99
            };
            await _bookManager.AddAsync(newBook);


            // Act
            await _bookManager.DeleteAsync("9780330258645");

            // Assert
            var bookInDb = await _dbContext.Books.FindAsync(newBook.Id);
            Assert.Null(bookInDb);
        }
        [Fact]
        public async Task DeleteBookAsync_TryToDeleteWithNullOrWhiteSpaceISBN_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Hello Kamen",
                Author = "J.D. Salina",
                ISBN = "9780330258645",
                YearPublished = 1941,
                Genre = "Novel",
                Pages = 280,
                Price = 18.99
            };
            await _bookManager.AddAsync(newBook);

            // Act
            var error = Assert.ThrowsAsync<ArgumentException>(() => _bookManager.DeleteAsync(null));
            var error2 = Assert.ThrowsAsync<ArgumentException>(() => _bookManager.DeleteAsync(" "));
            var error3 = Assert.ThrowsAsync<ArgumentException>(() => _bookManager.DeleteAsync(string.Empty));

            // Assert
            Assert.Equal("ISBN cannot be empty.", error.Result.Message);
            Assert.Equal("ISBN cannot be empty.", error2.Result.Message);
            Assert.Equal("ISBN cannot be empty.", error3.Result.Message);

        }

        [Fact]
        public async Task GetAllAsync_WhenBooksExist_ShouldReturnAllBooks()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, (Business.BookManager)_bookManager);

            // Act
            var result = await _bookManager.GetAllAsync();

            // Assert
            Assert.Equal(10, result.Count());
        }

        [Fact]
        public async Task GetAllAsync_WhenNoBooksExist_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            //var books = await _bookManager.GetAllAsync(); 

            // Act
            var error = await Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.GetAllAsync());

            // Assert
            Assert.Equal("No books found.", error.Message);
        }

        [Fact]
        public async Task SearchByTitleAsync_WithValidTitleFragment_ShouldReturnMatchingBooks()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, (Business.BookManager)_bookManager);

            // Act
            var result = await _bookManager.SearchByTitleAsync("War and Peace");

            // Assert
            Assert.Equal("War and Peace", result.FirstOrDefault().Title);

        }

        [Fact]
        public async Task SearchByTitleAsync_WithInvalidTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, (Business.BookManager)_bookManager);

            // Act
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.SearchByTitleAsync("Sanya"));

            // Assert
            Assert.Equal("No books found with the given title fragment.", exception.Message);
           
        }

        [Fact]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnBook()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, (Business.BookManager)_bookManager);

            // Act
            var result = await _bookManager.GetSpecificAsync("9780385487256");

            // Assert
            Assert.Equal("9780385487256", result.ISBN);
            //Assert.Equal("To Kill a Mockingbird", result.Title);
        }

        [Fact]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnBook2()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };
            await _bookManager.AddAsync(newBook); 

            // Act
            var result = await _bookManager.GetSpecificAsync(newBook.ISBN);

            // Assert
            Assert.Equal("1234567890123", result.ISBN);
            Assert.Equal("Test Book", result.Title);
        }

        [Fact]
        public async Task GetSpecificAsync_WithInvalidIsbn_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book 2",
                Author = "John Doe Dan",
                ISBN = "1234567890555",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };
            await _bookManager.AddAsync(newBook);

            // Act
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _bookManager.GetSpecificAsync("hahaha"));

            // Assert
            Assert.Equal($"No book found with ISBN: hahaha", exception.Message);
        }

        [Fact]
        public async Task UpdateAsync_WithValidBook_ShouldUpdateBook()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };
            await _bookManager.AddAsync(newBook);
            newBook.Title = "New Title";

            // Act
            await _bookManager.UpdateAsync(newBook);

            // Assert
            Assert.Equal("New Title", newBook.Title);
        }

        [Fact]
        public async Task UpdateAsync_WithInvalidBook_ShouldThrowValidationException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = 100,
                Price = 19.99
            };
            await _bookManager.AddAsync(newBook);
            newBook.Title = null;

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(() => _bookManager.UpdateAsync(newBook));

            // Assert
            Assert.Equal("Book is invalid.", exception.Result.Message);
        }

        

    }
}
