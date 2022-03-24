using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace Task_2
{
    [Serializable]
    public class Student
    {
        public string Surname { get; set; }
        public int Course { get; set; }

        public Student(string surname, int course)
        {
            Surname = surname;
            Course = course;
        }

        public Student() { }
    }

    [Serializable]
    public class Group
    {
        public int Id { get; set; }
        public List<Student> Students { get; set; }

        public Group(int id, List<Student> students)
        {
            Id = id;
            Students = students;
        }

        public Group() { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Group group1 = new Group(1, new List<Student>() { new Student("Black", 1), new Student("White", 1) });
            Group group2 = new Group(2, new List<Student>() { new Student("Red", 2), new Student("Orange", 2) });

            Group[] groups = new[] { group1, group2 };
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream("binary.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, groups);
            }

            using (FileStream fileStream = new FileStream("binary.txt", FileMode.Open))
            {
                var array = (Group[])formatter.Deserialize(fileStream);
                foreach (var item in array)
                {
                    Console.WriteLine("Group id:" + item.Id);
                    foreach (var student in item.Students)
                    {
                        Console.WriteLine(student.Surname + " " + student.Course);
                    }
                }
            }

            // Все элементы сериализации должны быть Serializable.

            XmlSerializer serializer = new XmlSerializer(typeof(Group[]));
            using (FileStream fileStream = new FileStream("xml.txt", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fileStream, groups);
            }

            using (FileStream fileStream = new FileStream("xml.txt", FileMode.Open))
            {
                var array = (Group[])serializer.Deserialize(fileStream);
                foreach (var item in array)
                {
                    Console.WriteLine("Group id:" + item.Id);
                    foreach (var student in item.Students)
                    {
                        Console.WriteLine(student.Surname + " " + student.Course);
                    }
                }
            }


            string json = JsonSerializer.Serialize(groups);

            var array2 = JsonSerializer.Deserialize<Group[]>(json);
            foreach (var item in array2)
            {
                Console.WriteLine("Group id:" + item.Id);
                foreach (var student in item.Students)
                {
                    Console.WriteLine(student.Surname + " " + student.Course);
                }
            }
        }
    }
}
