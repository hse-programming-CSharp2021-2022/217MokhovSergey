using System;
using System.IO;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOfStrings = new[] { "regre", "|", "grege", "|", "absa" };
            using (FileStream fileStream = new FileStream("1.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                foreach (var str in arrayOfStrings)
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(str);
                    fileStream.Write(array, 0, array.Length);
                }
            }

            using (FileStream fileStream = new FileStream("1.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                byte[] array = new byte[fileStream.Length];
                fileStream.Read(array, 0, array.Length);
                Console.WriteLine(System.Text.Encoding.Default.GetString(array));
            }

            string line = "red black white";
            using (FileStream fileStream = new FileStream("2.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(line);
                fileStream.Write(array, 0, array.Length);
            }

            using (FileStream fileStream = new FileStream("2.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                string replace = "abcde";
                // Начиная с какой позиции будет производиться запись слова. 
                fileStream.Seek(-1, SeekOrigin.End);
                byte[] array = System.Text.Encoding.Default.GetBytes(replace);
                fileStream.Write(array, 0, array.Length);
            }

            using (StreamWriter sw = new StreamWriter("3.txt"))
            {
                sw.Write(line);
            }

            using (StreamReader sr = new StreamReader("3.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());
            }

        }
    }
}
