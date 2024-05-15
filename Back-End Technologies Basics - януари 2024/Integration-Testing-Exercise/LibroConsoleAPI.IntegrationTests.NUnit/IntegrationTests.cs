using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.Data.Models;
using LibroConsoleAPI.DataAccess;
using LibroConsoleAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.NUnit
{
    public  class IntegrationTests
    {
        private TestLibroDbContext dbContext;
        private IBookManager bookManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestLibroDbContext();
            this.bookManager = new BookManager(new BookRepository(this.dbContext));
        }

        [TearDown]
        public void TearDown()
        {
            this.dbContext.Dispose();
        }

        [Test]
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
            await bookManager.AddAsync(newBook);

            // Assert
            var bookInDb = await dbContext.Books.FirstOrDefaultAsync(b => b.ISBN == newBook.ISBN);
            Assert.NotNull(bookInDb);
            Assert.That(bookInDb.Title, Is.EqualTo("Test Book"));
            Assert.That(bookInDb.Author, Is.EqualTo("John Doe"));
        }

        [Test]
        public async Task AddBookAsync_WhenPassInvalidPages_ShouldThrowException()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Test Book",
                Author = "John Doe",
                ISBN = "1234567890123",
                YearPublished = 2021,
                Genre = "Fiction",
                Pages = -100,
                Price = 19.99
            };

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(() => bookManager.AddAsync(newBook));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Book is invalid."));
        }
        [Test]
        public async Task AddBookAsync_TryToAddBookWithInvalidCredentials_ShouldThrowException()
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
            var exception = Assert.ThrowsAsync<ValidationException>(() => bookManager.AddAsync(newBook));


            // Assert
            Assert.That(exception.Message, Is.EqualTo("Book is invalid."));

        }

        [Test]
        public async Task DeleteBookAsync_WithValidISBN_ShouldRemoveBookFromDb()
        {
            // Arrange
            var newBook = new Book
            {
                Title = "Hello, World",
                Author = "John Dan",
                ISBN = "1234567891234",
                YearPublished = 2020,
                Genre = "Love",
                Pages = 250,
                Price = 19.99
            };

            await bookManager.AddAsync(newBook);

            // Act
            await bookManager.DeleteAsync("1234567891234");

            // Assert
            var bookInDb = await dbContext.Books.FindAsync(newBook.Id);
            Assert.IsNull(bookInDb);
            Assert.That(bookInDb, Is.Null);

        }

        [Test]
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
            await bookManager.AddAsync(newBook);

            // Act
            var error = Assert.ThrowsAsync<ArgumentException>(() => bookManager.DeleteAsync(null));
            var error2 = Assert.ThrowsAsync<ArgumentException>(() => bookManager.DeleteAsync(" "));
            var error3 = Assert.ThrowsAsync<ArgumentException>(() => bookManager.DeleteAsync(string.Empty));

            // Assert
            Assert.That(error.Message, Is.EqualTo("ISBN cannot be empty."));
            Assert.That(error2.Message, Is.EqualTo("ISBN cannot be empty."));
            Assert.That(error3.Message, Is.EqualTo("ISBN cannot be empty."));

        }

        [Test]
        public async Task GetAllAsync_WhenBooksExist_ShouldReturnAllBooks()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, (Business.BookManager)bookManager);

            // Act
            var result = await bookManager.GetAllAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetAllAsync_WhenNoBooksExist_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act
            var error = Assert.ThrowsAsync<KeyNotFoundException>(() => bookManager.GetAllAsync());

            // Assert
            //Assert.AreEqual("No books found.", error.Message);
            Assert.That("No books found.", Is.EqualTo(error.Message));
            
        }

        [Test]
        public async Task SearchByTitleAsync_WithValidTitleFragment_ShouldReturnMatchingBooks()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, (Business.BookManager)bookManager);

            // Act
            var result = await bookManager.SearchByTitleAsync("War and Peace");

            // Assert
            //Assert.AreEqual("War and Peace", result.FirstOrDefault().Title);
            Assert.That(result.FirstOrDefault().Title, Is.EqualTo("War and Peace"));
        }

        [Test]
        public async Task SearchByTitleAsync_WithInvalidTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            await DatabaseSeeder.SeedDatabaseAsync(dbContext, (Business.BookManager)bookManager);

            // Act
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => bookManager.SearchByTitleAsync("Sanya"));

            // Assert
           //Assert.AreEqual("No books found with the given title fragment.", exception.Message);
            Assert.That(exception.Message, Is.EqualTo("No books found with the given title fragment."));


        }

        [Test]
        public async Task GetSpecificAsync_WithValidIsbn_ShouldReturnBook()
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
            await bookManager.AddAsync(newBook);

            // Act
            var result = await bookManager.GetSpecificAsync(newBook.ISBN);


            // Assert
            Assert.That(result.ISBN, Is.EqualTo("1234567890123"));
            Assert.That(result.Title, Is.EqualTo("Test Book"));
        }

        [Test]
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
            await bookManager.AddAsync(newBook);

            // Act
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => bookManager.GetSpecificAsync("hahaha"));


            // Assert
            Assert.That(exception.Message, Is.EqualTo($"No book found with ISBN: hahaha"));
        }

        [Test]
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
            await bookManager.AddAsync(newBook);
            newBook.Title = "New Title";

            // Act
            var result = bookManager.UpdateAsync(newBook);

            // Assert
            Assert.That(newBook.Title, Is.EqualTo("New Title"));
        }

        [Test]
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
            await bookManager.AddAsync(newBook);
            newBook.Title = null;

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(() => bookManager.UpdateAsync(newBook));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Book is invalid."));
        }
    }
}
