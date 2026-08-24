Console.Write("Ange priset för din vara: ");
string breakfastInput = Console.ReadLine();
decimal Prisvara = Convert.ToDecimal(breakfastInput);
Console.WriteLine("Skriv in antal varor: ");
string quantityInput = Console.ReadLine();
decimal quantity = Convert.ToDecimal(quantityInput);
decimal totalprice = (decimal)(Prisvara * quantity * 2);
Console.WriteLine("Pris efter skatt: " + totalprice);
