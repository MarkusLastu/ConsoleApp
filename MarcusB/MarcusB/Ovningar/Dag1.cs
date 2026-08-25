

public class Dag1
{
    public static void Ovn1()
    {

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
        Console.WriteLine("Övning nummer 2 här!!!");
    }
}