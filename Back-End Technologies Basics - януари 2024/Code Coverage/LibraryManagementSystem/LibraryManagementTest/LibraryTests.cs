using LibraryManagementSystem;

namespace LibraryManagementTest
{
    [TestFixture]
    public class LibraryTests
    {
        [Test]
        public void AddBook_ShouldAddaNewBookAtTheLibrary()
        {
            // Arrange
            var library = new Library();

            var newBook = new Book()
            {
                Author = "Ivan",
                Id = 1,
                IsCheckedOut = false,
                Title = "Test",

            };

            // Act
            library.AddBook(newBook);

            // Assert
            //var bookInDb = library.GetAllBooks().FirstOrDefault(b => b.Id == newBook.Id);
            //Assert.IsNotNull(bookInDb);
            //Assert.That(library.GetAllBooks().Count(), Is.EqualTo(1));

            var allBooks = library.GetAllBooks();
            Assert.That(allBooks.Count, Is.EqualTo(1));

            var singleBook = allBooks.First();
            Assert.That(singleBook.Id, Is.EqualTo(newBook.Id));
            Assert.That(singleBook.Title, Is.EqualTo(newBook.Title));
            Assert.That(singleBook.Author, Is.EqualTo(newBook.Author));
            Assert.IsFalse(singleBook.IsCheckedOut);

        }

        [Test]
        public void CheckOutBook_ShouldReturnFalse_IfBookDoesNotExist() 
        {
            // Arrange
            var library = new Library();

            var newBook = new Book()
            {
                Author = "Jane Doe",
                Id = 1,
                IsCheckedOut = false,
                Title = "Title",
            };

            library.AddBook(newBook);


            // Act
            var result = library.CheckOutBook(999);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOutBook_ShouldReturnFalse_IfBookIsAlreadyCheck()
        {
            // Arrange
            var library = new Library();
            var newBook = new Book()
            {
                Author = "John Doe",
                Id = 1,
                IsCheckedOut = true,
                Title = "Test",
            };

            library.AddBook(newBook);

            // Act
            var result = library.CheckOutBook(newBook.Id);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckOutBook_ShouldReturnTrue_IfWeCanCheckOutTheBook()
        {
            // Arrange
            var library = new Library();
            var newBook = new Book()
            {
                Author = "John Doe",
                Id = 1,
                IsCheckedOut = false,
                Title = "Test",
            };

            library.AddBook(newBook);

            // Act
            var result = library.CheckOutBook(newBook.Id);

            // Assert
            Assert.IsTrue(result);
            var allBooks = library.GetAllBooks();
            var singleBook = allBooks.First();
            Assert.IsTrue(singleBook.IsCheckedOut);

        }

        [Test]
        public void ReturnBook_ShouldReturnFalse_IfBookDoesNotExist()
        {
            // Arrange
            var library = new Library();

            var newBook = new Book()
            {
                Author = "Jane Doe",
                Id = 1,
                IsCheckedOut = false,
                Title = "Title",
            };

            library.AddBook(newBook);


            // Act
            var result = library.ReturnBook(999);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Return_ShouldReturnFalse_IfBookIsNotCheckedOut()
        {
            // Arrange
            var library = new Library();

            var newBook = new Book()
            {
                Author = "Jane Doe",
                Id = 1,
                IsCheckedOut = false,
                Title = "Title",
            };

            library.AddBook(newBook);

            // Act
            var result = library.ReturnBook(1);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Return_ShouldReturnTrue_IfBookCanBeCheckedOut()
        {
            // Arrange
            var library = new Library();

            var newBook = new Book()
            {
                Author = "Jane Doe",
                Id = 1,
                IsCheckedOut = true,
                Title = "Title",
            };

            library.AddBook(newBook);

            // Act
            var result = library.ReturnBook(1);

            // Assert
            Assert.IsTrue(result);
            var allBooks = library.GetAllBooks();
            var singleBook = allBooks.First();
            Assert.IsFalse(singleBook.IsCheckedOut);
        }


    }
}
