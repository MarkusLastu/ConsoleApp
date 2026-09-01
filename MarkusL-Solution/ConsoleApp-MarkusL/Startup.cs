using Week1 = ConsoleApp_MarkusL.Exercises.Week1;
using Week2 = ConsoleApp_MarkusL.Exercises.Week2;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("--- HUVUDMENY ---");
        Console.WriteLine("1 - Week 1");
        Console.WriteLine("2 - Week 2");
        Console.Write("\nChoose week: ");

        if (int.TryParse(Console.ReadLine(), out int weekChoice))
        {
            Console.Clear();

            switch (weekChoice)
            {
                case 1:
                    RunWeek1();
                    break;
                case 2:
                    RunWeek2();
                    break;
                default:
                    Console.WriteLine("Invalid week choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private static void RunWeek1()
    {
        Console.WriteLine("--- WEEK 1 EXERCISES ---");
        Console.WriteLine("1 - Day1 - Exc1 Calculate price total");
        Console.WriteLine("2 - Day1 - Exc2 Calculate time");
        Console.WriteLine("3 - Day2 - Exc1 Temperature");
        Console.WriteLine("4 - Day2 - Exc2 Fruits");
        Console.WriteLine("5 - Day2 - Exc3 Mathematics");
        Console.WriteLine("6 - Day2 - Exc4 Password check");
        Console.WriteLine("7 - Day2 - Exc5 Menu choice");
        Console.WriteLine("8 - Day3_4 Exc1 Movie list");
        Console.WriteLine("9 - Day3_4 Exc2 Filter numbers");
        Console.WriteLine("10 - Day3_4 Exc3 Animal register");
        Console.WriteLine("11 - Day3_4 Exc4 High scores");
        Console.WriteLine("12 - Day5 Exc1 Analyze column");
        Console.WriteLine("13 - Day5 Exc2 Convert area (km2 to m2)");
        Console.WriteLine("14 - Day5 Exc3 Analyze GDP and currencies");

        Console.Write("\nYour choice: ");

        if (int.TryParse(Console.ReadLine(), out int useCase))
        {
            switch (useCase)
            {
                case 1: Week1.Day1.Exc1(); break;
                case 2: Week1.Day1.Exc2(); break;
                case 3: Week1.Day2.Exc1(); break;
                case 4: Week1.Day2.Exc2(); break;
                case 5: Week1.Day2.Exc3(); break;
                case 6: Week1.Day2.Exc4(); break;
                case 7: Week1.Day2.Exc5(); break;
                case 8: Week1.Day3_4.Exc1(); break;
                case 9: Week1.Day3_4.Exc2(); break;
                case 10: Week1.Day3_4.Exc3(); break;
                case 11: Week1.Day3_4.Exc4(); break;
                case 12: Week1.Day5.Exc1(); break;
                case 13: Week1.Day5.Exc2(); break;
                case 14: Week1.Day5.Exc3(); break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    private static void RunWeek2()
    {
        Console.WriteLine("--- WEEK 2 EXERCISES ---");
        Console.WriteLine("1 - Day1 - Exc1 XYZXYZ");
        Console.WriteLine("1 - Day2 - Exc1 XYZXYZ");

        Console.Write("\nYour choice: ");

        if (int.TryParse(Console.ReadLine(), out int useCase))
        {
            switch (useCase)
            {
                case 1: Week2.Day1.Exc1(); break;
                case 2: Week2.Day2.Exc1(); break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
}