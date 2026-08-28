using System.IO;
using System.Collections.Generic;
using System.Net.NetworkInformation;

public class ImporteraFiler
{
    static string fileDir = @"C:\Users\borka\OneDrive\Dokument\Kurs Programmering\C# Julia\ImportFiler\";



    public static List<string> ReadFiles(string fileName)
    {
        string filePath = fileDir + fileName;
        Console.WriteLine(filePath);

        List<string> dataList = new List<string>();

        int numberOfLines = 0;

        // Ordet using släpper listan efter man har läst in den (det som är innanför {})

        // Läser in data från filen
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line = reader.ReadLine();

            while ((line != null))
            {
                dataList.Add(line);
                Console.WriteLine(line);
                line = reader.ReadLine();
                numberOfLines++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("==========================");
        Console.WriteLine("Rader inlästa: " + numberOfLines);
        numberOfLines = 0;

        // Kollar det inlästa datat så varje rad innehåller data
        List<string> validData = new List<string>();
        {
            foreach (string data in dataList)
            {
                if (!string.IsNullOrWhiteSpace(data))
                {
                    validData.Add(data);
                    numberOfLines++;
                }
            }
        }


        Console.WriteLine("Valida rader inlagda: " + numberOfLines);

        return validData;
    }

    public static string[][] convertListToArray(List<string> incomingList)
    {

        Console.WriteLine("Skapar array av inkommande lista");
        // Rubriker
        // string[] headers = incomingList[0].Split(';');


        // Övrig data

        string[][] outputData = incomingList
            .Skip(1)
            .Select(line => line.Split(';'))
            .ToArray();

        foreach (string[] row in outputData)
        {

            foreach (string column in row)
            {
                Console.Write(column + " - ");
            }

            Console.WriteLine("/n");

        }
        return outputData;
    }



    public static void FindDataWithStartingLetter(List<string> incomingList, string startingLetter)
    {
        foreach (string data in incomingList)
        {
            var parts = data.Split(';');
            if (parts[0].StartsWith(startingLetter))
            {
                Console.WriteLine("---- Land ----");
                Console.WriteLine(parts[0]);
                Console.WriteLine($"{parts[0]} {parts[1]} {parts[2]} {parts[3]}");
            }

        }


        var dataStartingWithLetter = incomingList
            .Skip(1)
            .Select(line => line.Split(';'))
            .Where(parts => parts[0].StartsWith(startingLetter))
            .Select(parts => new
            {
                Country = parts[0],
                Population = int.Parse(parts[1]),
                GDP = long.Parse(parts[2]),
                Currency = parts[3]
            })
            .OrderBy(c => c.Population);


        foreach (var data in dataStartingWithLetter)
        {
            Console.WriteLine("---- LINQ ----");
            Console.WriteLine(data.Country);
        }
    }

    // Public static metod som returnerar kolumnnamnen
    public static string[] GetColumnNames(string fileName)
    {

        string filePath = fileDir + fileName;
        // Läser alla rader i filen
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            // Hoppa över tomma rader eller rader med bara blanksteg
            if (string.IsNullOrWhiteSpace(line))
                continue;
            // Första giltiga raden = kolumnnamn
            return line.Split(';');
        }
        // Om ingen giltig rad hittas
        return Array.Empty<string>();
    }


    public static void extractOneColumn(string fileName, int columnIndex, string columnName)
    {

        List<string> incomingList = ImporteraFiler.ReadFiles(fileName);

        Console.WriteLine($"--- {columnName} ---");

        var columnInfo = incomingList
         .Skip(1)
         .Select(line => line.Split(';'))         
         .Select(parts => parts[columnIndex])
         .Distinct()
         .ToList();

        foreach (var value in columnInfo)
        {
            Console.WriteLine(value);
        }
        Console.WriteLine("Antal unika värden: " + columnInfo.Count);
    }



    public static double[] GetAreaInSquareMeters(string[][] dataArray, int columnIndex)
    {
        if (dataArray == null)
            return Array.Empty<double>();

        var result = new List<double>();

        foreach (var row in dataArray)
        {
            if (row == null || row.Length <= columnIndex)
            {
                result.Add(double.NaN);
                continue;
            }

            string raw = row[columnIndex];
            if (string.IsNullOrWhiteSpace(raw))
            {
                result.Add(double.NaN);
                continue;
            }

            // Normalize number format (comma or dot) and remove spaces
            string cleaned = raw.Trim().Replace(" ", "").Replace("\u00A0", "").Replace(",", ".");

            if (double.TryParse(cleaned, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double value))
            {
                // Assume the input area is in square kilometers and convert to square meters
                double squareMeters = value * 1_000_000.0;
                result.Add(squareMeters);
            }
            else
            {
                result.Add(double.NaN);
            }
        }

        Console.WriteLine("Converted areas to square meters. Count: " + result.Count);
        return result.ToArray();
    }

}
