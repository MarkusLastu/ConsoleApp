Console.Write("Ange pris per vara: ");

string prisInput = Console.ReadLine();

decimal pris;

decimal.TryParse(prisInput, out pris);

Console.Write("Ange antal varor: ");

string antalInput = Console.ReadLine();

int antal;

int.TryParse(antalInput, out antal);

decimal totalsumma = pris * antal;

decimal moms = totalsumma * 0.25m;

decimal attBetala = totalsumma + moms;

Console.WriteLine();

Console.WriteLine("Pris per styck: " + pris + " kr");

Console.WriteLine("Antal: " + antal);

Console.WriteLine("Moms (25%): " + moms + " kr");

Console.WriteLine("Att betala: " + attBetala + " kr");

