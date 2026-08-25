public class Day2
{
    public static void Exc1()
    {
        Console.Write("Enter the temperature in degrees Celsius: ");
        string tempInput = Console.ReadLine();
        int temp;

        if (int.TryParse(tempInput, out temp))
        {
            if (temp < 0)
            {
                Console.WriteLine("It is freezing");
            }
            else if (temp >= 0 && temp <= 20)
            {
                Console.WriteLine("A bit chilly");
            }
            else
            {
                Console.WriteLine("It is warm");
            }

            Console.Write("Enter a comment about the weather: ");
            string comment = Console.ReadLine();

            Console.WriteLine($"Your comment: {comment.Trim().ToUpper()}");
        }
        else
        {
            Console.WriteLine("Invalid input, you must enter a number.");
        }
    }

    public static void Exc2()
    {
        Console.Write("Enter the name of a fruit: ");
        string fruit = Console.ReadLine().Trim().ToLower();

        switch (fruit)
        {
            case "apple":
            case "pear":
            case "banana":
                Console.WriteLine("Common fruit");
                break;

            case "mango":
            case "kiwi":
                Console.WriteLine("Exotic fruit");
                break;

            default:
                Console.WriteLine("Unknown fruit");
                break;
        }
    }

    public static void Exc3()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Add two numbers");
        Console.WriteLine("2. Subtract two numbers");
        Console.WriteLine("3. Square a number");
        Console.WriteLine("4. Exit");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter the first number: ");
                int add1 = int.Parse(Console.ReadLine());
                Console.Write("Enter the second number: ");
                int add2 = int.Parse(Console.ReadLine());
                Console.WriteLine($"Result: {add1 + add2}");
                break;

            case "2":
                Console.Write("Enter the first number: ");
                int sub1 = int.Parse(Console.ReadLine());
                Console.Write("Enter the second number: ");
                int sub2 = int.Parse(Console.ReadLine());
                Console.WriteLine($"Result: {sub1 - sub2}");
                break;

            case "3":
                Console.Write("Enter a number to square: ");
                int numberToSquare = int.Parse(Console.ReadLine());
                Console.WriteLine($"Result: {numberToSquare * numberToSquare}");
                break;

            case "4":
                Console.WriteLine("Exiting...");
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
    public static void Exc4()
    {
        Console.Write("Enter a password: ");
        string password = Console.ReadLine();

        if (string.IsNullOrEmpty(password))
        {
            Console.WriteLine("No password provided");
        }
        else if (password.Length < 6)
        {
            Console.WriteLine("Password is too short");
            Console.WriteLine($"Character count: {password.Length}");
        }
        else
        {
            Console.WriteLine("Password accepted");
            Console.WriteLine($"Character count: {password.Length}");
        }
    }

    public static void Exc5()
    {
        Console.WriteLine("Choose what you want to do:");
        Console.WriteLine("1. Check temperature");
        Console.WriteLine("2. Check word");
        Console.WriteLine("3. Exit");

        string menuChoice = Console.ReadLine();

        switch (menuChoice)
        {
            case "1":
                Console.Write("Enter a temperature in degrees Celsius: ");
                string inputTemp = Console.ReadLine();

                if (int.TryParse(inputTemp, out int degrees))
                {
                    if (degrees < 10)
                    {
                        Console.WriteLine("Cold");
                    }
                    else if (degrees >= 10 && degrees <= 25)
                    {
                        Console.WriteLine("Moderate");
                    }
                    else
                    {
                        Console.WriteLine("Warm");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. You must enter a number.");
                }
                break;

            case "2":
                Console.Write("Enter any word: ");
                string word = Console.ReadLine().Trim().ToUpper();

                if (word.Length < 7)
                {
                    Console.WriteLine($"The word '{word}' is short.");
                }
                else
                {
                    Console.WriteLine($"The word '{word}' is long.");
                }

                Console.WriteLine($"The word contains {word.Length} characters.");
                break;

            case "3":
                Console.WriteLine("Program is exiting. Goodbye!");
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}