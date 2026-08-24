Console.Write("Ange priset för din vara: ");
string PrisVaraInput = Console.ReadLine();
decimal Prisvara = Convert.ToDecimal(PrisVaraInput);
Console.WriteLine("Skriv in antal varor: ");
string quantityInput = Console.ReadLine();
decimal Quantity = Convert.ToDecimal(quantityInput);
decimal totalprice = (decimal)(Prisvara * Quantity * 2);
Console.WriteLine("Pris efter skatt: " + totalprice +"Kr");
