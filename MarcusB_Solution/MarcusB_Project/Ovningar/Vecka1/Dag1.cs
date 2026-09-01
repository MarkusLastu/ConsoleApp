namespace MarcusB_Project.Ovningar.Vecka1;

using System.Runtime.ConstrainedExecution;

public class Dag1
{
    public static void Ovn1()
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



    public static void Ovn2()
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


        Console.WriteLine("Övning nummer 2");

        int hours = 0;
        int minutes = 0;
        int totalMinutes = 0;

        Console.WriteLine("Ange antal timmar: ");
        int.TryParse(Console.ReadLine(), out hours);

        Console.WriteLine("Ange antal minuter: ");
        int.TryParse(Console.ReadLine(), out minutes);

        totalMinutes = (hours * 60) + minutes;

        Console.WriteLine("Total tid i minuter: " + totalMinutes);
    }


    public static void Ovn3()
    {
        //Skapa ett Console - program som:
        //1. Ber användaren ange:
        //o pris per smoothi i kronor
        //o antal smoothisar
        //2. Konverterar värdena till:
        //o decimal (pris)
        //o int (antal)
        //3. Räknar ut:
        //o totalpriset
        //4.Konverterar totalpriset till string
        //5. Skriver ut resultatet med ett tydligt meddelande och med
        //konkatineringsmetoden.
        //Krav:
        //• Använd decimal.TryParse
        //• Använd int.TryParse
        //• Använd ToString()
        //• Ingen if / else
        //• Kommentar ovanför varje rad

        Console.WriteLine("Övning 3 - Räkna totalpris Smoothie");

        decimal prisPerSmoothi = 0;
        int antalSmoothisar = 0;
        decimal totalPris = 0;

        Console.WriteLine("Ange pris per smoothi: ");
        decimal.TryParse(Console.ReadLine(), out prisPerSmoothi);

        Console.WriteLine("Ange antal smoothisar: ");
        int.TryParse(Console.ReadLine(), out antalSmoothisar);

        totalPris = prisPerSmoothi * antalSmoothisar;

        Console.WriteLine("Totalt pris för allt blir: " + totalPris); ;









    }

    public static void Ovn4()
    {


        //Skapa ett Console-program som:
        //1. Ber användaren ange:
        //• kostnad för frukost.
        //• kostnad för lunch.
        //• kostnad för middag.
        //2. Konverterar värdena till decimal.
        //3. Räknar ut den genomsnittliga kostnaden.
        //4. Skriver ut resultatet.
        //Krav:
        //• Använd Convert.ToDecimal().
        //• Ingen if / else.
        //• Alla värden ska lagras i variabler.
        //• Skriv kommentar om varje rad (ovanför raden)

        Console.WriteLine("Övning 4 - Räkna matkostnader");

        decimal frukostKostnad = 0;
        decimal lunchKostnad = 0;
        decimal middagKostnad = 0;
        decimal genomsnittKostnad = 0;

        Console.WriteLine("Vad kostar frukosten?");
        frukostKostnad = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Vad kostar lunchen?");
        lunchKostnad = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Vad kostar middagen?");
        middagKostnad = Convert.ToDecimal(Console.ReadLine());

        // Beräkna medelvärdet
        genomsnittKostnad = (frukostKostnad + lunchKostnad + middagKostnad) / 3;

        Console.WriteLine("Den genomsnittliga kostnaden för måltiderna är: " + genomsnittKostnad + " kr");


    }


}