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

        for (int i = 0;i<incomingArray.Length;i++)
        {
            outputArray[i] = new double[2];
            Console.WriteLine($"Rad {i}, värde: '{incomingArray[i][columnIndex]}'");
            outputArray[i][0] = double.Parse(incomingArray[i][columnIndex]);
            outputArray[i][1] = outputArray[i][0] * 1000000;
        }

        
        return outputArray;
        

    }
}