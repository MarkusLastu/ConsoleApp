using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbeten_Project.Vecka2
{
    internal class Dag2
    {
        public static void Ovn1_Main()
        {
            Console.WriteLine("V2.Dag2.Ovn1 - Simulera ett litet zoo.");


        }
    }



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

    // AnvändningVehicle car = new Vehicle("Volvo");car.Drive();

    class Car : Vehicle
    {

        public Car(string brand) : base(brand) { }

        public void Honk()

        {

            Console.WriteLine($"{Brand} honks: Beep!");

        }

    }

    // AnvändningCar myCar = new Car("Saab");myCar.Drive();myCar.Honk();

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

    // AnvändningVehicle2 bike = new Motorcycle("Yamaha");bike.Start();

}

