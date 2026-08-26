namespace MarcusB_Project.Funktioner;


public class Inputs
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
}