using ContactsConsoleAPI.Business;
using ContactsConsoleAPI.Business.Contracts;
using ContactsConsoleAPI.Data.Models;
using ContactsConsoleAPI.DataAccess;
using ContactsConsoleAPI.DataAccess.Contrackts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestContactDbContext dbContext;
        private IContactManager contactManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestContactDbContext();
            this.contactManager = new ContactManager(new ContactRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }


        //positive test
        [Test]
        public async Task AddContactAsync_ShouldAddNewContact()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            // Act
            await contactManager.AddAsync(newContact);

            // Assert
            var dbContact = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            Assert.NotNull(dbContact);
            Assert.AreEqual(newContact.FirstName, dbContact.FirstName);
            Assert.AreEqual(newContact.LastName, dbContact.LastName);
            Assert.AreEqual(newContact.Phone, dbContact.Phone);
            Assert.AreEqual(newContact.Email, dbContact.Email);
            Assert.AreEqual(newContact.Address, dbContact.Address);
            Assert.AreEqual(newContact.Contact_ULID, dbContact.Contact_ULID);
        }

        //Negative test
        [Test]
        public async Task AddContactAsync_TryToAddContactWithInvalidCredentials_ShouldThrowException()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "invalid_Mail", //invalid email
                Gender = "Male",
                Phone = "0889933779"
            };

            // Act & Assert
            var exception = Assert.ThrowsAsync<ValidationException>(async () => await contactManager.AddAsync(newContact));
            var actual = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            Assert.IsNull(actual);
            // exception? check for null
            Assert.That(exception?.Message, Is.EqualTo("Invalid contact!"));

        }

        [Test]
        public async Task DeleteContactAsync_WithValidULID_ShouldRemoveContactFromDb()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", 
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            // Act
            await contactManager.DeleteAsync(newContact.Contact_ULID);

            // Assert
            var contactInDb = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Contact_ULID == newContact.Contact_ULID);
            Assert.IsNull(contactInDb);
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        public async Task DeleteContactAsync_TryToDeleteWithNullOrWhiteSpaceULID_ShouldThrowException(string invalidUlid)
        {
            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(() => contactManager.DeleteAsync(invalidUlid));

            Assert.That(exception.Message, Is.EqualTo("ULID cannot be empty."));
            
        }

        [Test]
        public async Task GetAllAsync_WhenContactsExist_ShouldReturnAllContacts()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH",
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            var secondContact = new Contact()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Address = "Anything for testing address",
                Contact_ULID = "1ABCB3456HH",
                Email = "peter@gmail.com",
                Gender = "Male",
                Phone = "0889934779"
            };

            await contactManager.AddAsync(newContact);
            await contactManager.AddAsync(secondContact);

            // Act
            var result = await contactManager.GetAllAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));

            var firstContact = result.First();
            Assert.That(firstContact.Email, Is.EqualTo(newContact.Email));
            //Assert with other props
        }

        [Test]
        public async Task GetAllAsync_WhenNoContactsExist_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.GetAllAsync());
            Assert.That(exception.Message, Is.EqualTo("No contact found."));
        }

        [Test]
        public async Task SearchByFirstNameAsync_WithExistingFirstName_ShouldReturnMatchingContacts()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH",
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            var secondContact = new Contact()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Address = "Anything for testing address",
                Contact_ULID = "1ABCB3456HH",
                Email = "peter@gmail.com",
                Gender = "Male",
                Phone = "0889934779"
            };

            await contactManager.AddAsync(newContact);
            await contactManager.AddAsync(secondContact);


            // Act
            var result = await contactManager.SearchByFirstNameAsync(secondContact.FirstName);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(1));
            var itemInDb = result.First();
            Assert.That(itemInDb.LastName, Is.EqualTo(secondContact.LastName));
            // TODO: Assert.That with other props of secondContact
        }

        [Test]
        public async Task SearchByFirstNameAsync_WithNonExistingFirstName_ShouldThrowKeyNotFoundException()
        {
            // Arrange

            // Act & Assert

            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.SearchByFirstNameAsync("NO_SUCH_KEY"));

            Assert.That(exception.Message, Is.EqualTo("No contact found with the given first name."));
        }

        [Test]
        public async Task SearchByLastNameAsync_WithExistingLastName_ShouldReturnMatchingContacts()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH",
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            var secondContact = new Contact()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Address = "Anything for testing address",
                Contact_ULID = "1ABCB3456HH",
                Email = "peter@gmail.com",
                Gender = "Male",
                Phone = "0889934779"
            };

            await contactManager.AddAsync(newContact);
            await contactManager.AddAsync(secondContact);

            // Act 
            var result = await contactManager.SearchByLastNameAsync(newContact.LastName);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(1));
            var itemInDb = result.First();
            Assert.That(itemInDb.FirstName, Is.EqualTo(newContact.FirstName));
            // Assert with other props
        }

        [Test]
        public async Task SearchByLastNameAsync_WithNonExistingLastName_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert

            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.SearchByLastNameAsync("NON_EXISTING_NAME"));

            Assert.That(exception.Message, Is.EqualTo("No contact found with the given last name."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidULID_ShouldReturnContact()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH",
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            var secondContact = new Contact()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Address = "Anything for testing address",
                Contact_ULID = "1ABCB3456HH",
                Email = "peter@gmail.com",
                Gender = "Male",
                Phone = "0889934779"
            };

            await contactManager.AddAsync(newContact);
            await contactManager.AddAsync(secondContact);

            // Act
            var result = await contactManager.GetSpecificAsync(newContact.Contact_ULID);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.FirstName, Is.EqualTo(newContact.FirstName));
            // TODO: Assert with all other props
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidULID_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            const string invalidUlid = "NON_VALID_ULID";

            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.GetSpecificAsync(invalidUlid));
            Assert.That(exception.Message, Is.EqualTo($"No contact found with ULID: {invalidUlid}"));

            
        }

        [Test]
        public async Task UpdateAsync_WithValidContact_ShouldUpdateContact()
        {
            // Arrange
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH",
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            var secondContact = new Contact()
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Address = "Anything for testing address",
                Contact_ULID = "1ABCB3456HH",
                Email = "peter@gmail.com",
                Gender = "Male",
                Phone = "0889934779"
            };

            await contactManager.AddAsync(newContact);
            await contactManager.AddAsync(secondContact);

            newContact.FirstName = "Sofia";

            // Act
            await contactManager.UpdateAsync(newContact);

            // Assert
            var itemInDb = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Contact_ULID == newContact.Contact_ULID);
            Assert.NotNull(itemInDb);
            Assert.That(itemInDb.FirstName, Is.EqualTo(newContact.FirstName));
            // TODO: Add asserts for other props
        }

        [Test]
        public async Task UpdateAsync_WithInvalidContact_ShouldThrowValidationException()
        {
            // Act & Assert
            var exception = Assert.ThrowsAsync<ValidationException>(() => contactManager.UpdateAsync(new Contact()));

            Assert.That(exception.Message, Is.EqualTo("Invalid contact!"));
        }
    }
}
