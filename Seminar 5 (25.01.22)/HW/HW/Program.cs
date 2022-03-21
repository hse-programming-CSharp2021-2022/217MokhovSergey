using System;

namespace HW
{
    public delegate double calculate(double x);

    interface IFunction
    {
        double Function(double x);
    }

    class F : IFunction
    {
        calculate calculator;
        public F(calculate a) => calculator = a;
        public double Function(double a)
        {
            return calculator(a);
        }
    }

    class G
    {
        F firstFunc;
        F secondFunc;
        public G(F f1, F f2)
        {
            firstFunc = f1;
            secondFunc = f2;
        }

        public double GF(double x)
        {
            return firstFunc.Function(secondFunc.Function(x));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            G g = new G(new F(x => x * x + 4), new F(x => Math.Sin(x)));
            for (double i = 0; i < Math.PI; i += Math.PI / 16)
            {
                Console.WriteLine(g.GF(i));
            }
        }
    }
}
