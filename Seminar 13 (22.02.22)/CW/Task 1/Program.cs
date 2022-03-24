using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_1
{
    class Week : IEnumerable
    {
        string[] days = { "Monday", "Tuesday", "Wednesday" };
        public IEnumerator GetEnumerator()
        {
            return days.GetEnumerator();
        }
    }
    class Week2 : IEnumerable
    {
        string[] days = { "Monday", "Tuesday", "Wednesday" };
        public IEnumerator GetEnumerator()
        {
            return new WeekEnumerator(days);
        }
        class WeekEnumerator : IEnumerator<string>
        {
            int position = -1;
            string[] days;
            public WeekEnumerator(string[] days)
            {
                this.days = days;
            }
            public string Current => days[position];
            object IEnumerator.Current => days[position];
            public void Dispose() { }
            public bool MoveNext()
            {
                if (position < days.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void Reset()
            {
                position = -1;
            }
        }
    }

    class ArProgression : IEnumerable
    {
        int a0, d;
        public ArProgression(int a0, int d)
        {
            this.a0 = a0; this.d = d;
        }
        public IEnumerator GetEnumerator()
        {
            return new ArProgressionEnumerator(a0, d);
        }
        public IEnumerable NextElement(int n)
        {
            return new ArProgressionEnumerator(a0, d, n);
        }
        public IEnumerable NextElementYield(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return a0 + d * i;
            }
        }
        class ArProgressionEnumerator : IEnumerator, IEnumerable
        {
            int a0, d;
            public ArProgressionEnumerator(int a0, int d)
            {
                this.a0 = a0; this.d = d;
            }
            public ArProgressionEnumerator(int a0, int d, int n)
            {
                this.a0 = a0; this.d = d; this.n = n;
            }
            int position = -1;
            int n = 10;
            public object Current => a0 + d * position;
            public bool MoveNext()
            {
                if (position < n - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void Reset()
            {
                position = -1;
            }
            public IEnumerator GetEnumerator()
            {
                return this;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArProgression arProgression = new ArProgression(2, 4);
            foreach (var a in arProgression)
            {
                Console.WriteLine(a);
            }
            foreach (var a in arProgression.NextElement(5))
            {
                Console.WriteLine(a);
            }
            foreach (var a in arProgression.NextElementYield(15))
            {
                Console.WriteLine(a);
            }
            //Week2 week = new Week2();
            //foreach(var day in week)
            //{
            //    Console.WriteLine(day);
            //}
            //string[] str = { "freg", "fewfer", "3wfe" };
            //foreach (string s in str)
            //{
            //    Console.WriteLine(s);
            //}
            //IEnumerator strenum = str.GetEnumerator();
            //while(strenum.MoveNext())
            //{
            //    Console.WriteLine(strenum.Current);
            //}
        }
    }
}