using System;
using System.IO;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                ChangeData();
            }
        }

        private static void ChangeData()
        {
            using (FileStream fs = new FileStream("1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                if (fs.Length == 0)
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes("A");
                    fs.Write(array, 0, array.Length);
                }
                else
                {
                    byte[] array = new byte[fs.Length];
                    fs.Read(array, 0, array.Length);
                    string line = System.Text.Encoding.Default.GetString(array);

                    byte[] array2 = System.Text.Encoding.Default.GetBytes(
                        ((char)(line[^1] + 1)).ToString());
                    fs.Position = array.Length;
                    fs.Write(array2, 0, 1);
                }
            }
        }
    }
}
