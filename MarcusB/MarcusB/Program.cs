
Console.WriteLine("Hello, World!");

Console.WriteLine("Ange pris per vara: ");
decimal prisPerVara = decimal.Parse(Console.ReadLine());
Console.WriteLine("Ange antal: ");
int antalVaror = int.Parse(Console.ReadLine());

Console.WriteLine("Totalt pris: " + prisPerVara * antalVaror + " kr");

