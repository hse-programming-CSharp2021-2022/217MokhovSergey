using System;

namespace Task_1
{
    public struct Person : IComparable<Person>
    {
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                _name = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                _lastName = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _age = value;
            }
        }

        private string _name;
        private string _lastName;
        private int _age;


        public Person(string name, string lastName, int age) : this()
        {
            Name = name;
            LastName = lastName;
            Age = age;
        }

        public int CompareTo(Person person)
        {
            if (Age > person.Age)
            {
                return 1;
            }

            if (Age == person.Age)
            {
                return 0;
            }
            return -1;
        }

        public override string ToString()
        {
            return $"Имя: {Name} | Фамилия: {LastName} | Возраст: {Age}";
        }
    }

    class Program
    {
        static void Main()
        {
            Random random = new Random();

            string[] name = { "Jack", "Den", "Carl" };
            string[] lastname = { "Black", "Red", "White" };
            int n = int.Parse(Console.ReadLine());

            Person[] persons = new Person[n];

            for (int i = 0; i < n; i++)
            {
                persons[i] = new Person(name[random.Next(name.Length)], lastname[random.Next(lastname.Length)], random.Next(1, 101));
            }
            Array.ForEach(persons, person => Console.WriteLine(person));

            Array.Sort(persons);
            Array.ForEach(persons, person => Console.WriteLine(person));
        }
    }
}
