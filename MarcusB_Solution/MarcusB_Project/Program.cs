


int useCase = 8; /* Fyll i nummer på övning (Hårdkodat). Om 0, så får man välja varje körning */


if (useCase == 0)
{
    Console.WriteLine("Välj övning:");
    Console.WriteLine("1 - Dag1 - Övn1 - Räkna totalpris");
    Console.WriteLine("2 - Dag1 - Övn2 - Räkna minuter");
    Console.WriteLine("3 - Dag1 - Övn3 - Totalpris Smoothie");
    Console.WriteLine("4 - Dag1 - Övn4 - Räkna matkostnader");
    Console.WriteLine("5 - Dag2 - Övn1 - Temperaturkontroll");
    Console.WriteLine("6 - Dag2 - Övn2 - Fruktsortering med switch");
    Console.WriteLine("7 - Dag2 - Övn3 - Enkel räknesnurra");
    Console.WriteLine("8 - Dag2 - Övn4 - Kontrollera lösenordslängd");
    Console.WriteLine("9 - Dag2 - Övn5 - Interaktiv meny");

    Console.Write("Ditt val: ");
    useCase = int.Parse(Console.ReadLine());

}

switch (useCase)
{
    case 1: Dag1.Ovn1(); break;
    case 2: Dag1.Ovn2(); break;
    case 3: Dag1.Ovn3(); break;
    case 4: Dag1.Ovn4(); break;
    case 5: Dag2.Ovn1(); break;
    case 6: Dag2.Ovn2(); break;
    case 7: Dag2.Ovn3(); break;
    case 8: Dag2.Ovn4(); break;
    case 9: Dag2.Ovn5(); break;
    case 10: Dag3.Ovn1(); break; 
    case 11: Dag3.Ovn2(); break;
    case 12: Dag3.Ovn3(); break;


    default:
        Console.WriteLine("Ogiltigt val.");
        break;
}