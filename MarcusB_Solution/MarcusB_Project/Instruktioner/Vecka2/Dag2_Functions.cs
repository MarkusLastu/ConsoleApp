using System;
using System.Collections.Generic;
using System.Text;

namespace MarcusB_Project.Instruktioner.Vecka2
{

    class Vehicle
    {
        public string Brand;
        public Vehicle(string brand)
        {
            Brand = brand;
            Console.WriteLine($"Creating a vehicle: {Brand}");
        }
        public void Drive()
        {
            Console.WriteLine($"{Brand} drives forward.");
        }
    }
    class Car : Vehicle
    {
        public Car(string brand) : base(brand)
        {
            // tom konstruktor förutom att brand ärvs från Vehicle}
        }
        public void Honk()
        {
            Console.WriteLine($"{Brand} honks: Beep!");
        }
    }

    class Vehicle2
    {
        public string Brand;
        public Vehicle2(string brand) { Brand = brand; }
        public virtual void Start()
        {
            Console.WriteLine($"{Brand} starts.");
        }
    }
    class Motorcycle : Vehicle2
    {
        public Motorcycle(string brand) : base(brand) { }
        public override void Start()
        {
            Console.WriteLine($"{Brand} roars as a motorcycle!");
        }
    }

    abstract class Animal
    {
        public string Name;
        public Animal(string name) { Name = name; }
        public abstract void MakeSound();
        public virtual void Sleep()
        {
            Console.WriteLine($"{Name} sleeps...");
        }
    }
    class Cat : Animal
    {
        public Cat(string name) : base(name) { }
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Meow!");
        }
        public override void Sleep()
        {
            base.Sleep();
            Console.WriteLine(this.Name +" skriker 'Snark!'");
        }
        public void Eat()
        {
            Console.WriteLine("nom nom nom");
        }
    }
    class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        public override void MakeSound()
        {
            base.Sleep(); // Anropar basklassens Sleep()
            Console.WriteLine($"{Name} says: Woof!");
        }
    }


}
