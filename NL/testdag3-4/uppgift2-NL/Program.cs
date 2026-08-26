Random rnd = new Random();
int secrets = rnd.Next(1, 51);
int attempts = 7;
bool guessedCorrectly = false;

Console.WriteLine("Gissa ett tal mellan 1 och 50. Du har { attempts} försök.");

for (int tryes = 1; tryes <= attempts; tryes++)
{
    Console.Write ($"Försök {tryes}: ");
    string input = Console.ReadLine()!;

    if (!int.TryParse(input, out int guessing))
    {
        Console.WriteLine("Ogiltigt inmatning. Vänligen mata in ett giltigt tal.");
        tryes--;
        continue;
    }

    else if (guessing > secrets)
    {
        Console.WriteLine("För högt! Försök igen.");
    }

    else if (guessing < secrets)
    {
        Console.WriteLine("För lågt! Försök igen.");
    }
    else
    {
        Console.WriteLine($"Grattis! Du gissade rätt på försök {tryes}.");
        guessedCorrectly |= true;
        break;
    }
}

if (!guessedCorrectly)
{
    Console.WriteLine($"Tyvärr! Du har slut på försök. Det rätta talet var {secrets}.");
}
