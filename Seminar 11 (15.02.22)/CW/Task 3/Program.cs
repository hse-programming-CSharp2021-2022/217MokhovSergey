using System;
using System.IO;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(
                       new FileStream("1.txt", FileMode.OpenOrCreate)))
            {
                binaryWriter.Write("123");
            }

            using (BinaryReader binaryReader = new BinaryReader(new FileStream("1.txt", FileMode.Open)))
            {
                Console.WriteLine(binaryReader.ReadString());
            }
        }
    }
}
