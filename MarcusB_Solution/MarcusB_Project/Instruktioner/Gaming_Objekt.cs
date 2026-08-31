namespace MarcusB_Project.Instruktioner;

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;




public class Game()
{
    public static void GameStart()
    {

        Person p = new Person("Anna");

        //Console.WriteLine(p.Name); // OK - kan lasa

        //p.Name = " Eva "; // ERROR ! Set ar private
    }
}


class Person
{
    public string Name { get; private set; }

    public Person(string name)
    {
        Name = name; // OK - inuti klassen
    }


    public void ChangeName(string newName)
    {
        Name = newName; // OK - inuti klassen
    }
}
class Player
{
    public void TakeTurn()
    {
        Dice dice = new Dice();
        int steps = dice.Roll();

        Console.WriteLine($"Går {steps} steg ");
    }
}

class Wizard
{
    public ManaPool Mana { get; set; }

    public Wizard()
    {
        Mana = new ManaPool(100);
    }

    public void CastSpell()
    {
        Mana.Use(20);
    }
}

class ManaPool
{
    public int Amount
    {
        get; private set;
    }

    public ManaPool(int
   start)
    {
        Amount = start;
    }

    public void Use(int
   cost)
    {
        Amount -= cost;
    }
}

class Dice
{
    public int Roll()
    {
        return Random.Shared.Next(1, 7);
    }
}

class CombatService
{
    public static void DealDamage(Character target, int dmg)
    {
        target.Health -= dmg;
    }
}

class DamageControl()
{

}

class Character
{
    public int Health { get; set; }
};

    

