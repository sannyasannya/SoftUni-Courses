using Homies.Data;
using Homies.Data.Models;
using Homies.Models.Event;
using Homies.Services;
using Microsoft.EntityFrameworkCore;

namespace Homies.Tests
{
    [TestFixture]
    internal class EventServiceTests
    {
        private HomiesDbContext _dbContext;
        private EventService _eventService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<HomiesDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Use unique database name to avoid conflicts
                .Options;
            _dbContext = new HomiesDbContext(options);

            _eventService = new EventService(_dbContext);
        }

        [Test]
        public async Task AddEventAsync_ShouldAddEvent_WhenValidEventModelAndUserId()
        {
            // Step 1: Arrange - Set up the initial conditions for the test
            // Create a new event model with test data
            var eventModel = new EventFormModel
            {
                Name = "Test Event",
                Description = "Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2)
            };
            // Define a user ID for testing purposes
            string userId = "testUserId";

            // Step 2: Act - Perform the action being tested
            // Call the service method to add the event
            await _eventService.AddEventAsync(eventModel, userId);

            // Step 3: Assert - Verify the outcome of the action
            // Retrieve the added event from the database
            var eventInDatabase = await _dbContext.Events.FirstOrDefaultAsync(x => x.Name ==
            eventModel.Name && x.OrganiserId == userId);

            // Assert that the added event is not null, indicating it was successfully added
            Assert.IsNotNull(eventInDatabase);

            // Assert that the description of the added event matches the description provided in the event model
            Assert.That(eventInDatabase.Description, Is.EqualTo(eventModel.Description));
            Assert.That(eventInDatabase.Start, Is.EqualTo(eventModel.Start));
            Assert.That(eventInDatabase.End, Is.EqualTo(eventModel.End));
        }


