using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
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

            var z1 = list.Select(x => x * x);

            Console.WriteLine("--------------");
            foreach (var item in z1)
            {
                Console.WriteLine(item);
            }

            var z2 = list.Where(x => x > 0 && x < 100);

            Console.WriteLine("--------------");
            foreach (var item in z2)
            {
                Console.WriteLine(item);
            }

            var z3 = list.Where(x => x % 2 == 0).OrderByDescending(x => x);

            Console.WriteLine("--------------");
            foreach (var item in z3)
            {
                Console.WriteLine(item);
            }

            var z4 = list.GroupBy(x => x.ToString().Length).ToArray();
            Console.WriteLine("--------------");
            Array.ForEach(z4, x => { Array.ForEach(x.ToArray(), Console.WriteLine); });
        }
    }
}
