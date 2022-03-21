using System;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TriangleComp triangle = new(new Point(0, 0), new Point(0, 1), new Point(1, 0));
            Console.WriteLine(triangle.Area + " " + triangle.IsInside(new Point(0.5, 1)));
        }
    }
    class Point
    {
        public double x { get; set; }
        public double y { get; set; }
        public Point(double x0, double y0)
        {
            x = x0;
            y = y0;
        }
        public double FindDistance(Point A)
        {
            return Math.Sqrt(Math.Pow(x - A.x, 2) + Math.Pow(y - A.y, 2));
        }
    }
    class TriangleComp
    {
        private Point A1, A2, A3;
        private double AB { get; set; }
        private double BC { get; set; }
        private double CA { get; set; }
        public double Area
        {
            get
            {
                double p = (AB + BC + CA) / 2;
                return Math.Sqrt(p * (p - AB) * (p - BC) * (p - CA));
            }
        }
        public bool IsInside(Point P)
        {
            double a = (A1.x - P.x) * (A2.y - A1.x) - (A2.x - A1.x) * (A1.y - P.y);
            double b = (A2.x - P.x) * (A3.x - A2.x) - (A3.x - A2.x) * (A2.y - P.y);
            double c = (A1.x - P.x) * (A1.y - A3.y) - (A1.x - A3.x) * (A3.y - P.y);

            return (a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0);
        }
        public TriangleComp(Point A, Point B, Point C)
        {
            A1 = A;
            A2 = B;
            A3 = C;
            AB = A.FindDistance(B);
            CA = A.FindDistance(C);
            BC = B.FindDistance(C);
        }
    }
}