        [Test]
        public async Task GetAllEventsAsync_ShouldReturnAllEvents()
        {
            // Step 1: Arrange - Set up the initial conditions for the test
            // Create two event models with test data
            var firstEventModel = new EventFormModel
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2)
            };

            var secondEventModel = new EventFormModel
            {
                Name = "Second Test Event",
                Description = "Second Test Description",
                Start = DateTime.Now.AddDays(2),
                End = DateTime.Now.AddDays(3)
            };

            // Define a user ID for testing purposes
            string userId = "testUserId";

            await _eventService.AddEventAsync(firstEventModel, userId);
            await _eventService.AddEventAsync(secondEventModel, userId);

            // Step 2: Act - Perform the action being tested
            // Add the two events to the database using the event service
            var result = await _eventService.GetAllEventsAsync();

            // Step 3: Act - Retrieve the count of events from the database


            // Step 4: Assert - Verify the outcome of the action
            // Assert that the count of events in the database is equal to the expected count (2)
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetEventDetailsAsync_ShouldReturnAllEventDetails()
        {
            // Arrange
            var firstEventModel = new EventFormModel
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = 2
            };

            await _eventService.AddEventAsync(firstEventModel, "nonExistingUser");

            // assume that it will add new lines in my DB
            var eventsInDb = await _dbContext.Events.FirstAsync();

            // Act
            var result = await _eventService.GetEventDetailsAsync(eventsInDb.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(firstEventModel.Name));
            Assert.That(result.Description, Is.EqualTo(firstEventModel.Description));

        }
        [Test]
        public async Task GetEventForEditAsync_ShouldGetEventIfPresentInTheDatabase()
        {
            // Arrange
            var firstEventModel = new EventFormModel
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = 2
            };
            await _eventService.AddEventAsync(firstEventModel, "nonExistingUser");

            var eventsInDb = await _dbContext.Events.FirstAsync();


            // Act
            var result = await _eventService.GetEventForEditAsync(eventsInDb.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(firstEventModel.Name));
        }

        [Test]
        public async Task GetEventForEditAsync_ShouldReturnNullIfPresentIsNotFound()
        {
            // Act
            var result = await _eventService.GetEventForEditAsync(90);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetEventOrganizerAsync_ShouldReturnOrganizerIdIfExisting()
        {
            // Arrange
            var firstEventModel = new EventFormModel
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = 2
            };

            const string userId = "userId";

            await _eventService.AddEventAsync(firstEventModel, userId);

            var eventsInDb = await _dbContext.Events.FirstAsync();

            // Act
            var result = await _eventService.GetEventOrganizerIdAsync(eventsInDb.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(userId));
        }

        [Test]
        public async Task GetEventOrganizerAsync_ShouldReturnNullIfEventIsNotExisting() 
        {  
            // Act
            var result = await _eventService.GetEventOrganizerIdAsync(99);

            // Assert
            Assert.IsNull(result);
            
        }

        [Test]
        public async Task GetUserJoinedEventsAsync_ShouldReturnAllJoinedUser()
        {
            // Arrange
            const string userId = "userId";

            var testType = new Data.Models.Type
            {
                Name = "TestType"
            };
            _dbContext.Types.Add(testType);
            await _dbContext.SaveChangesAsync();

            var testEvent = new Event
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = testType.Id,
                OrganiserId = userId,
            };
            await _dbContext.Events.AddAsync(testEvent);
            await _dbContext.SaveChangesAsync();

            var allEvents = _dbContext.Events.ToList();
            await _dbContext.EventsParticipants.AddAsync(new EventParticipant()
            {
                EventId = testEvent.Id,
                HelperId = userId
            });

            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _eventService.GetUserJoinedEventsAsync(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(1));

            var eventParticipation = result.First();

            Assert.That(eventParticipation.Id, Is.EqualTo(testEvent.Id));
            Assert.That(eventParticipation.Name, Is.EqualTo(testEvent.Name));
            Assert.That(eventParticipation.Type, Is.EqualTo(testEvent.Name));
        }

        [Test]
        public async Task JoinEventAsync_ShouldReturnFalseIfUserIsAlreadyPartOfTheEvent()
        {
            // Arrange
            const string userId = "userId";

            // Add an event type to Database
            var testType = new Data.Models.Type
            {
                Name = "TestType"
            };
            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Add an event to the Database
            var testEvent = new Event
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = testType.Id,
                OrganiserId = userId,
            };
            await _dbContext.Events.AddAsync(testEvent);
            await _dbContext.SaveChangesAsync();

            // Add user to the event.
            var allEvents = _dbContext.Events.ToList();
            await _dbContext.EventsParticipants.AddAsync(new EventParticipant()
            {
                EventId = testEvent.Id,
                HelperId = userId
            });

            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _eventService.JoinEventAsync(testEvent.Id, userId);

            // Assert
            Assert.False(result);

        }

        [Test]
        public async Task JoinEventAsync_ShouldReturnFalseIfEventDoesNotExist()
        {
            // Act
            var result = await _eventService.JoinEventAsync(99, "");

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task JoinEventAsync_ShouldReturnTrueIfUserIsAddedToTheEvent()
        {
            // Arrange

            const string userId = "userId";

            // Add an event type to Database
            var testType = new Data.Models.Type
            {
                Name = "TestType"
            };
            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Add an event to the Database
            var testEvent = new Event
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = testType.Id,
                OrganiserId = userId,
            };
            await _dbContext.Events.AddAsync(testEvent);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _eventService.JoinEventAsync(testEvent.Id, userId);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task LeaveEventAsync_ShouldReturnFalse_IfWeTryToLeaveAnEventWeAreNotPartOf()
        {
            // Arrange
            const string userId = "userId";

            // Act
            var result = await _eventService.LeaveEventAsync(123, userId);

            // Assert
            Assert.False(result);
        }


        [Test]
        public async Task LeaveEventAsync_ShouldReturnTrue_IfWeLeaveTheEvent()
        {
            // Arrange           

            // Add an event type to Database
            var testType = new Data.Models.Type
            {
                Name = "TestType"
            };
            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Add an event to the Database
            var testEvent = new Event
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = testType.Id,
                OrganiserId = "simple user",
            };
            await _dbContext.Events.AddAsync(testEvent);
            await _dbContext.SaveChangesAsync();

            string userId = "new participant";
            await _eventService.JoinEventAsync(testEvent.Id, userId);


            // Act
            var result = await _eventService.LeaveEventAsync(testEvent.Id, userId);

            // Assert
            Assert.True(result);
        }

        [Test]
        public async Task UpdateEventAsync_ShouldReturnFalse_IfEventDoesNotExist()
        {
            // Act
            var result = await _eventService.UpdateEventAsync(999, new EventFormModel { }, "userId");

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task UpdateEventAsync_ShouldReturnFalse_IfTheOrganizerOfTheEventIsDifferent()
        {
            // Arrange
            const string firstUser = "first user";
            const string secondUser = "second user";

            var testType = new Data.Models.Type
            {
                Name = "TestType"
            };
            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Add an event to the Database
            var testEvent = new Event
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = testType.Id,
                OrganiserId = firstUser,
            };
            await _dbContext.Events.AddAsync(testEvent);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _eventService.UpdateEventAsync(999, new EventFormModel { }, secondUser);

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task UpdateEventAsync_ShouldReturnTrue_IfWeUpdateTheEventSuccessfully()
        {
            // Arrange

            const string firstUser = "first user";
           
            var testType = new Data.Models.Type
            {
                Name = "TestType"
            };
            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Add an event to the Database
            var testEvent = new Event
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = testType.Id,
                OrganiserId = firstUser,
            };
            await _dbContext.Events.AddAsync(testEvent);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _eventService.UpdateEventAsync(testEvent.Id,
                new EventFormModel 
                { Name = "Updated Name!",
                  Description = testEvent.Description,
                  Start = testEvent.Start,
                  End = testEvent.End,
                  TypeId = testEvent.Id
                },
                firstUser);

            // Assert
            Assert.True(result);

            var eventFromTheDb = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == testEvent.Id);
            Assert.NotNull(eventFromTheDb);
            Assert.That(eventFromTheDb.Name, Is.EqualTo("Updated Name!"));
        }

        [Test]
        public async Task GetAllTypesAsync_ShouldReturnAllTypes()
        {
            // Arrange
            var testType = new Data.Models.Type
            {
                Name = "TestType"
            };
            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _eventService.GetAllTypesAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(1));
            var resultType = result.First();
            Assert.That(resultType.Name, Is.EqualTo(testType.Name));
        }

        [Test]
        public async Task IsUserJoinedEventAsync_ShouldReturnFalse_IfEventDoesNotExist()
        {
            // Act
            var result = await _eventService.IsUserJoinedEventAsync(99, "ala-bala");

            // Assert
            Assert.False(result);
        }

        [Test]
        public async Task IsUserJoinedEventAsync_ShouldReturnFalse_IfUserDoesNotExist()
        {
            // Arrange
            const string firstUser = "first user";

            var testType = new Data.Models.Type
            {
                Name = "TestType"
            };
            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Add an event to the Database
            var testEvent = new Event
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = testType.Id,
                OrganiserId = "sample-user",
            };
            await _dbContext.Events.AddAsync(testEvent);
            await _dbContext.SaveChangesAsync();


            // Act
            var result = await _eventService.IsUserJoinedEventAsync(testEvent.Id, "haha");


            // Assert
            Assert.False(result);

        }

        [Test]
        public async Task IsUserJoinedEventAsync_ShouldReturnTrue_IfUserIsInTheEvent()
        {
            // Arrange
            const string firstUser = "first user";

            var testType = new Data.Models.Type
            {
                Name = "TestType"
            };
            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            // Add an event to the Database
            var testEvent = new Event
            {
                Name = "First Test Event",
                Description = "First Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = testType.Id,
                OrganiserId = "sample-user",
            };
            await _dbContext.Events.AddAsync(testEvent);
            await _dbContext.SaveChangesAsync();

            await _eventService.JoinEventAsync(testEvent.Id, "joined-id");


            // Act
            var result = await _eventService.IsUserJoinedEventAsync(testEvent.Id, "joined-id");


            // Assert
            Assert.True(result);
        }

    }

}













    





