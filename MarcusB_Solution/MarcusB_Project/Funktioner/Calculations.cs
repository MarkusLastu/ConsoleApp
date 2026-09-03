

namespace MarcusB_Project.Funktioner;

public class Calculations
{

    public static int HeltalParsing(string fraga)
    {
        while (true)
        {
            Console.Write(fraga);
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Felaktig inmatning. Ange ett heltal.");
                Console.WriteLine();
            }
        }
    }

    public static int[] squareArray(int[] inputArray)
    {
        int[] outputArray = new int[inputArray.Length];

        for (int i = 0; i < inputArray.Length; i++)
        {
            Console.WriteLine("Nummer från inkommande array: " + inputArray[i]);
            outputArray[i] = inputArray[i] * inputArray[i];

            Console.WriteLine("Numret i kvadrat: " + outputArray[i]);


        }

        return outputArray;

    }

    public static double[][] GetAreaInSquareMeters(string[][] incomingArray, int columnIndex)
    {

        incomingArray = incomingArray
    .Where(row => row.Length > columnIndex &&
                  !string.IsNullOrWhiteSpace(row[columnIndex]))
    .ToArray();

        double[][] outputArray = new double[incomingArray.Length][];

        for (int i = 0; i < incomingArray.Length; i++)
        {
            outputArray[i] = new double[2];
            Console.WriteLine($"Rad {i}, värde: '{incomingArray[i][columnIndex]}'");
            outputArray[i][0] = double.Parse(incomingArray[i][columnIndex]);
            outputArray[i][1] = outputArray[i][0] * 1000000;
        }


        return outputArray;


    }
}


// Klassen som innehåller både statiska och instansmetoder

// Det finns statiska metoder(Add, Multiply) och de anropas direkt med
// klassnamnet: SimpleMath.Add(5,7). De kräver ingen instans.De har inte heller
// någon påverkan på objektets tillstånd. Däremot instansmetoder (Subtract,
// Divide) kräver att vi skapar ett objekt: SimpleMath mathObj = new SimpleMath();
// De fåverkar objektets metoder och egenskaper(LastResult) och kan lagra
// senaste beräkningen i objektet.


public class SimpleMathClass
{
    // Instansfält för att lagra senaste resultat
    public int LastResultInstance { get; private set; }

    // Statisk metod: kan anropas utan objekt
    public static int AddMethod(int a, int b)
    {
        return a + b;
    }

    // Statisk metod        
    public static int MultiplyMethod(int a, int b)
    {
        return a * b;
    }

    // Instansmetod: påverkar objektets tillstånd
    public void SubtractMethod(int a, int b)
    {
        LastResultInstance = a - b;
        Console.WriteLine($"Resultatet av {a} - {b} = {LastResultInstance}");
    }

    // Instansmetod: påverkar objektets tillstånd
    public void DivideMethod(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("Kan inte dividera med noll!");
            return;
        }
        LastResultInstance= a / b;
        Console.WriteLine($"Resultatet av {a} / {b} = {LastResultInstance}");
    }
}

