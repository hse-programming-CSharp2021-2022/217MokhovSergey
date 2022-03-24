using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Task_1
{
    [Serializable]
    public class Person
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonIgnore]
        public int Year { get; set; }

        [NonSerialized]
        private int _someValue;

        [JsonInclude]
        public int a = 100;
        public int b = 200;

        public Person(string name, int year)
        {
            Name = name;
            Year = year;
        }
        public Person() { }
    }
    internal class Program
    {

        public static void Main(string[] args)
        {
            Person person1 = new Person("Bob", 1980);
            Person person2 = new Person("Tom", 1995);

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream("output.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, person1);
            }

            using (FileStream fileStream = new FileStream("output.txt", FileMode.OpenOrCreate))
            {
                Person p = (Person)formatter.Deserialize(fileStream);
                Console.WriteLine(p.Name + " " + p.Year);
            }

            Person[] people = new Person[] { person1, person2 };

            using (FileStream fileStream = new FileStream("output.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, people);
            }

            using (FileStream fileStream = new FileStream("output.txt", FileMode.OpenOrCreate))
            {
                Person[] array = (Person[])formatter.Deserialize(fileStream);
                foreach (var person in people)
                {
                    Console.WriteLine(person.Name + " " + person.Year);
                }
            }

            // Xml не сериализует приватные поля и требует конструктор без параметров.

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using (FileStream fileStream = new FileStream("output1.txt", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, person1);
            }

            using (FileStream fileStream = new FileStream("output1.txt", FileMode.OpenOrCreate))
            {
                Person p = (Person)xmlSerializer.Deserialize(fileStream);
                Console.WriteLine(p.Name + " " + p.Year);
            }

            XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(Person[]));
            using (FileStream fileStream = new FileStream("output4.txt", FileMode.OpenOrCreate))
            {
                xmlSerializer2.Serialize(fileStream, people);
            }

            using (FileStream fileStream = new FileStream("output4.txt", FileMode.OpenOrCreate))
            {
                Person[] array = (Person[])xmlSerializer2.Deserialize(fileStream);
                foreach (var person in people)
                {
                    Console.WriteLine(person.Name + " " + person.Year);
                }
            }

            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                WriteIndented = true
            };

            // По умолчанию сериализуются только свойства. Для полей пишем [JsonInclude]
            string json = JsonSerializer.Serialize<Person>(person1, options);
            Console.WriteLine(json);

            Person person3 = JsonSerializer.Deserialize<Person>(json, options);
            Console.WriteLine(person3.Name + " " + person3.Year);
        }
    }
}
