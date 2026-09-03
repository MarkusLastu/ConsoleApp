using System;
using System.Collections.Generic;
using System.Text;

namespace MarcusB_Project.Instruktioner.Vecka2
{
    // Utanför Program-klassen
    class Player
    {
        public string Name { get; set; }
        public int Position { get; private set; } = 0;

        //Konstruktor
        public Player(string name)
        {
            Name = name;
        }

        public void Move(int steps)
        {
            Position += steps;
            Console.WriteLine($"{Name} går {steps} steg, nu på {Position}");
        }



        public void SayHello()
        {
            Console.WriteLine($"Hej! Jag heter {Name}");
        }
    }

    class Dice
    {
        public int Roll()
        {
            return Random.Shared.Next(1, 7); // 1 till 6
        }

    }
    class ManaPool
    {
        public int Amount { get; private set; }
        public ManaPool(int start)
        {
            Amount = start;
        }
        public void Use(int cost)
        {
            Amount -= cost;
            Console.WriteLine($"Använde {cost} mana, kvar: {Amount}");
        }
    }
    class CombatService
    {
        public static void DealDamage(ref int health, int dmg)
        {
            health -= dmg;
            Console.WriteLine($"Skada: {dmg}, återstående hälsa: {health}");
        }
    }

    // -------------------------------------------------
    class WorldTime
    {
        public static int Day = 1;
    }
    class Farmer
    {
        public void Work()
        {
            Console.WriteLine($"Jobbar dag {WorldTime.Day}");
        }
    }
}
