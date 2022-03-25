using System;

namespace HW
{
    class Program
    {
        public class RingIsFoundEventArgs : EventArgs
        {
            public RingIsFoundEventArgs(string s) { Message = s; }
            public String Message { get; set; }
        }

        public abstract class Creature
        {
            public string Name { get; set; }
            public string Location { get; set; }

            public Creature(string name, string location)
            {
                Name = name;
                Location = location;
            }

            public abstract void Method(object sender, RingIsFoundEventArgs e);
        }

        public class Wizard : Creature
        {
            public delegate void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs a);

            public event RingIsFoundEventHandler RaiseRingIsFoundEvent;

            public Wizard(string name, string location) : base(name, location) { }

            public void SomeThisIsChangedInTheAir()
            {
                Console.WriteLine($"{Name} >> Кольцо найдено у старого Бильбо! Призываю вас в Ривендейл! ");
                RaiseRingIsFoundEvent(this, new RingIsFoundEventArgs("Ривендейл"));
            }

            public override void Method(object sender, RingIsFoundEventArgs e)
            {
                throw new NotImplementedException();
            }
        }




        public sealed class Hobbit : Creature
        {
            public Hobbit(string name, string location) : base(name, location) { }

            public override void Method(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. Покидаю Шир! Иду в " + e.Message);
                Location = e.Message;
            }
        }

        public class Human : Creature
        {
            public Human(string name, string location) : base(name, location) { }
            public override void Method(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. Волшебник {((Wizard)sender).Name} позвал. Моя цель {e.Message}");
                Location = e.Message;
            }
        }

        public class Elf : Creature
        {
            public Elf(string name, string location) : base(name, location) { }

            public override void Method(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. Звёзды светят не так ярко как обычно. Цветы увядают. Листья предсказывают идти в " + e.Message);
                Location = e.Message;
            }
        }

        public class Dwarf : Creature
        {
            public Dwarf(string name, string location) : base(name, location) { }

            public override void Method(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. Точим топоры, собираем припасы! Выдвигаемся в " + e.Message);
                Location = e.Message;
            }
        }

        static void Main(string[] args)
        {
            Wizard wizard = new Wizard("Wizard 1", "location");
            Creature[] creatures =
            {
                new Hobbit("Hobbit 1", "location"),
                new Hobbit("Hobbit 2", "location"),
                new Human("Human 1", "location"),
                new Human("Human 2", "location"),
                new Dwarf("Dwarf 1", "location"),
                new Dwarf("Dwarf 2", "location"),
                new Elf("Elf 1", "location"),
                new Elf("Elf 2", "location")

            };
            foreach (var creature in creatures)
            {
                wizard.RaiseRingIsFoundEvent += creature.Method;
            }
            wizard.SomeThisIsChangedInTheAir();
        }

    }
}