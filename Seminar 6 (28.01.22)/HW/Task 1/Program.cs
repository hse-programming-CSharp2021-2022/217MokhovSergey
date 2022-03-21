using System;

namespace Task_1
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double Distance(Point point)
        {
            return Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
        }
        public override string ToString() => $"Point({X},{Y})";

    }
    class Circle : IComparable<Circle>
    {
        public double Rad { get; set; }
        public Point Center { get; set; }
        public Circle(double x, double y, double rad)
        {
            Rad = rad;
            Center = new Point(x, y);
        }
        public override string ToString()
        {
            return $"Rad: {Rad} | Center: {Center}";
        }

        public int CompareTo(Circle obj)
        {
            if (Rad * Center.Distance(new Point(0, 0)) < obj.Rad * obj.Center.Distance(new Point(0, 0)))
            {
                return -1;
            }
            if (Rad * Center.Distance(new Point(0, 0)) > obj.Rad * obj.Center.Distance(new Point(0, 0)))
            {
                return 1;
            }
            return 0;
        }
    }

    struct PointStructure
    {
        public double X { get; set; }
        public double Y { get; set; }
        public PointStructure(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Distance(PointStructure point)
        {
            return Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
        }
    }

    struct CircleStructure
    {
        public double Rad { get; set; }
        public PointStructure center { get; set; }
        public CircleStructure(double x, double y, double rad)
        {
            center = new PointStructure(x, y);
            Rad = rad;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Circle[] array = new Circle[3];
            for (int i = 0; i < 3; i++)
            {
                array[i] = new Circle(
                    random.Next() + random.NextDouble(),
                    random.Next() + random.NextDouble(),
                    random.Next() + random.NextDouble());
            }

            Array.ForEach(array, item => Console.WriteLine(item));

            Array.Sort(array, (circle1, circle2) =>
                (circle1.Rad * circle1.Center.Distance(new Point(0, 0))).CompareTo(circle2.Rad * circle2.Center.Distance(new Point(0, 0))));
            Array.ForEach(array, item => Console.WriteLine(item));

            Array.Sort(array, delegate (Circle circle1, Circle circle2)
            {
                return (circle1.Rad * circle1.Center.Distance(new Point(0, 0))).CompareTo(circle2.Rad * circle2.Center.Distance(new Point(0, 0)));

            });
            Array.ForEach(array, item => Console.WriteLine(item));

            Array.Sort(array);
            Array.ForEach(array, item => Console.WriteLine(item));

        }
    }
}