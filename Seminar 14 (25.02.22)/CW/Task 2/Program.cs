using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> list = new List<int>();
            Random random = new Random();

            int.TryParse(Console.ReadLine(), out int n);

            for (int i = 0; i < n; i++)
            {
                list.Add(random.Next(-10000, 10001));
            }

            Console.WriteLine("--------------");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            var z1_1 = from g in list
                       select Math.Abs(g) % 10;

            Console.WriteLine("--------------");
            foreach (var item in z1_1)
            {
                Console.WriteLine(item);
            }

            var z1_2 = list.Select(x => Math.Abs(x) % 10);

            Console.WriteLine("--------------");
            foreach (var item in z1_2)
            {
                Console.WriteLine(item);
            }
            var z2_1 = from el in list
                       group el by Math.Abs(el) % 10 into newGroup
                       select newGroup;

            Console.WriteLine("--------------");
            foreach (var item in z2_1)
            {
                Console.WriteLine(item.Key);
            }

            var z2_2 = list.GroupBy(x => Math.Abs(x) % 10);

            Console.WriteLine("--------------");
            foreach (var item in z2_2)
            {
                Console.WriteLine(item.Key);
            }

            var z3_1 = (from el in list
                        where el % 2 == 0
                        select el).Count();

            Console.WriteLine("--------------");
            Console.WriteLine(z3_1);

            var z3_2 = list.Count(x => x % 2 == 0);

            Console.WriteLine("--------------");
            Console.WriteLine(z3_2);

            var z4_1 = (from el in list
                        where el % 2 == 0
                        select el).Sum();

            Console.WriteLine("--------------");
            Console.WriteLine(z4_1);

            var z4_2 = list.Where(x => x % 2 == 0).Sum();

            Console.WriteLine("--------------");
            Console.WriteLine(z4_2);

            var z5_1 = from el in list
                       orderby el / Math.Pow(10, el.ToString().Length), el % 10
                       select el;

            Console.WriteLine("--------------");
            foreach (var item in z5_1)
            {
                Console.WriteLine(item);
            }

            var z5_2 = list.OrderBy(x => x / Math.Pow(10, x.ToString().Length))
                .ThenBy(x => x % 10);

            Console.WriteLine("--------------");
            foreach (var item in z5_2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
