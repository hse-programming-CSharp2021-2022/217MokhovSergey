using System;
using System.Diagnostics;

namespace Task_1
{

    class B : IComparable<B>
    {
        public int b;
        public int CompareTo(B other)
        {
            return other.b - this.b;
        }
    }
    struct A : IComparable<A>
    {
        public int a;
        public int CompareTo(A other)
        {
            return other.a - this.a;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100000;
            A[] a = new A[n];
            B[] b = new B[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                int c = random.Next(1000);
                a[i].a = c;
                b[i] = new B();
                b[i].b = c;
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Array.Sort(a);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Start();
            Array.Sort(b);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
