using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using ZooConsoleAPI.Business;
using ZooConsoleAPI.Business.Contracts;
using ZooConsoleAPI.Data.Model;
using ZooConsoleAPI.DataAccess;

namespace ZooConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestAnimalDbContext dbContext;
        private IAnimalsManager animalsManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestAnimalDbContext();
            this.animalsManager = new AnimalsManager(new AnimalRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }


        //positive test
        [Test]
        public async Task AddAnimalAsync_ShouldAddNewAnimal()
        {
            // Arrange
            var newAnimal = new Animal()
            {                
                CatalogNumber = "123ABC456DEF",
                Name = "Fluffy",
                Breed = "Persian",
                Type = "Cat",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            // Act
            await animalsManager.AddAsync(newAnimal);

            // Assert
            var animalInDb = await dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == newAnimal.CatalogNumber);

            Assert.NotNull(animalInDb);
            
            Assert.That(animalInDb.CatalogNumber, Is.EqualTo(newAnimal.CatalogNumber));
            Assert.That(animalInDb.Name, Is.EqualTo(newAnimal.Name));
            Assert.That(animalInDb.Breed, Is.EqualTo(newAnimal.Breed));
            Assert.That(animalInDb.Type, Is.EqualTo(newAnimal.Type));
            Assert.That(animalInDb.Age, Is.EqualTo(newAnimal.Age));
            Assert.That(animalInDb.Gender, Is.EqualTo(newAnimal.Gender));
            Assert.That(animalInDb.IsHealthy, Is.EqualTo(newAnimal.IsHealthy));
        }

        //Negative test
        [Test]
        public async Task AddAnimalAsync_TryToAddAnimalWithInvalidCredentials_ShouldThrowException()
        {
            // Arrange
            var newAnimal = new Animal()
            {                
                CatalogNumber = "",
                Name = "Fluffy",
                Breed = "Persian",
                Type = "Cat",
                Age = -2,
                Gender = "Female",
                IsHealthy = true
            };

            // Act & Assert
            var exception = Assert.ThrowsAsync<ValidationException>(async () => await animalsManager.AddAsync(newAnimal));
            var actual = await dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == newAnimal.CatalogNumber);

            Assert.IsNull(actual);
            Assert.That(exception?.Message, Is.EqualTo("Invalid animal!"));

        }

        [Test]
        public async Task DeleteAnimalAsync_WithValidCatalogNumber_ShouldRemoveAnimalFromDb()
        {
            // Arrange
            var newAnimal = new Animal()
            {                
                CatalogNumber = "123ABC456DEF",
                Name = "Fluffy",
                Breed = "Persian",
                Type = "Cat",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            await animalsManager.AddAsync(newAnimal);

            // Act
            await animalsManager.DeleteAsync(newAnimal.CatalogNumber);

            // Assert
            var animalInDb = await dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == newAnimal.CatalogNumber);
            Assert.IsNull(animalInDb);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public async Task DeleteAnimalAsync_TryToDeleteWithNullOrWhiteSpaceCatalogNumber_ShouldThrowException(string invalidCatalogNumber)
        { 
            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(() => animalsManager.DeleteAsync(invalidCatalogNumber));

            Assert.That(exception.Message, Is.EqualTo("Catalog number cannot be empty."));
        }

        [Test]
        public async Task GetAllAsync_WhenAnimalsExist_ShouldReturnAllAnimals()
        {
            // Arrange
            var firstAnimal = new Animal()
            {                
                CatalogNumber = "123ABC456DEF",
                Name = "Fluffy",
                Breed = "Persian",
                Type = "Cat",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            var secondAnimal = new Animal()
            {               
                CatalogNumber = "124ADC456DEF",
                Name = "Johny",
                Breed = "Pomeran",
                Type = "Dog",
                Age = 1,
                Gender = "Male",
                IsHealthy = true
            };

            await animalsManager.AddAsync(firstAnimal);
            await animalsManager.AddAsync(secondAnimal);

            // Act
            var result = await animalsManager.GetAllAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));

            var firstAn = result.FirstOrDefault(x => x.CatalogNumber == firstAnimal.CatalogNumber);

            Assert.IsNotNull(firstAn);
            
            Assert.That(firstAn.CatalogNumber, Is.EqualTo(firstAnimal.CatalogNumber));
            Assert.That(firstAn.Name, Is.EqualTo(firstAnimal.Name));
            Assert.That(firstAn.Breed, Is.EqualTo(firstAnimal.Breed));
            Assert.That(firstAn.Type, Is.EqualTo(firstAnimal.Type));
            Assert.That(firstAn.Age, Is.EqualTo(firstAnimal.Age));
            Assert.That(firstAn.Gender, Is.EqualTo(firstAnimal.Gender));
            Assert.That(firstAn.IsHealthy, Is.EqualTo(firstAnimal.IsHealthy));

            var secondAn = result.FirstOrDefault(x => x.CatalogNumber == secondAnimal.CatalogNumber);

            Assert.IsNotNull(secondAn);
            
            Assert.That(secondAn.CatalogNumber, Is.EqualTo(secondAnimal.CatalogNumber));
            Assert.That(secondAn.Name, Is.EqualTo(secondAnimal.Name));
            Assert.That(secondAn.Breed, Is.EqualTo(secondAnimal.Breed));
            Assert.That(secondAn.Type, Is.EqualTo(secondAnimal.Type));
            Assert.That(secondAn.Age, Is.EqualTo(secondAnimal.Age));
            Assert.That(secondAn.Gender, Is.EqualTo(secondAnimal.Gender));
            Assert.That(secondAn.IsHealthy, Is.EqualTo(secondAnimal.IsHealthy));
        }

        [Test]
        public async Task GetAllAsync_WhenNoAnimalsExist_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert

            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => animalsManager.GetAllAsync());

            Assert.That(exception.Message, Is.EqualTo("No animal found."));

        }

        [Test]
        public async Task SearchByTypeAsync_WithExistingType_ShouldReturnMatchingAnimals()
        {
            // Arrange
            var firstAnimal = new Animal()
            {
                CatalogNumber = "123ABC456DEF",
                Name = "Fluffy",
                Breed = "Persian",
                Type = "Cat",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            var secondAnimal = new Animal()
            {
                CatalogNumber = "124ADC456DEF",
                Name = "Johny",
                Breed = "Pomeran",
                Type = "Dog",
                Age = 1,
                Gender = "Male",
                IsHealthy = true
            };

            await animalsManager.AddAsync(firstAnimal);
            await animalsManager.AddAsync(secondAnimal);

            // Act
            var result = await animalsManager.SearchByTypeAsync(secondAnimal.Type);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(1));
            var resultAnimal = result.First();
            Assert.That(resultAnimal.CatalogNumber, Is.EqualTo(secondAnimal.CatalogNumber));
            Assert.That(resultAnimal.Name, Is.EqualTo(secondAnimal.Name));
            Assert.That(resultAnimal.Breed, Is.EqualTo(secondAnimal.Breed));
            Assert.That(resultAnimal.Type, Is.EqualTo(secondAnimal.Type));
            Assert.That(resultAnimal.Age, Is.EqualTo(secondAnimal.Age));
            Assert.That(resultAnimal.Gender, Is.EqualTo(secondAnimal.Gender));
            Assert.That(resultAnimal.IsHealthy, Is.EqualTo(secondAnimal.IsHealthy));
        }

        [Test]
        public async Task SearchByTypeAsync_WithNonExistingType_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => animalsManager.SearchByTypeAsync("NON_EXISTING_TYPE"));
            Assert.That(exception.Message, Is.EqualTo("No animal found with the given type."));

        }

        [Test]
        public async Task GetSpecificAsync_WithValidCatalogNumber_ShouldReturnAnimal()
        {
            // Arrange
            var firstAnimal = new Animal()
            {
                CatalogNumber = "123ABC456DEF",
                Name = "Fluffy",
                Breed = "Persian",
                Type = "Cat",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            var secondAnimal = new Animal()
            {
                CatalogNumber = "124ADC456DEF",
                Name = "Johny",
                Breed = "Pomeran",
                Type = "Dog",
                Age = 1,
                Gender = "Male",
                IsHealthy = true
            };

            await animalsManager.AddAsync(firstAnimal);
            await animalsManager.AddAsync(secondAnimal);

            // Act
            var result = await animalsManager.GetSpecificAsync(firstAnimal.CatalogNumber);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.CatalogNumber, Is.EqualTo(firstAnimal.CatalogNumber));
            Assert.That(result.Name, Is.EqualTo(firstAnimal.Name));
            Assert.That(result.Breed, Is.EqualTo(firstAnimal.Breed));
            Assert.That(result.Type, Is.EqualTo(firstAnimal.Type));
            Assert.That(result.Age, Is.EqualTo(firstAnimal.Age));
            Assert.That(result.Gender, Is.EqualTo(firstAnimal.Gender));
            Assert.That(result.IsHealthy, Is.EqualTo(firstAnimal.IsHealthy));
        }

        [Test]
        public async Task GetSpecificAsync_WithInvalidCatalogNumber_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            const string invalidCatalogNumber = "NON_VALID_CATALOG_NUMBER";

            // Act & Assert
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => animalsManager.GetSpecificAsync(invalidCatalogNumber));

            Assert.That(exception.Message, Is.EqualTo($"No animal found with catalog number: {invalidCatalogNumber}"));
            
        }

        [Test]
        public async Task UpdateAsync_WithValidAnimal_ShouldUpdateAnimal()
        {
            // Arrange
            var firstAnimal = new Animal()
            {
                CatalogNumber = "123ABC456DEF",
                Name = "Fluffy",
                Breed = "Persian",
                Type = "Cat",
                Age = 2,
                Gender = "Female",
                IsHealthy = true
            };

            var secondAnimal = new Animal()
            {
                CatalogNumber = "124ADC456DEF",
                Name = "Johny",
                Breed = "Pomeran",
                Type = "Dog",
                Age = 1,
                Gender = "Male",
                IsHealthy = true
            };

            await animalsManager.AddAsync(firstAnimal);
            await animalsManager.AddAsync(secondAnimal);

            // Act
            firstAnimal.Name = "Jasmine";
            await animalsManager.UpdateAsync(firstAnimal);

            // Assert
            var animalInDb = await dbContext.Animals.FirstOrDefaultAsync(a => a.CatalogNumber == firstAnimal.CatalogNumber);
            Assert.IsNotNull(animalInDb);
            Assert.That(animalInDb.Name, Is.EqualTo(firstAnimal.Name));
            Assert.That(animalInDb.Breed, Is.EqualTo(firstAnimal.Breed));
            Assert.That(animalInDb.Type, Is.EqualTo(firstAnimal.Type));
            Assert.That(animalInDb.Age, Is.EqualTo(firstAnimal.Age));
            Assert.That(animalInDb.Gender, Is.EqualTo(firstAnimal.Gender));
            Assert.That(animalInDb.IsHealthy, Is.EqualTo(firstAnimal.IsHealthy));
            Assert.That(animalInDb.CatalogNumber, Is.EqualTo(firstAnimal.CatalogNumber));
        }

        [Test]
        public async Task UpdateAsync_WithInvalidAnimal_ShouldThrowValidationException()
        {
            // Arrange
            var invalidAnimal = new Animal()
            {
                CatalogNumber = "123ABC456DEF",
                Name = "Fluffy",
                Breed = "Persian",
                Type = "Cat",
                Age = -200,
                Gender = "Person",
                IsHealthy = true
            };

            // Act
            var exception = Assert.ThrowsAsync<ValidationException>(() => animalsManager.UpdateAsync(invalidAnimal));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Invalid animal!"));
        }
    }
}

