using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Grupparbeten_Project;

public class V2_dag1
{
    public static void Ovn1_Main()
    {
        int usedMana = 0;
        int SpellCount = 0;

        Wizard p1 = new Wizard("Gandalf", 100);
        Wizard p2 = new Wizard("Merlin", 80);

        Wizard.ShowGlobalStats(p1, p2, SpellCount);

        Console.WriteLine(p1.Name + " kastar en mana spell på 20 mana.");
        usedMana = p1.CastSpell(20);
        SpellCount = Wizard.TotalSpellsCast(SpellCount);

        Wizard.ShowGlobalStats(p1, p2, SpellCount);

        Console.WriteLine(p2.Name + " tar emot 20 mana.");
        p2.ReceiveMana(usedMana);

        Wizard.ShowGlobalStats(p1, p2, SpellCount);

        // Merlin kastar två spells
        Console.WriteLine(p2.Name + " Kastar 2 spells: 20 resp. 10 mana.");
        p2.CastSpell(20);
        SpellCount = Wizard.TotalSpellsCast(SpellCount);

        p2.CastSpell(10);
        SpellCount = Wizard.TotalSpellsCast(SpellCount);

        Wizard.ShowGlobalStats(p1, p2, SpellCount);

        Console.WriteLine();
        Console.WriteLine("1.Varför påverkas inte Merlins mana när Gandalf kastar en trollformel ?");
        Console.WriteLine("Gandalf är objektet p1. Merlin är p2. Det är bara p1-objektet som uppdateras.");
        Console.WriteLine();
        Console.WriteLine("2.Varför räknas alla trollformler ihop i TotalSpellsCast ?");
        Console.WriteLine("Det är en statisk global räknare. När någon kastar så räknar vi upp med +1 ");
        Console.WriteLine();
        Console.WriteLine("3.Vad händer om TotalSpellsCast inte är static?");
        Console.WriteLine("Då blir det kompileringsfel. ");
        Console.WriteLine();
        Console.WriteLine("4.Vad skulle hända om Mana var static?");
        Console.WriteLine("Då kan vi inte koppla det till resp. objekt. Det hör till klassen Wizard då och gäller alla Wizards.");
        Console.WriteLine();
    }

    public static void Ovn2_Main()
    {
        Console.WriteLine("Övning 2 - Bibliotek");
        // Du är bibliotekarie i ett magiskt bibliotek. Det finns olika Böcker som kan läsas av
        // Läsare. Varje läsare har Energy som minskar när de läser. Det finns en statisk klass som
        // håller koll på totalt antal lästa böcker.


        Reader Reader1 = new Reader("Kalle");
        Reader Reader2 = new Reader("Bosse");

        Book Book1 = new Book("Den gamle och havet", 100);
        Book Book2 = new Book("Pippi", 66);

        //Reader1.ReadBook(Reader1.)


    }

}


public class Reader(string Name)
{
    string Name { get; set; } = Name;
    int Energy { get; set; } = 100;

    public void ReadBook(Reader reader, Book book)
    {
        Console.WriteLine(reader.Name + " läser boken: " + book);
    }
}

public class Book(string Title, int Pages)
{
    string Title { get; set; } = Title;
    int Pages { get; set; } = Pages;
}




public class Wizard
{
    // Skapa en klass som heter Wizard med Instansdel (hör till varje trollkarl)
    public string Name { get; set; } 
    public int CurrentManaLevel { get; set; } 

    public Wizard(string name, int mana)
    {
        this.Name = name;
        this.CurrentManaLevel = mana;
    }

    // Metoder:
    public int CastSpell(int cost)
    {
        if ((CurrentManaLevel -= cost) < 0)
        {
            Console.WriteLine(this.Name + " kan inte kasta denna spell. För lite mana.");
            return 0;
        }
        else
        {
            // Minskar trollkarlens Mana
            CurrentManaLevel -= cost;

            //Returnerar hur mycket mana som användes
            return cost;
        }
        
    }

    public void ReceiveMana(int amount)
    {
        //Ökar trollkarlens Mana
        CurrentManaLevel += amount;
    }

    // Lägg till statisk del i samma klass:
    // Statisk variabel:
    public static int TotalSpellsCast(int incomingSpellCount)
    {
        return incomingSpellCount + 1;
    }

    // Statisk metod:
    public static void ShowGlobalStats(Wizard p1, Wizard p2, int SpellCount)
    {
        //Skriver ut hur många trollformler som kastats totalt

        Console.WriteLine();
        Console.WriteLine("===============================================");
        Console.WriteLine("-------------------- STATS -------------------- ");

        Console.WriteLine();
        Console.WriteLine("Nuvarande mana-nivåer: ");
        Console.WriteLine(p1.Name + " har nu: " + p1.CurrentManaLevel + " mana.");
        Console.WriteLine(p2.Name + " har nu: " + p2.CurrentManaLevel + " mana.");

        Console.WriteLine();
        Console.WriteLine("Trollformler som kastats: ");
        Console.WriteLine(SpellCount + " st totalt.");

        Console.WriteLine("===============================================");

        Console.WriteLine();
        Console.ReadLine();

    }


}




