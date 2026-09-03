using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;
using MarcusB_Project.Funktioner;


namespace MarcusB_Project.Instruktioner.Vecka2
{
    internal class Dag1
    {
        public static void Ovn1_Main()
        {
            // Det finns enbart publika metoder och variabler i den klassen.
            // Det betyder att vi måste instantiera klassen för att kunna nå dessa metoder.
            Car myCar = new Car { Brand = "Volvo", Speed = 0 };//Skapa objektet

            myCar.StartEngine(); // Sätt egenskapen

            myCar.StartAndDrive(50);

            // Anropa statisk metod via klassnamn
            Car.CarInfo();


            Car myCar2 = new Car { Brand = "BMW", Speed = 0 };
            myCar2.StartAndDrive(30);

            // --------------------------- //





            Console.ReadLine(); // håller konsolfönstret öppet

        }



        public static void Ovn2_Main()
        {
            // Använd statiska metoder direkt via klassnamn
            int sum = SimpleMathClass.AddMethod(5, 7);
            int product = SimpleMathClass.MultiplyMethod(3, 4);

            Console.WriteLine($"Summa: {sum}");
            Console.WriteLine($"Produkt: {product}");

            // Skapa objekt för att använda instansmetoder
            SimpleMathClass mathObj = new SimpleMathClass();

            mathObj.SubtractMethod(10, 3); // ändrar LastResult
            mathObj.DivideMethod(20, 4); // ändrar LastResult
            Console.WriteLine($"Senaste resultat lagrat i objektet:{mathObj.LastResultInstance}");


            // --------------------------- //

            // Ligger i filen Calculations.cs
            SimpleMathClass mathObj2 = new SimpleMathClass();

            // math1 räknar ut ett värde
            int resultFromMath1 = SimpleMathClass.AddMethod(5, 3); // 8

            // resultatet används som input i math2
            int finalResult = SimpleMathClass.MultiplyMethod(resultFromMath1, 2); // 16
            Console.WriteLine("Resultatet används som input i math2" + finalResult);

        }

        public static void Ovn3_Main_Game()
        {
            Player p1 = new Player("Alice");
            p1.SayHello(); // Output: Hej! Jag heter Alice

            Player p2 = new Player("Bob");
            p2.SayHello(); // Output: Hej! Jag heter Bob

            // Vart ska detta vara? Inte här gissar jag.
            Dice dice = new Dice();
            int result = dice.Roll();
            Console.WriteLine($"Tärningskast: {result}");

            ManaPool mp = new ManaPool(50);
            mp.Use(10); // Output: Använde 10 mana, kvar: 40

            int health = 100;

            CombatService.DealDamage(ref health, 25); // Output: Skada: 25, återstående hälsa: 75

            int steps = dice.Roll();
            p1.Move(steps); // Alice går X steg
            steps = dice.Roll();
            p2.Move(steps); // Bob går Y steg



        }


        public static void Ovn4_Main_WorldTime()
        {
            Farmer f1 = new Farmer();
            Farmer f2 = new Farmer();
            f1.Work(); // Jobbar dag 1
            WorldTime.Day++;
            f2.Work(); // Jobbar dag 2
        }


        public class Car
        {
            public string Brand { get; set; }
            public double Speed { get; set; }
            public void StartEngine()
            {
                Console.WriteLine($"{Brand} motorn startade!");
            }

            public static void CarInfo()
            {
                Console.WriteLine("Alla bilar har 4 hjul.");
            }


            // Instansmetod 2: öka hastighet
            public void Accelerate(int increase)
            {
                Speed += increase; // ändrar objektets tillstånd
                Console.WriteLine($"{Brand} kör nu i {Speed} km/h");

            }

            // Instansmetod 3: anropar Accelerate inifrån en annan metod
            public void StartAndDrive(int startSpeed)
            {
                StartEngine(); // anropar en annan metod i samma objekt
                Accelerate(startSpeed); // påverkar objektets Speed

            }
        }
    }


}