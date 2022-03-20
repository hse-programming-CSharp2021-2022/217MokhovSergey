using System;

namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int n = int.Parse(Console.ReadLine());
            Plant[] arrayOfPlants = new Plant[n];
            for (int i = 0; i < n; i++)
            {
                arrayOfPlants[i] = new Plant((double)random.Next(25, 101), (double)random.Next(0, 101), (double)random.Next(0, 81));
            }

            Console.WriteLine("Изначальный массив");
            Array.ForEach(arrayOfPlants, plant => Console.WriteLine(plant));

            Array.Sort(arrayOfPlants, delegate (Plant plant1, Plant plant2) { return plant1.Growth > plant2.Growth ? -1 : 1; });

            Console.WriteLine("Сортировка по Growth");
            Array.ForEach(arrayOfPlants, plant => Console.WriteLine(plant));

            Array.Sort(arrayOfPlants, (Plant plant1, Plant plant2) => plant1.Frostresistance > plant2.Frostresistance ? 1 : -1);

            Console.WriteLine("Сортировка по Frostresistance");
            Array.ForEach(arrayOfPlants, plant => Console.WriteLine(plant));

            Array.Sort(arrayOfPlants, ComparePlants);

            Console.WriteLine("Сортировка по четности Photosensiuvity");
            Array.ForEach(arrayOfPlants, plant => Console.WriteLine(plant));

            Array.ConvertAll(arrayOfPlants,
                (Plant plant) => plant.Frostresistance = plant.Frostresistance % 2 == 0
                    ? plant.Frostresistance / 3
                    : plant.Frostresistance / 2);

            Console.WriteLine("Изменение Frostresistance");
            Array.ForEach(arrayOfPlants, plant => Console.WriteLine(plant));


        }

        public static int ComparePlants(Plant a, Plant b)
        {
            if (a.Photosensiuvity % 2 != 0 && b.Photosensiuvity % 2 == 0)
            {
                return 1;
            }

            if (Math.Abs(a.Photosensiuvity - b.Photosensiuvity) < double.Epsilon)
            {
                return 0;
            }

            return -1;
        }
    }

    class Plant
    {
        private double growth;
        private double photosensiuvity;
        private double frostresistance;

        public double Growth
        {
            get => growth;
            private set => growth = value;
        }

        public double Photosensiuvity
        {
            get => photosensiuvity;
            private set
            {
                if (value >= 0 && value <= 100)
                    photosensiuvity = value;
                else
                {
                    photosensiuvity = 0;
                }
            }
        }

        public double Frostresistance
        {
            get => frostresistance;
            set
            {
                if (value >= 0 && value <= 100)
                    frostresistance = value;
                else
                {
                    frostresistance = 0;
                }
            }
        }

        public Plant(double growth, double photosensiuvity, double frostresistance)
        {
            Growth = growth;
            Photosensiuvity = photosensiuvity;
            Frostresistance = frostresistance;
        }

        public override string ToString()
        {
            return $"Growth: {Growth}, Photosensivity: {Photosensiuvity}, Frostresistance: {Frostresistance}";
        }
    }
}
