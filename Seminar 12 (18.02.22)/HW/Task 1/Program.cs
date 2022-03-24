using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_1
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }

        public Human() { }

        public Human(string name)
        {
            Name = name;
        }
    }

    [Serializable]
    public class Professor : Human
    {
        public Professor(string name) : base(name) { }

        public Professor() { }
    }

    [Serializable]
    [XmlInclude(typeof(Professor)), XmlInclude(typeof(Human))]
    public class Department
    {
        public Department() { }

        public string Name { get; set; }
        public List<Human> Humans { get; set; }

        public Department(List<Human> humans, string name)
        {
            Name = name;
            Humans = humans;
        }

        public override string ToString()
        {
            string output = $"->{Name}<-" + Environment.NewLine;
            foreach (var person in Humans)
            {
                output += person.Name + Environment.NewLine;
            }
            return output;
        }
    }

    [Serializable]
    [XmlInclude(typeof(Professor)), XmlInclude(typeof(Human)), XmlInclude(typeof(Department))]
    public class University
    {
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

        public University() { }

        public University(List<Department> departments, string name)
        {
            Name = name;
            Departments = departments;
        }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Human> list = new List<Human>() {
                new Human("Ben"), new Professor("Jeff"),
                new Human("Mike"), new Professor("Calman")
            };

            University university = new University(
                new List<Department>(){
                    new Department(list, "department 1"),
                    new Department(list, "department 2")},
                "HSE");


            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("BinaryFormatter.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, university);
            }

            using (FileStream fileStream = new FileStream("BinaryFormatter.txt", FileMode.OpenOrCreate))
            {
                var universityDeserialize = (University)formatter.Deserialize(fileStream);
                foreach (var dept in universityDeserialize.Departments)
                {
                    Console.WriteLine(dept);
                }
            }


            XmlSerializer serializer = new XmlSerializer(typeof(University));

            using (FileStream fileStream = new FileStream("Xml.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fileStream, university);
            }

            using (FileStream fileStream = new FileStream("Xml.xml", FileMode.OpenOrCreate))
            {
                var universityDeserialize = (University)serializer.Deserialize(fileStream);
                foreach (var dept in universityDeserialize.Departments)
                {
                    Console.WriteLine(dept);
                }
            }

            using (FileStream fileStream = new FileStream("Json.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fileStream, university);
            }

            using (FileStream fileStream = new FileStream("Json.json", FileMode.OpenOrCreate))
            {
                var universityDeserialize = await JsonSerializer.DeserializeAsync<University>(fileStream);
                foreach (var dept in universityDeserialize.Departments)
                {
                    Console.WriteLine(dept);
                }
            }
        }
    }
}
