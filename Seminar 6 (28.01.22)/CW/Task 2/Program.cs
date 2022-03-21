using System;
using System.Collections.Generic;

namespace Task_2
{
    interface IJump
    {
        void Jump();
    }

    interface IRun
    {
        void Run();
    }

    abstract class Animal : IComparable<Animal>
    {
        public int Age
        {
            get;
            protected set;
        }
        public int CompareTo(Animal animal)
        {
            if (Age < animal.Age)
            {
                return 1;
            }

            if (Age > animal.Age)
            {
                return -1;
            }
            return 0;
        }
    }

    class Cockroach : Animal, IRun
    {
        public int Speed { get; set; }
        public Cockroach(int age, int speed)
        {
            Speed = speed;
            Age = age;
        }
        public void Run()
        {
            Console.WriteLine("Таракан бегает со скоростью {0} км/ч", Speed);
        }
    }

    class CockroachComparer : IComparer<Cockroach>
    {
        public int Compare(Cockroach a, Cockroach b)
        {
            if (a.Speed < b.Speed)
            {
                return 1;
            }

            if (a.Speed > b.Speed)
            {
                return -1;
            }
            return 0;
        }
    }
    class Kangaroo : Animal, IJump
    {
        public int Length { get; }

        public Kangaroo(int age, int length)
        {
            Length = length;
            Age = age;
        }
        public void Jump()
        {
            Console.WriteLine("Кенгуру прыгает на {0} м", Length);
        }

    }
    class KangarooComparer : IComparer<Kangaroo>
    {
        public int Compare(Kangaroo a, Kangaroo b)
        {
            if (a.Length < b.Length)
            {
                return 1;
            }

            if (a.Length > b.Length)
            {
                return -1;
            }
            return 0;
        }
    }
    class Cheetah : Animal, IJump, IRun
    {
        public int Length { get; }
        public int Speed { get; }

        public Cheetah(int age, int speed, int length)
        {
            Length = length;
            Age = age;
            Speed = speed;
        }
        public void Jump()
        {
            Console.WriteLine("Гепард прыгает на {0} м", Length);
        }
        public void Run()
        {
            Console.WriteLine("Гепард бегает со скоростью {0} км/ч", Speed);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new()
            {

                new Cockroach(10, 12),
                new Cockroach(32, 14),
                new Cheetah(15, 42, 33),
                new Cheetah(25, 30, 12),
                new Kangaroo(14, 18),
                new Kangaroo(28, 24)
            };

            animals.Sort();
            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.GetType().Name}, возраст = {animal.Age}");
            }

            List<Kangaroo> kangaroos = new List<Kangaroo>();
            foreach (var animal in animals)
            {
                if (animal is Kangaroo)
                {
                    kangaroos.Add(animal as Kangaroo);
                }
            }

            kangaroos.Sort(new KangarooComparer());
            foreach (var kangaroo in kangaroos)
            {
                Console.WriteLine($"Кенгуру, возраст = {kangaroo.Age}, длина = {kangaroo.Length}");
            }


            List<Cockroach> cockroaches = new List<Cockroach>();
            foreach (var animal in animals)
            {
                if (animal is Cockroach)
                {
                    cockroaches.Add(animal as Cockroach);
                }
            }
            cockroaches.Sort(new CockroachComparer());
            foreach (var cockroach in cockroaches)
            {
                Console.WriteLine($"Таракан, возраст = {cockroach.Age}, скорость = {cockroach.Speed}");
            }
        }
    }
}
