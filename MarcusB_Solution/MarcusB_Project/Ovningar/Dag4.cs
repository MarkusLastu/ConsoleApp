public class Dag4
{
    public static void Ovn1()
    {

        Console.WriteLine("Övning 1 - Temperaturkontroll");

        //1) Du ska skriva ett program som:
        //• Låter användaren mata in ett antal temperaturvärden(t.ex. 5–10 värden).
        //• Sparar varje inmatning i en lista.
        //a.Beräknar och skriver ut:
        //b.Medeltemperaturen list.Average()
        //c.Det högsta och lägsta värdet, list.Min(), list.Max().
        //d.Antal temperaturer över ett visst värde(t.ex. 25 grader)
        //Krav:
        //• Använd for-loop för inmatning.
        //• Använd List<int> för att spara värdena.
        //• Hantera felaktig inmatning med try-catch (t.ex.om användaren skriver
        //text istället för ett heltal).




        int nyTemp = 0;
        double medelTemp = 0;
        int maxTemp = 0;
        int minTemp = 0;
        int gransVarde = 0;
        int antalOverGrans = 0;
        int antalTemperaturer = 0;

        List<int> tempLista = new List<int>();


        while (true)
        {
            Console.WriteLine();

            try
            {
                Console.Write("Ange antal temperaturer att mata in: ");
                antalTemperaturer = int.Parse(Console.ReadLine());
                Console.WriteLine();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ange antalet med heltal!");
            }
        }

        for (int i = 0; i < antalTemperaturer; i++)
        {
            Console.WriteLine();
            Console.Write("Ange temperatur nr " + (i + 1) + " av totalt " + antalTemperaturer + ": ");
            try
            {
                nyTemp = int.Parse(Console.ReadLine());
                tempLista.Add(nyTemp);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ange temperaturen med heltal!");
                i--;
            }
        }


        Console.WriteLine();
        Console.WriteLine(tempLista.Count + " temperaturer inlagda.");

        while (true)
        {
            Console.WriteLine();
            Console.Write("Ange ett gränsvärde för att räkna antal temperaturer över detta värde: ");

            try
            {
                gransVarde = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Ange gränsvärdet med heltal!");
            }
        }


        maxTemp = tempLista.Max();
        minTemp = tempLista.Min();
        medelTemp = tempLista.Average();

        antalOverGrans = tempLista.Where(x => x > gransVarde).Count();

        Console.WriteLine();
        Console.WriteLine("-------------- HELA LISTAN --------------");
        foreach (int i in tempLista)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("Totalt antal temperaturer: " + tempLista.Count());
        Console.WriteLine("Högsta värde: " + maxTemp);
        Console.WriteLine("Lägsta värde: " + minTemp);
        Console.WriteLine("Medelvärde: " + medelTemp);
        Console.WriteLine("Antal temperaturer över gränsvärde: " + antalOverGrans);
        Console.WriteLine("-----------------------------------------");

    }



    public static void Ovn2()
    {
        Console.WriteLine("Övning 2 Slumpa fram ett hemligt tal");

        //2) Programmet ska slumpa fram ett hemligt tal mellan 1 och 50.
        //• Användaren får max 7 försök att gissa talet.
        //• Efter varje gissning ska programmet skriva ut:
        //• “För högt” om gissningen är större än talet
        //• “För lågt” om gissningen är mindre än talet
        //• “Rätt!” om gissningen stämmer
        //• Om användaren gissar rätt avslutas loopen direkt.
        //• Programmet ska även hantera felaktig inmatning(icke-nummer).
        //Talet kan slumpas med nedanstående procedur:
        //  Random rnd = new Random();
        //        int secret = rnd.Next(1, 51); // 1–50




    }



    public static void Ovn3()
    {
        Console.WriteLine("Övning 3 Filtrera studenter med poäng ≥ 70.");

        //3) 
        //Krav:
        //• Skapa två listor:
        //o names – med studentnamn.
        //o scores – med poäng, där varje poäng motsvarar samma index i names.
        //• Använd en foreach-loop för att gå igenom alla poäng i listan scores.
        //• Använd en räknare(i) för att hålla koll på vilket namn som matchar varje
        //poäng.
        //• Använd en if-sats för att filtrera de studenter som har poäng ≥ 70.
        //• Skriv ut varje student som klarade kursen, t.ex



    }
}