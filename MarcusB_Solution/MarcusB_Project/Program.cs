
namespace MarcusB_Project;

using MarcusB_Project.Ovningar;
using V1 = MarcusB_Project.Ovningar.Vecka1;
using V2 = MarcusB_Project.Ovningar.Vecka2;
using V2i = MarcusB_Project.Instruktioner.Vecka2;

public class Program
{
    static void Main(string[] args)
    {
        string useCase = "i222"; /* Fyll i nummer på övning (Hårdkodat). Om 0, så får man välja varje körning */


        if (useCase.Equals("0"))
        {
            Console.WriteLine("Välj övning:");
            Console.WriteLine("v111 - Dag1 - Övn1 - Räkna totalpris");
            Console.WriteLine("o12 - Dag1 - Övn2 - Räkna minuter");
            Console.WriteLine("o13 - Dag1 - Övn3 - Totalpris Smoothie");
            Console.WriteLine("o14 - Dag1 - Övn4 - Räkna matkostnader");
            Console.WriteLine("o21 - Dag2 - Övn1 - Temperaturkontroll");
            Console.WriteLine("o22 - Dag2 - Övn2 - Fruktsortering med switch");
            Console.WriteLine("o23 - Dag2 - Övn3 - Enkel räknesnurra");
            Console.WriteLine("o24 - Dag2 - Övn4 - Kontrollera lösenordslängd");
            Console.WriteLine("o25 - Dag2 - Övn5 - Interaktiv meny");
            Console.WriteLine("o31 - Dag3 - Övn1 - ");
            Console.WriteLine("o41 - Dag4 - Övn1 - ");
            Console.WriteLine("o42 - Dag4 - Övn2 - ");
            Console.WriteLine("40bi - ImporteraFiler - ");

            Console.WriteLine("i1 - Gaming - ");

            Console.WriteLine("91 - ImporteraFiler - ");


            Console.Write("Ditt val: ");
            useCase = Console.ReadLine();

        }

        switch (useCase)
        {
            // Övningar
            case "v111": V1.Dag1.Ovn1(); break;
            case "o12": V1.Dag1.Ovn2(); break;
            case "o13": V1.Dag1.Ovn3(); break;
            case "o14": V1.Dag1.Ovn4(); break;

            case "o21": V1.Dag2.Ovn1(); break;
            case "o22": V1.Dag2.Ovn2(); break;
            case "o23": V1.Dag2.Ovn3(); break;
            case "o24": V1.Dag2.Ovn4(); break;
            case "o25": V1.Dag2.Ovn5(); break;

            case "o31": V1.Dag3.Ovn1(); break;
            case "o32": V1.Dag3.Ovn2(); break;
            case "o33": V1.Dag3.Ovn3(); break;

            case "o41": V1.Dag4.Ovn1(); break;
            case "o42": V1.Dag4.Ovn2(); break;
            case "o43": V1.Dag4.Ovn3(); break;

            case "o4bi1": V1.Dag4b.Info1(); break;
            case "o4bi2": V1.Dag4b.Info2_LasInRaderFranFil("Countries_area.txt"); break; // eller "Countries.txt"
            case "o4bi3": V1.Dag4b.Info3_LasInKolumnNamnFranFil("Countries_area.txt"); break;
            case "o4b1": V1.Dag4b.Ovn1("Countries.txt"); break;
            case "o4b2": V1.Dag4b.Ovn2("Countries_area.txt"); break;

            case "v211": V2.Dag1.Ovn1(); break;


            // Instruktioner
            case "i211": V2i.Dag1.Ovn1_Main(); break;
            case "i212": V2i.Dag1.Ovn2_Main(); break;
            case "i213": V2i.Dag1.Ovn3_Main_Game(); break;
            case "i214": V2i.Dag1.Ovn4_Main_WorldTime(); break;

            case "i221": V2i.Dag2.Ovn1_Main(); break;
            case "i222": V2i.Dag2.Ovn2_Main(); break;


            //case "i1": Game.GameStart(); break;








            // Fredagsmys



            // Övrigt
            case "91": ImporteraFiler.ReadFiles("Countries.txt"); break;



            default:
                Console.WriteLine("Ogiltigt val.");
                break;
        }
    }





}