using System.Text;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input =            
            {
                "Vladi 215130 2",
                "Sanya 910518 32"
            };
            //"{name} {id} {age}"
            List<Person> people = new List<Person>();

            Person p1 = new Person();
            people.AddRange( p1.AddPeople(input));

            foreach (Person person in people)
            {
                Console.WriteLine($"the name is {person.Name} with Id:{person.Id} and {person.Age} years old.");
            }


        }
    }
    public class Person
    {
        public string Name { get; set; } = null!;

        public string Id { get; set; } = null!;

        public int Age { get; set; }

        public List<Person> AddPeople(string[] people)
        {
            List<Person> peopleList = new();
            foreach (string data in people)
            {
                string[] split = data.Split();

                string name = split[0];
                string id = split[1];
                int age = int.Parse(split[2]);

                Person? searchPerson = peopleList.FirstOrDefault(person => person.Id == id);
                if (searchPerson is null)
                {
                    peopleList.Add(new()
                    {
                        Name = name,
                        Id = id,
                        Age = age
                    });
                }
                else
                {
                    searchPerson.Age = age;
                    searchPerson.Name = name;
                }
            }

            return peopleList;
        }

        public string GetByAgeAscending(List<Person> people)
        {
            StringBuilder sb = new();
            foreach (Person person in people.OrderBy(person => person.Age))
            {
                sb.AppendLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }

            return sb.ToString().Trim();
        }
    }
}

    