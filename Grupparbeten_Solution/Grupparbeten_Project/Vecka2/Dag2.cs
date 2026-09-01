using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Grupparbeten_Project.Vecka2
{
    internal class Dag2
    {
        public static void Ovn1_Main()
        {
            Console.WriteLine("V2.Dag2.Ovn1 - Simulera ett litet zoo."); Console.WriteLine();
            Console.WriteLine("Hur många djur vill du ha i ditt zoo?"); int numberOfAnimals = int.Parse(Console.ReadLine());
            List<Animal> AnimalList = new List<Animal>();
            for (int i = 0; i < numberOfAnimals; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Vad heter djur nummer " + (i + 1) + "/" + numberOfAnimals + "?");
                string animalName = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Vad är djurets typ?");
                Console.WriteLine("1 - Lejon?");
                Console.WriteLine("2 - Elefant?");
                Console.WriteLine("3 - Papegoja?");

                int animalType = 0;

                bool isNumeric = int.TryParse(Console.ReadLine(), out animalType);

                while (!isNumeric || animalType < 1 || animalType > 3)
                {
                    Console.WriteLine("Ogiltig inmatning. Ange ett nummer mellan 1 och 3.");
                    Console.WriteLine();
                    isNumeric = int.TryParse(Console.ReadLine(), out animalType);
                }

                switch (animalType)
                {
                    case 1: AnimalList.Add(new Lion(animalName)); break;
                    case 2: AnimalList.Add(new Elephant(animalName)); break;
                    case 3: AnimalList.Add(new Parrot(animalName)); break;
                }

            }

            foreach (Animal animal in AnimalList)
            {
                animal.MakeSound();
                animal.Eat();
                animal.Sleep();
                Console.WriteLine();
            }



        }
    }



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

    // AnvändningCar myCar = new Car("Saab");myCar.Drive();myCar.Honk();

    /* class Vehicle2
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

     }*/

    // AnvändningVehicle2 bike = new Motorcycle("Yamaha");bike.Start();

}

