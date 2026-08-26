using System;
using System.Collections.Generic;
using System.Linq;

List<int> tempraturer = new List<int>();
int antalMätningar = 10;
Console.WriteLine($"Mata in {antalMätningar} temperaturer (heltal): ");

for (int i = 0; i < antalMätningar; i++)
{
    bool giltigInmatning = false;
    while (!giltigInmatning)
    {
        try
        {
            Console.Write($"Temperatur {i + 1}: ");
            int temperatur = int.Parse(Console.ReadLine()!);
            tempraturer.Add(temperatur);
            giltigInmatning = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Ogiltig inmatning. Vänligen mata in ett heltal.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Talet är för stort eller för litet! Vänligen mata in ett heltal inom giltigt intervall.");
        }
        catch (Exception)
        {
            Console.WriteLine("Ett oväntat fel inträffade. Vänligen försök igen.");
        }



    }
}
Console.WriteLine("--Resultat--");

double medelvärde = tempraturer.Average();
Console.WriteLine($"Medelvärdet är: {medelvärde:F1} Grader");

int minTemp = tempraturer.Min();
int maxTemp = tempraturer.Max();
Console.WriteLine($"Minsta temperatur: {minTemp} Grader");
Console.WriteLine($"högsta temperatur: {maxTemp} Grader");

int under25 = tempraturer.Count(t => t < 25);
int över25 = tempraturer.Count(t => t > 25);
Console.WriteLine($"Antal temperaturer under 25 grader: {under25}");
Console.WriteLine($"Antal temperaturer över 25 grader: {över25}");

Console.ReadKey();