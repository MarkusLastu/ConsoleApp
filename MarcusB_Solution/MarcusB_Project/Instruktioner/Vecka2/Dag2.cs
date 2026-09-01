using System;
using System.Collections.Generic;
using System.Text;
using static MarcusB_Project.Instruktioner.Vecka2.Dag1;

namespace MarcusB_Project.Instruktioner.Vecka2
{
    internal class Dag2
    {
        public static void Ovn1_Main()
        {
            Vehicle myCar1 = new Vehicle("Volvo");
            myCar1.Drive();

            Car myCar2 = new Car("Saab");
            myCar2.Drive(); // Ärver Drive() från Vehicle
            myCar2.Honk(); // Egen metod i subklassen

            Motorcycle myMc1 = new Motorcycle("HD");
            myMc1.Start();

            Cat myCat1 = new Cat("Kissen");
            myCat1.MakeSound();
            myCat1.Sleep();

            Dog myDog1 = new Dog("Fido");
            myDog1.MakeSound();

            List<Animal> animals = new List<Animal> { myCat1, myDog1 };
            Console.WriteLine("----------- Lista med djur: -----------");
            foreach (Animal a in animals)
            {
                a.MakeSound(); // Samma metod, olika beteende
            }


        }




    }
}
