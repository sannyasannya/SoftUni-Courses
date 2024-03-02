using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
        public class Dog
        {

            public Dog()
            {
            
            }
            public Dog(string name, int age)
            {
                Name = name;
                Age = age;
            }

             public string Name { get; set; }

            public string Breed { get; set; }

            public int Age { get; set; }


            public void Bark()
            {
                Console.WriteLine("Bark!");
            }
        }
}
