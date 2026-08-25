


int useCase = 0; /* Fyll i nummer på övning (Hårdkodat). Om 0, så får man välja varje körning */


if (useCase == 0)
{
    Console.WriteLine("Välj övning:");
    Console.WriteLine("1 - Dag1 - Räkna totalpris");
    Console.WriteLine("2 - Dag1 - Övning 2");
    Console.WriteLine("3 - Dag2 - Övning 1");
    Console.WriteLine("4 - Dag2 - Övning 2");

    Console.Write("Ditt val: ");
    useCase = int.Parse(Console.ReadLine());

}

switch (useCase)
{
    case 1: Dag1.Ovn1(); break;
    case 2: Dag1.Ovn2(); break;
    case 3: Dag2.Ovn2(); break;
    case 4: Dag2.Ovn2(); break;



    default:
        Console.WriteLine("Ogiltigt val.");
        break;
}