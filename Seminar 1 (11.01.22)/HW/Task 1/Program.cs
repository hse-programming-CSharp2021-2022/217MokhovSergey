using System;

namespace Task_1
{
    internal class Program
    {
        delegate int Cast(double a);

        static void Main(string[] args)
        {
            Cast cast1 = delegate (double a)
            {
                return (int)a % 2 == 0 ? (int)a : (int)a + 1;
            };

            Cast cast2 = delegate (double a)
            {
                return ((int)a).ToString().Length;
            };

            Console.WriteLine("Тесты для cast1 и cast2:");
            Console.WriteLine(cast1(1.55));
            Console.WriteLine(cast1(99.55));
            Console.WriteLine(cast2(1.55));
            Console.WriteLine(cast2(99.55));

            Cast cast3 = cast1 + cast2;

            Console.WriteLine("Тесты для cast3:");
            Console.WriteLine(cast3(1.55));
            Console.WriteLine(cast3(99.55));

            Cast LambdaCast1 = (double a) => (int)a % 2 == 0 ? (int)a : (int)a + 1;

            Cast LambdaCast2 = (double a) => ((int)a).ToString().Length;

            cast3 -= cast2;

            Console.WriteLine("Тесты для cast3:");
            Console.WriteLine(cast3(1.55));
            Console.WriteLine(cast3(99.55));
        }
    }
}

