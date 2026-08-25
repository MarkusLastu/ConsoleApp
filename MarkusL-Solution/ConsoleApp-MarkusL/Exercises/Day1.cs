

public class Day1
{
    public static void Exc1()
    {

        // Skapa ett Console - program som:
        // 1.Ber användaren att ange:
        //  o priset på en vara.
        //  o hur många varor som köps.
        // 2.Räknar ut:
        //  o Totalsumma.
        //  o moms(25 %)
        // 3.Skriver ut ett enkelt kvitto
        // Krav:
        //  • Använd decimal för pengar.
        //  • Använd int för antal.
        // • Använd TryParse.
        // • Ingen if / else.
        // • Skriv kommentar om varje rad(ovanför raden).



        int antalVaror = 0;
        decimal prisPerVara = 0;
        decimal pris = 0;
        decimal moms = 0;

        Console.WriteLine("Övning 1 - Räkna totalpris");

        Console.WriteLine("Ange pris per vara: ");

        //Läser in användarens svar
        decimal.TryParse(Console.ReadLine(), out prisPerVara);

        Console.WriteLine("Ange antal: ");
        //Läser in användarens svar
        int.TryParse(Console.ReadLine(), out antalVaror);

        pris = prisPerVara * antalVaror;
        moms = pris * 0.25m;


        Console.WriteLine("=========== KVITTO =========== ");
        Console.WriteLine("Du har köpt " + antalVaror + " grejjer för " + prisPerVara + " kr st.");
        Console.WriteLine("Pris: " + pris + " kr");
        Console.WriteLine("Moms: " + moms + " kr");
        Console.WriteLine("Att betala: " + (pris + moms) + " kr");
        Console.WriteLine("============================== ");

    }



    public static void Exc2()
    {
        // Skapa ett Console - program som:
        // 1.Ber användaren ange:
        // • antal timmar
        // • antal minuter
        // 2.Konverterar värdena till int.
        // 3.Räknar ut den totala tiden i minuter.
        // 4.Skriver ut resultatet.
        // 5.Skriv kommentar om varje rad(ovanför raden)
        // Krav:
        // • Använd int.TryParse.
        // • Ingen if / else.
        // • Resultatet ska lagras i en variabel.


        // Kommentar för att testa en ny pull request


        Console.WriteLine("Övning nummer 2 här!!!");
    }
}