using System;

namespace Task_1
{
    internal class Program
    {
        public delegate void CoordChanged(Dot dot);

        public class Dot
        {

            public double X { get; set; }

            public double Y { get; set; }

            public Dot(double x, double y)
            {
                X = x;
                Y = y;
            }

            public event CoordChanged OnCoordChanged;

            public void DotFlow()
            {
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    X = random.Next(-10, 11) + random.NextDouble();
                    Y = random.Next(-10, 11) + random.NextDouble();

                    if (X < 0 && Y < 0)
                    {
                        OnCoordChanged?.Invoke(this);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            Dot dot = new Dot(x, y);
            dot.OnCoordChanged += PrintInfo;
            dot.DotFlow();
        }

        private static void PrintInfo(Dot obj)
        {
            Console.WriteLine($"X:{obj.X}{Environment.NewLine}Y:{obj.Y}{Environment.NewLine}");
        }
    }
}
