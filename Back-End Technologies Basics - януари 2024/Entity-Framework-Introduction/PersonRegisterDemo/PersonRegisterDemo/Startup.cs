using Microsoft.EntityFrameworkCore;
using PersonRegisterDemo.Data;
using PersonRegisterDemo.Data.Models;

namespace PersonRegisterDemo
{
    public class Startup
    {
        static async Task Main(string[] args)
        {
            var contextFactory = new PersonRegisterDbContextFactory();
            var dbContext = contextFactory.CreateDbContext(args);

            await dbContext.Database.MigrateAsync();

            //var region = new Region()
            //{
            //    Name = "Smirnenski",
            //    Person = new List<Person> { }

            //};

            var person = new Person()
             {
                 FirstName = "Petar",
                 LastName = "Georgiev",
                 City = "Sofia",
                 Age = 26,
                 

             };

             dbContext.Persons.Add(person);
             await dbContext.SaveChangesAsync(); 

            //var person = dbContext.Persons.Where(p => p.FirstName == "Ivan").ToList();

            //var person1 = dbContext.Persons.First();

            //var person1 = dbContext.Persons.FirstOrDefaultAsync(p => p.FirstName == "Georgi");

            //var person = dbContext.Persons.Where(p => p.Age == 20).Select(p => p.FirstName).ToList();

           // var person3 = dbContext.Persons.OrderBy(p => p.FirstName).ToList();

            //var statement = dbContext.Persons.Any(p => p.FirstName == "Ivan");


            // var statement2 = dbContext.Persons.All(p => p.Age == 20);


            


        }
    }
} 
