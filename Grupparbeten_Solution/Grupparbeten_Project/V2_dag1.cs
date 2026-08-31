using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbeten_Project;

public class V2_dag1
{
    public static void Ovn1_Main()
    {
        Wizard p1 = new Wizard("Gandalf");
        Wizard p2 = new Wizard("Börje");
    }

}

public class Wizard(string Name)
{
    // Skapa en klass som heter Wizard med Instansdel (hör till varje trollkarl)
    string Name { get; set; } = Name;
    int Mana { get; set; } = 100;


    // Metoder:
    public int CastSpell(int cost)
    {
        // Minskar trollkarlens Mana
        Mana = Mana - cost;

        //Returnerar hur mycket mana som användes
        return CastSpell(cost);
    }

    public void ReceiveMana(int amount)
    {
        //Ökar trollkarlens Mana
        Mana = Mana + amount;
    }
    
    // Lägg till statisk del i samma klass:
    // Statisk variabel:
    public static int TotalSpellsCast(int incomingSpellCount){
        
        return incomingSpellCount + 1;

         
    }
    // Statisk metod:
    public static void ShowGlobalStats()
    {
        //Skriver ut hur många trollformler som kastats totalt
        Console.WriteLine("Trollformler som kastats: ");
    }






}


