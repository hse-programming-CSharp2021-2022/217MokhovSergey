using System;
using System.Collections;

namespace Task_2
{

    public class Fibbonacci
    {
        private int _el1 = 1;
        private int _el2 = 1;
        public IEnumerable GetElement(int a)
        {
            for (int i = 0; i < a; i++)
            {
                yield return _el1;
                int box = _el1 + _el2;
                _el1 = _el2;
                _el2 = box;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Fibbonacci myFibbonacci = new Fibbonacci();
            foreach (var item in myFibbonacci.GetElement(5))
            {
                Console.WriteLine(item);
            }
        }
    }
}
