using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp_MarkusL.Exercises.Week1
{
    public class Day5
    {
        private static string countriesPath = @"C:\Projekt_GitHub\ConsoleApp\MarkusL-Solution\External_files\Countries.txt";
        private static string countriesAreaPath = @"C:\Projekt_GitHub\ConsoleApp\MarkusL-Solution\External_files\Countries_area.txt";

        public static void Exc1()
        {
            Console.WriteLine("=== DAY 5 - EXC 1: Analysera specifik kolumn ===");

            string[] columnNames = GetColumnNames(countriesPath);
            if (columnNames.Length == 0) return;

            Console.WriteLine("Tillgängliga kolumner:");
            for (int i = 0; i < columnNames.Length; i++)
            {
                Console.WriteLine($"{i} = {columnNames[i]}");
            }

            Console.Write("Välj en kolumn genom att ange dess siffra: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selectedIndex) && selectedIndex >= 0 && selectedIndex < columnNames.Length)
            {
                string[] allLines = File.ReadAllLines(countriesPath);
                List<string> columnValues = new List<string>();

                for (int i = 1; i < allLines.Length; i++)
                {
                    string line = allLines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(';');
                    if (parts.Length > selectedIndex)
                    {
                        columnValues.Add(parts[selectedIndex]);
                    }
                }

                List<string> uniqueValues = columnValues.Distinct().ToList();

                Console.WriteLine($"\nVald kolumn: {columnNames[selectedIndex]}");
                Console.WriteLine($"Antal unika värden: {uniqueValues.Count}");
                Console.WriteLine("Unika värden:");
                foreach (string val in uniqueValues)
                {
                    Console.WriteLine($"- {val}");
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt val.");
            }
        }

        public static void Exc2()
        {
            Console.WriteLine("=== DAY 5 - EXC 2: Konvertera Area (km2 -> m2) ===");

            double[] areas = GetAreaInSquareMeters(countriesAreaPath);

            if (areas.Length == 0)
            {
                Console.WriteLine("Ingen data kunde läsas in.");
                return;
            }

            Console.WriteLine($"Konverterade {areas.Length} rader från km² till m²:");
            for (int i = 0; i < areas.Length; i++)
            {
                Console.WriteLine($"Rad {i + 1}: {areas[i]:N0} m²");
            }
        }

        public static void Exc3()
        {
            Console.WriteLine("=== DAY 5 - EXC 3: Analysera GDP och Valutor ===");

            if (!File.Exists(countriesPath))
            {
                Console.WriteLine($"Hittade inte filen: {countriesPath}");
                return;
            }

            string[] allLines = File.ReadAllLines(countriesPath);

            var validDataLines = allLines
                .Skip(1)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Split(';'))
                .ToList();

            Console.WriteLine("\n--- Topp 5 rikaste länderna (GDP/Capita) ---");

            var gdpList = validDataLines
                .Where(parts => parts.Length >= 4)
                .Select(parts =>
                {
                    bool validPop = long.TryParse(parts[1], out long pop);
                    bool validGdp = double.TryParse(parts[2], out double gdp);

                    return new
                    {
                        Country = parts[0],
                        Population = pop,
                        GDP = gdp,
                        IsValid = validPop && validGdp && pop > 0
                    };
                })
                .Where(x => x.IsValid)
                .Select(x => new
                {
                    Country = x.Country,
                    GdpPerCapita = x.GDP / x.Population
                })
                .Where(x => x.GdpPerCapita > 10000)
                .OrderByDescending(x => x.GdpPerCapita)
                .Take(5)
                .ToList();

            foreach (var item in gdpList)
            {
                Console.WriteLine($"{item.Country}: {item.GdpPerCapita:C0} per person");
            }

            Console.WriteLine("\n--- Analys av Valutor ---");

            var currencyGroups = validDataLines
                .Where(parts => parts.Length >= 4)
                .GroupBy(parts => parts[3])
                .Select(group => new
                {
                    Currency = group.Key,
                    Count = group.Count(),
                    Countries = group.Select(g => g[0]).ToList()
                })
                .OrderByDescending(x => x.Count)
                .ToList();

            Console.WriteLine($"Antal unika valutor: {currencyGroups.Count}");

            var topCurrency = currencyGroups.First();
            Console.WriteLine($"Valutan som används av flest länder är: {topCurrency.Currency} ({topCurrency.Count} länder)");

            Console.WriteLine("Länder som använder denna valuta:");
            foreach (string country in topCurrency.Countries)
            {
                Console.WriteLine($"- {country}");
            }
        }

        // --- Hjälpmetoder ---
        private static string[] GetColumnNames(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Hittade inte filen: {filePath}");
                return Array.Empty<string>();
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                return line.Split(';');
            }
            return Array.Empty<string>();
        }

        private static double[] GetAreaInSquareMeters(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Hittade inte filen: {filePath}");
                return Array.Empty<double>();
            }

            string[] allLines = File.ReadAllLines(filePath);
            List<double> areasInMeters = new List<double>();

            string[] headers = GetColumnNames(filePath);
            int areaIndex = Array.IndexOf(headers, "AreaKm2");

            if (areaIndex == -1)
            {
                Console.WriteLine("Kunde inte hitta kolumnen 'AreaKm2'.");
                return Array.Empty<double>();
            }

            for (int i = 1; i < allLines.Length; i++)
            {
                string line = allLines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(';');
                if (parts.Length > areaIndex)
                {
                    if (double.TryParse(parts[areaIndex], out double areaKm2))
                    {
                        double areaM2 = areaKm2 * 1_000_000;
                        areasInMeters.Add(areaM2);
                    }
                }
            }

            return areasInMeters.ToArray();
        }
    }
}