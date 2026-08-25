


int useCase = 3; /* Fyll i nummer på övning (Hårdkodat). Om 0, så får man välja varje körning */


if (useCase == 0)
{
    Console.WriteLine("Välj övning:");
    Console.WriteLine("1 - Dag1 - Räkna totalpris");
    Console.WriteLine("2 - Dag1 - Räkna minuter");
    Console.WriteLine("3 - Dag1 - Totalpris Smoothie");
    Console.WriteLine("4 - Dag1 - Räkna matkostnader");
    Console.WriteLine("5 - Dag2 - Övning 1");
    Console.WriteLine("6 - Dag2 - Övning 2");

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



    default:
        Console.WriteLine("Ogiltigt val.");
        break;
}