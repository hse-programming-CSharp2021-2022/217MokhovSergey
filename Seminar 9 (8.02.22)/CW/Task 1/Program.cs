using System;

namespace Task_1
{
    interface IFigure
    {
        double GetArea { get; }
    }

    class Square : IFigure
    {
        double Side { get; set; }

        public double GetArea => Side * Side;

        public Square(double side)
        {
            Side = side;
        }
    }

    class Circle : IFigure
    {
        double Radius { get; set; }

        public double GetArea => Math.PI * Radius * Radius;

        public Circle(double r)
        {
            Radius = r;
        }

        public override string ToString()
        {
            return "Круг радиуса " + Radius;
        }

    }

    class Program
    {
        public static void PrintFromArea<T>(T[] mass, double limit) where T : IFigure
        {
            foreach (var figure in mass)
            {
                if (figure.GetArea > limit)
                {
                    Console.WriteLine($"Type: {figure.GetType().Name} | Area:{figure.GetArea}");
                }
            }
        }


        static void Main(string[] args)
        {
            Random rnd = new();

            IFigure[] figures = new IFigure[5];
            Circle[] circles = new Circle[5];
            Square[] squares = new Square[5];

            for (int i = 0; i < 5; i++)
            {
                figures[i] = new Square(rnd.Next(6));
                squares[i] = new Square(rnd.Next(6));
                circles[i] = new Circle(rnd.Next(6));
            }

            PrintFromArea(figures, 3);
            PrintFromArea(circles, 3);
            PrintFromArea(squares, 3);
        }
    }

}