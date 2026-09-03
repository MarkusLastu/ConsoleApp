using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbeten_Project.Vecka2
{
    public abstract class Animal
    {

        public string Name { get; set; }

        public Animal(string name)
        {

            Name = name;

            Console.WriteLine($"Creating one {GetType().Name} named: {Name}");

        }

        public abstract void MakeSound();
        public virtual void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }
        public virtual void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }
    }


    class Lion : Animal
    {

        public string Name { get; set; }

        public Lion(string name) : base(name)
        {
            Name = name;

        }

        public override void MakeSound()

        {

            Console.WriteLine($"{Name} roars: Roar!");
        }

    }

    class Elephant : Animal
    {
        public string Name { get; set; }
        public Elephant(string name) : base(name)
        {
            Name = name;

        }

        public override void MakeSound()

        {

            Console.WriteLine($"{Name} trumpets: Trumpet!");
        }

    }

    class Parrot : Animal
    {

        public string Name { get; set; }

        public Parrot(string name) : base(name)
        {
            Name = name;

        }

        public override void MakeSound()

        {

            Console.WriteLine($"{Name} squawks: Squawk!");
        }

    }
}
