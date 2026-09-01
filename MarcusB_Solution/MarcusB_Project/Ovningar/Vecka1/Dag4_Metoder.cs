namespace MarcusB_Project.Ovningar.Vecka1;

using System.Diagnostics;
using System.IO.Enumeration;
using System.Reflection.Metadata;
using MarcusB_Project.Funktioner;


public class Dag4b
{
    public static void Info1()
    {

        //Vi ska nu skapa en funktion som returnerar värden ifrån en numerisk array.Den är
        //statisk och därför måste ligga inom samma klass.Den ska returnera en array av
        //int och därför skriver vi det som datatyp. Den ska även ta emot argument, därför
        //definierar vi parameter med array datatyp som indata. En funktion skall alltid
        //returnera ett värde och därför avslutas funktionerna med return.

        int[] numbers = { 2, 4, 6, 8, 10, 12, 100 };

        Console.WriteLine("========= INDATA =========");

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("==========================");
        Console.WriteLine();

        int[] numbersSquared = Calculations.squareArray(numbers);

        Console.WriteLine("==========================");
        Console.WriteLine();
        Console.WriteLine("========= UTDATA =========");

        foreach (int number in numbersSquared)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("==========================");

    }

    public static void Info2_LasInRaderFranFil(string fileName)
    {

        Console.WriteLine("Läser in filen " + fileName);

        List<string> Countries = ImporteraFiler.ReadFiles(fileName);


        Console.WriteLine("Antal rader returnerade: " + Countries.Count);

        Console.WriteLine();
        Console.WriteLine("==========================");

        Console.Write("Vilken begynnelsebokstav ska vi söka efter? ");
        string startingLetter = Console.ReadLine();

        ImporteraFiler.FindDataWithStartingLetter(Countries, startingLetter);
    }

    public static void Info3_LasInKolumnNamnFranFil(string fileName)
    {
        // string filePath = "Countries_area.txt"; // eller "Countries.txt"
        string[] columnNames = ImporteraFiler.GetColumnNames(fileName);
        Console.WriteLine("Kolumnnamn:");
        foreach (string column in columnNames)
        {
            Console.WriteLine(column);
        }
    }


    public static void Ovn1(string fileName)
    {
        Console.WriteLine("Övning 1 - Anropa GetColumnNames");

        var columnNames = ImporteraFiler.GetColumnNames(fileName);

        Console.WriteLine();
        Console.WriteLine("===============================");
        Console.WriteLine("Kolumner i filen: " + fileName);
        Console.WriteLine();
        Console.WriteLine("-------------------------------");
        for (int i = 0; i < columnNames.Length; i++)
        {
            Console.WriteLine("Index: " + i + " - KolumnNamn: " + columnNames[i]);
        }


        Console.WriteLine();
        Console.WriteLine("===============================");
        Console.WriteLine();
        Console.Write("Vilken kolumn vill du analysera? Ange Index: ");
        int columnIndex = 0;
        int.TryParse(Console.ReadLine(), out columnIndex);

        var filData = ImporteraFiler.ReadFiles(fileName);

        Console.WriteLine("Rader mottagna i filData: " + filData.Count);

        ImporteraFiler.extractOneColumn(fileName, columnIndex, columnNames[columnIndex]);
        {

        }
    }

    public static void Ovn2(string fileName)
    {

        Console.WriteLine("Övning 1 - Anropa GetColumnNames");

        var columnNames = ImporteraFiler.GetColumnNames(fileName);

        Console.WriteLine();
        Console.WriteLine("===============================");
        Console.WriteLine("Kolumner i filen: " + fileName);
        Console.WriteLine();
        Console.WriteLine("-------------------------------");
        for (int i = 0; i < columnNames.Length; i++)
        {
            Console.WriteLine("Index: " + i + " - KolumnNamn: " + columnNames[i]);
        }


        Console.WriteLine();
        Console.WriteLine("===============================");
        Console.WriteLine();
        Console.Write("Vilken kolumn vill du få tillbaka i kvadrat? Ange Index: ");
        int columnIndex = 0;
        int.TryParse(Console.ReadLine(), out columnIndex);

        List<string> dataList = ImporteraFiler.ReadFiles(fileName);
        Console.WriteLine("Antal rader i dataList: " + dataList.Count);

        // Ändra listan till Array

        string[][] dataArray = ImporteraFiler.convertListToArray(dataList);
        Console.WriteLine("Antal rader i dataArray: " + dataArray.Length);

        double[][] squaredArray = Calculations.GetAreaInSquareMeters(dataArray, columnIndex);

        Console.WriteLine("Antal rader i squaredArray: " + squaredArray.Length);

        Console.WriteLine();
        Console.WriteLine("===============================");
        Console.WriteLine();

        Console.WriteLine(
            "Area km2".PadRight(15) +
            "Area m2".PadRight(15)
        );

        foreach (double[] row in squaredArray)
        {
            Console.WriteLine(
                row[0].ToString().PadRight(15) +
                row[1].ToString().PadRight(15));
        }

        Console.WriteLine("===============================");




    }

}
