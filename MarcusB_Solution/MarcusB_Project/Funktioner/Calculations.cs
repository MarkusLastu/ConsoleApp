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

}