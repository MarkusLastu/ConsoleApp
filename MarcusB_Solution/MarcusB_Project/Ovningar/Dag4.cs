using System.Threading.Tasks.Sources;
using MarcusB_Project.Funktioner;


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


        int antalGissningar = 0;
        int gissning = 0;
        int gissningarKvar = 0;


        Console.WriteLine("Jag kommer tänka på ett hemligt tal.");

        Console.Write("");
        int minTal = Calculations.HeltalParsing("Ange minsta möjliga det talet ska vara: ");

        Console.Write("");
        int maxTal = Calculations.HeltalParsing("Ange största möjliga det talet ska vara: ");

        Console.WriteLine();
        Console.WriteLine("OK. Jag tänker på ett hemligt tal mellan " + minTal + " och " + maxTal + ": ");
        int maxAntalGissningar = Calculations.HeltalParsing("Hur många gissningar vill du ha? ");
        gissningarKvar = maxAntalGissningar - 1;

        // Generera ett hemligt tal
        Random rnd = new Random();
        int hemligtTal = rnd.Next(minTal, maxTal + 1); // +1 för att inkludera maxTal

        for (int i = 0; i < maxAntalGissningar; i++)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("Försök " + (i + 1) + " av " + maxAntalGissningar);
            Console.WriteLine("----------------------------------------------------------");
            gissning = Calculations.HeltalParsing("Vad gissar du att det hemliga talet är? ");

            Console.WriteLine();

            if (gissning > hemligtTal)
            {
                Console.WriteLine("Du gissade för högt! Det hemliga talet är lägre än " + gissning + ".");
                if (gissningarKvar == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("Tyvärr, du har inga försök kvar. Det hemliga talet var " + hemligtTal + ".");
                    Console.WriteLine("==========================================================");
                    break;
                }
                else
                {
                    Console.WriteLine("Du har " + gissningarKvar + " försök kvar.");
                }
            }
            else if (gissning < hemligtTal)
            {
                Console.WriteLine("Du gissade för lågt! Det hemliga talet är högre än " + gissning + ".");
                if (gissningarKvar == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("Tyvärr, du har inga försök kvar. Det hemliga talet var " + hemligtTal + ".");
                    Console.WriteLine("==========================================================");
                    break;
                }
                else
                {
                    Console.WriteLine("Du har " + gissningarKvar + " försök kvar.");
                }
            }
            else
            {
                Console.WriteLine("Grattis! Du gissade rätt! Det hemliga talet var " + hemligtTal + ".");
                break;
            }
            ;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();
            gissningarKvar--;

        }



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


        List<string> names = new List<string>
        {
            "Alice",
            "Bob",
            "Charlie",
            "Diana",
            "Erik",
            "Fatima",
            "Gustav",
            "Hanna",
            "Isak",
            "Julia"
        };

        List<int> scores = new List<int>
        {
            85,
            62,
            74,
            91,
            68,
            77,
            55,
            70,
            83,
            49
        };

        Console.WriteLine();
        


        int i = 0;

        Console.WriteLine();
        Console.WriteLine("-------------------------------------------");
        int passingPoints = Calculations.HeltalParsing("Ange poänggräns för att klara kursen (t.ex. 70): ");
        Console.WriteLine("-------------------------------------------");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Studenter som klarade kursen (poäng ≥ " + passingPoints + "):");
        Console.WriteLine("-------------------------------------------");
        foreach (var score in scores)
        {
            if(score >= passingPoints)
            {
                Console.WriteLine(names[i] + " - " + score+" poäng.");
            }
            i++;
        }

        Console.WriteLine("-------------------------------------------");



    }
}