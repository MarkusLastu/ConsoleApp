
public class Program
{
    static void Main(string[] args)
    {
        string useCase = "4b1"; /* Fyll i nummer på övning (Hårdkodat). Om 0, så får man välja varje körning */


        if (useCase.Equals("0"))
        {
            Console.WriteLine("Välj övning:");
            Console.WriteLine("11 - Dag1 - Övn1 - Räkna totalpris");
            Console.WriteLine("12 - Dag1 - Övn2 - Räkna minuter");
            Console.WriteLine("13 - Dag1 - Övn3 - Totalpris Smoothie");
            Console.WriteLine("14 - Dag1 - Övn4 - Räkna matkostnader");
            Console.WriteLine("21 - Dag2 - Övn1 - Temperaturkontroll");
            Console.WriteLine("22 - Dag2 - Övn2 - Fruktsortering med switch");
            Console.WriteLine("23 - Dag2 - Övn3 - Enkel räknesnurra");
            Console.WriteLine("24 - Dag2 - Övn4 - Kontrollera lösenordslängd");
            Console.WriteLine("25 - Dag2 - Övn5 - Interaktiv meny");
            Console.WriteLine("31 - Dag3 - Övn1 - ");
            Console.WriteLine("41 - Dag4 - Övn1 - ");
            Console.WriteLine("42 - Dag4 - Övn2 - ");
            Console.WriteLine("40bi - ImporteraFiler - ");

            Console.WriteLine("91 - ImporteraFiler - ");


            Console.Write("Ditt val: ");
            useCase = Console.ReadLine();

        }

        switch (useCase)
        {
            case "11": Dag1.Ovn1(); break;
            case "12": Dag1.Ovn2(); break;
            case "13": Dag1.Ovn3(); break;
            case "14": Dag1.Ovn4(); break;

            case "21": Dag2.Ovn1(); break;
            case "22": Dag2.Ovn2(); break;
            case "23": Dag2.Ovn3(); break;
            case "24": Dag2.Ovn4(); break;
            case "25": Dag2.Ovn5(); break;

            case "31": Dag3.Ovn1(); break;
            case "32": Dag3.Ovn2(); break;
            case "33": Dag3.Ovn3(); break;

            case "41": Dag4.Ovn1(); break;
            case "42": Dag4.Ovn2(); break;
            case "43": Dag4.Ovn3(); break;

            case "4bi1": Dag4b.Info1(); break;
            case "4bi2": Dag4b.Info2_LasInRaderFranFil("Countries_area.txt"); break; // eller "Countries.txt"
            case "4bi3": Dag4b.Info3_LasInKolumnNamnFranFil("Countries_area.txt"); break;
            case "4b1": Dag4b.Ovn1("Countries.txt"); break;



            case "91"   : ImporteraFiler.ReadFiles("Countries.txt"); break;



            default:
                Console.WriteLine("Ogiltigt val.");
                break;
        }
    }





}