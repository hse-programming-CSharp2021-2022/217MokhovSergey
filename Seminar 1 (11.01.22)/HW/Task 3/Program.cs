using System;
using System.Collections.Generic;

namespace Task_3
{
    internal class Program
    {
        delegate double DelegateConvertTemperature(double t);

        class TemperatureConvertImp
        {
            public double CelsiusToFahrenheit(double t) => (double)5 / 9 * (t - 32);

            public double FahrenheitToCelsius(double t) => (double)9 / 5 * t + 32;
        }

        class StaticTempConverts
        {
            public static double CtoK(double temp) => temp + 273.15;
            public static double KtoC(double temp) => temp - 273.15;

            public static double CtoR(double temp) => (temp + 273.15) * (double)9 / 5;
            public static double RtoC(double temp) => (temp - 491.67) * (double)5 / 9;

            public static double CtoRe(double temp) => temp * (double)4 / 5;
            public static double RetoC(double temp) => temp * (double)5 / 4;
        }



        static void Main(string[] args)
        {
            TemperatureConvertImp TempClass = new();

            DelegateConvertTemperature CelToFar = TempClass.CelsiusToFahrenheit;
            DelegateConvertTemperature FarToCel = TempClass.FahrenheitToCelsius;

            Console.WriteLine(CelToFar(100));
            Console.WriteLine(FarToCel(50));

            List<DelegateConvertTemperature> list = new()
            {
                CelToFar,
                FarToCel,
                StaticTempConverts.CtoK,
                StaticTempConverts.CtoR,
                StaticTempConverts.CtoRe
            };

            Console.WriteLine("Введите значение в Цельсиях:");
            int input = 0;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Введите значение в Цельсиях:");

            }
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Method.Name}: {item(input)}");
            }

        }
    }
}
