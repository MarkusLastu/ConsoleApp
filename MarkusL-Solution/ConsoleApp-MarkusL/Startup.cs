int useCase = 0;


if (useCase == 0)
{
    Console.WriteLine("Choose exercise:");
    Console.WriteLine("1 - Day1 - Exc1 Calculate price total");
    Console.WriteLine("2 - Day1 - Exc2 Calculate time");
    Console.WriteLine("3 - Day2 - Exc1 Temperature");
    Console.WriteLine("4 - Day2 - Exc2 Fruits");
    Console.WriteLine("5 - Day2 - Exc3 Mathematics");
    Console.WriteLine("6 - Day2 - Exc4 Password check");
    Console.WriteLine("7 - Day2 - Exc5 Menu choice");

    Console.Write("Your choice: ");
    useCase = int.Parse(Console.ReadLine());
}

switch (useCase)
{
    case 1: Day1.Exc1(); break;
    case 2: Day1.Exc2(); break;
    case 3: Day2.Exc1(); break;
    case 4: Day2.Exc2(); break;
    case 5: Day2.Exc3(); break;
    case 6: Day2.Exc4(); break;
    case 7: Day2.Exc5(); break;

    default:
        Console.WriteLine("Invalid choice.");
        break;
}