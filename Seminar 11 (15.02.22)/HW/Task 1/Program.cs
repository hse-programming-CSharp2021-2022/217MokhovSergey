using System;
using System.IO;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(
                       new FileStream("Numbers.txt", FileMode.Create, FileAccess.ReadWrite)))
            {
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    binaryWriter.Write(random.Next(1, 101));
                }
            }

            int[] array = new int[10];
            using (BinaryReader binaryReader = new BinaryReader(
                       new FileStream("Numbers.txt", FileMode.Open)))
            {

                for (int i = 0; i < 10; i++)
                {
                    array[i] = binaryReader.ReadInt32();
                    Console.WriteLine(array[i]);
                }


                Console.WriteLine("----------- \n Введите число \n----------- ");
                int.TryParse(Console.ReadLine(), out int number);


                int min = Int32.MaxValue;
                int index = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    int delta = Math.Abs(number - array[i]);
                    if (delta < min)
                    {
                        min = delta;
                        index = i;
                    }
                }

                array[index] = min;
            }


            using (BinaryWriter binaryWriter = new BinaryWriter(
                       new FileStream("Numbers.txt", FileMode.Create, FileAccess.ReadWrite)))
            {
                for (int i = 0; i < 10; i++)
                {
                    binaryWriter.Write(array[i]);
                }
            }

            using (BinaryReader reader
                   = new BinaryReader(new FileStream("Numbers.txt", FileMode.Open)))
            {
                for (int i = 0; i < 10; ++i)
                {
                    array[i] = reader.ReadInt32();
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}
