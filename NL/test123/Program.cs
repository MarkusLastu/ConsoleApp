public class Program
{

    public static void Main(string[] args)
    {


        int useCase = 41; /* Fyll i nummer på övning (Hårdkodat). Om 0, så får man välja varje körning */



        if (useCase == 0)
        {
            Console.WriteLine("Välj övning:");
            Console.WriteLine("11 - Dag1 - Ö1 - Räkna totalpris");
            Console.WriteLine("12 - Dag1 - Ö2 - Räkna minuter");
            Console.WriteLine("13 - Dag1 - Ö3 - Totalpris Smoothie");
            Console.WriteLine("14 - Dag1 - Ö4 - Räkna matkostnader");

            Console.WriteLine("21 - Dag2 - Ö1 - Temperaturkontroll");
            Console.WriteLine("22 - Dag2 - Ö2 - Fruktsortering med switch");
            Console.WriteLine("23 - Dag2 - Ö3 - Enkel räknesnurra");
            Console.WriteLine("24 - Dag2 - Ö4 - Kontrollera lösenordslängd");
            Console.WriteLine("25 - Dag2 - Ö5 - Interaktiv meny");

            Console.WriteLine("31 - Dag3 - Ö1 - ");
            Console.WriteLine("32 - Dag3 - Ö2 - ");
            Console.WriteLine("33 - Dag3 - Ö3 - ");
            Console.WriteLine("34 - Dag3 - Ö4 - ");

            Console.WriteLine("41 - Dag4 - Ö1 - ");
            Console.WriteLine("42 - Dag4 - Ö2 - ");


            Console.Write("Ditt val: ");
            useCase = int.Parse(Console.ReadLine());

        }

        switch (useCase)
        {
            /*case 11: Dag1.Ovn1(); break;
            case 12: Dag1.Ovn2(); break;
            case 13: Dag1.Ovn3(); break;
            case 14: Dag1.Ovn4(); break;

            case 21: Dag2.Ovn1(); break;
            case 22: Dag2.Ovn2(); break;
            case 23: Dag2.Ovn3(); break;
            case 24: Dag2.Ovn4(); break;
            case 25: Dag2.Ovn5(); break;

            case 31: Dag3.Ovn1(); break;
            case 32: Dag3.Ovn2(); break;
            case 33: Dag3.Ovn3(); break;
            case 34: Dag3.Ovn4(); break;*/

            case 41: Dag4.Ovn1(); break;
            /*case 42: Dag4.Ovn2(); break;
            case 43: Dag4.Ovn3(); break;
            case 44: Dag4.Ovn4(); break;*/
            //case 44: Dag4.Ovn4(); break;



            default:
                Console.WriteLine("Ogiltigt val.");
                break;
        }
    }

}