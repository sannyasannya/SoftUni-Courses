namespace Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Sanya", 32);
            Console.WriteLine(person.Name);

            Worker worker = new Worker("Sanya", 32, "KPKONPI");
            
        }
    }

    public class Person
    {
        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            this._name = name;
            this._age = age;

           //this.isoflegalage(this);
        }

        public string Name 
        {
            get
            {
                return this._name;
            }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name is not valid!");
                }
                this._name = value;
            }
        }

        public int Age
        {
            get
            {
                return this._age;
            }
            private set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentException("Age must be a positive number.");
                }


                this._age = value;
            }
        }
        public void SayName()
        {
            Console.WriteLine(this.Name);
        }

        //public bool IsOfLegalAge(Person person)
        //{
        //    return person.Age >= 18;
        //}
    }

    public class Worker : Person
    {
        private string _workplace;

        public Worker(string name, int age, string workplace) : base(name, age)
        {
            this.Workplace = workplace;
        }

        public string Workplace
        {
            get
            {
                return this._workplace;
            }
            set
            {
                _workplace = value;
            }
        }
    }
    
    public class Student : Person
    {
        public Student (string name, int age, string university) : base (name, age)
        {
            University = university;
        }
        public string University { get; set; }
    }
}