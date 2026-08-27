public class Dag2
{
    public static void Ovn1()
    {

        Console.WriteLine("Övning 1 - Temperaturkontroll");

        //Övning 1 Temperaturkontroll
        //• Mål: Träna if-else och strängmetoder.
        //• Instruktion:
        //1.Be användaren skriva in temperaturen i grader Celsius.
        //2.Om temperaturen är under 0, skriv “Det är frost”.
        //3.Om temperaturen är mellan 0 och 20, skriv “Lite kyligt”.
        //4.Om temperaturen över 20, skriv “Det är varmt”.
        //5.Konvertera de inmatade värdena med TryParse.
        //6.Skapa nästlade if-villkor där TryParse är det första if-villkoret.
        //7.Be användaren skriva in ett kommentarsord om vädret, använd Trim() och
        //ToUpper(), och skriv sedan ut det tillsammans med meddelandet.
        //8.Kommentera koden.

        int temperatur = 0;
        bool isNumeric = false;
        string myComment = "";
        string yourComment = "";

        Console.WriteLine("Ange antal grader Celsius:");

        isNumeric = int.TryParse(Console.ReadLine(), out temperatur);

        Console.WriteLine("Vad tycker du om vädret idag?");
        yourComment = Console.ReadLine();


        Console.WriteLine("Är det nummer? - " + isNumeric);

        if (isNumeric)
        {
            if (temperatur < 0)
            {
                myComment = "Det är frost";
            }
            else if (temperatur >= 0 && temperatur <= 20)
            {
                myComment = "Det är lite kyligt";
            }
            else if (temperatur > 20)
            {
                myComment = "Det är varmt";
            }
        }
        else
        {
            Console.WriteLine("Ange temperaturen med siffor endast");
        }



        Console.WriteLine("Idag är det " + temperatur + " grader Celsius. " + myComment + ". ");
        Console.WriteLine("Ditt väderkommentar är: " + yourComment.ToUpper().Trim() + "! ");





    }



    public static void Ovn2()
    {
        Console.WriteLine("Övning 2 Fruktsortering med switch");
        //Övning 2 Fruktsortering med switch
        //• Mål: Träna switch och strängmetoder.
        //• Instruktion:
        //1.Be användaren skriva namnet på en frukt.
        //2.Använd ToLower() för att hantera små och stora bokstäver.
        //3.Använd switch för att skriva ut kategorin:
        //• "äpple", "päron", "banan" - “Vanlig frukt”
        //• "mango", "kiwi" - “Exotisk frukt”
        //• Allt annat - “Okänd frukt”
        //4.Kommentera koden.


        Console.WriteLine("Ange namnet på en frukt:");
        string Frukt = Console.ReadLine().ToLower();

        // Validera värdet från användaren - Välj rätt case och skriv ut kategorin
        switch (Frukt)
        {
            case "äpple":
            case "päron":
            case "banan":
                Console.WriteLine("Vanlig frukt");
                break;
            case "mango":
            case "kiwi":
                Console.WriteLine("Exotisk frukt");
                break;
            default:
                Console.WriteLine("Okänd frukt");
                break;
        }

        






    }



    public static void Ovn3()
    {
        Console.WriteLine("Övning 3 Enkel räknesnurra(beräkning)");
        //Övning 3 Enkel räknesnurra(beräkning)
        //• Mål: Träna switch och matematik baserat på användarval.
        //• Instruktion:
        //1.Skapa en meny som låter användaren välja:
        //1.Addera två tal
        //2.Subtrahera två tal
        //3.Kvadrera ett tal
        //4.Avsluta
        //2.Beroende på valet, be användaren mata in ett eller två tal och skriv ut resultatet.
        //3.Om man matar in ett ogiltigt val, skriv “Ogiltigt val”.
        //4.Kommentera koden.

        int val = 0;
        int tal1 = 0;
        int tal2 = 0;
        bool isNumeric1 = false;
        bool isNumeric2 = false;

        while (val != 4)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Välj hur du vill beräkna");
            Console.WriteLine("1.Addera två tal");
            Console.WriteLine("2.Subtrahera två tal");
            Console.WriteLine("3.Kvadrera ett tal");
            Console.WriteLine("4.Avsluta");
            Console.WriteLine("");
            int.TryParse(Console.ReadLine(), out val);




            switch (val)
            {
                case 1:
                    Console.WriteLine("Ange första talet att addera: ");
                    isNumeric1 = int.TryParse(Console.ReadLine(), out tal1);

                    Console.WriteLine("Ange andra talet att addera: ");
                    isNumeric2 = int.TryParse(Console.ReadLine(), out tal2);

                    if (isNumeric1 == false || isNumeric2 == false)
                    {
                        Console.WriteLine("--> Ogiltigt tal");
                    }
                    else
                    {
                        Console.WriteLine("--> Summan av additionen är: " + (tal1 + tal2));
                        isNumeric1 = false;
                        isNumeric2 = false;

                    }
                    ; break;

                case 2:
                    Console.WriteLine("Ange ett tal: ");
                    isNumeric1 = int.TryParse(Console.ReadLine(), out tal1);

                    Console.WriteLine("Ange hur mycket som ska dras ifrån det första talet: ");
                    isNumeric2 = int.TryParse(Console.ReadLine(), out tal2);

                    if (isNumeric1 == false || isNumeric2 == false)
                    {
                        Console.WriteLine("--> Ogiltigt tal");
                    }
                    else
                    {
                        Console.WriteLine("--> Efter avdrag är summan: " + (tal1 - tal2));
                        isNumeric1 = false;
                        isNumeric2 = false;
                    }
                    ; break;

                case 3:
                    Console.WriteLine("Ange ett tal som du vill se i kvadrat: ");
                    isNumeric1 = int.TryParse(Console.ReadLine(), out tal1);


                    if (isNumeric1 == false)
                    {
                        Console.WriteLine("--> Ogiltigt tal");
                    }
                    else
                    {
                        Console.WriteLine("--> Kvadraten av talet är: " + (tal1 * tal1));
                        isNumeric1 = false;
                    }
                    ; break;

                case 4:
                    Console.WriteLine("--- Avslutar programmet ---");
                    break;
            }

        }
    }

    public static void Ovn4()
    {
        Console.WriteLine("Övning 4 Kontrollera lösenordslängd");
        //Övning 4 Kontrollera lösenordslängd
        //• Mål: Träna if-else och strängmetoder.
        //• Instruktion:
        //1.Be användaren skriva ett lösenord.
        //2.Om lösenordet är tomt(IsNullOrEmpty), skriv “Inget lösenord angivet”.
        //3.Om lösenordet har färre än 6 tecken, skriv “För kort lösenord”.
        //4.Om lösenordet är minst 6 tecken, skriv “Lösenordet är accepterat”.
        //5.Skriv också ut antal tecken i lösenordet(Length).
        //6.Kommentera koden.


        Console.WriteLine("Ange ett lösenord: ");
        string pw = Console.ReadLine();

        if (string.IsNullOrEmpty(pw))
        {
            Console.WriteLine("Inget lösenord angivet");

        }
        else if (pw.Length < 6)
        {
            Console.WriteLine("För kort lösenord");
            Console.WriteLine("Du har angett en längd på " + pw.Length + " tecken.");
        }
        else
        {
            Console.WriteLine("Godkänt lösenord");
            Console.WriteLine("Du har angett en längd på " + pw.Length + " tecken.");
        }




    }

    public static void Ovn5()
    {
        Console.WriteLine("Övning 5 - Interaktiv meny");
        //Övning 5
        //Skapa ett konsolprogram i C# där användaren får göra ett val och programmet
        //reagerar olika beroende på inmatning. Uppgiften ska träna användning av switch, ifsatser, numerisk inmatning och stränghantering.
        //Programmet ska börja med att fråga användaren vad hen vill göra genom att visa
        //följande meny:
        //1.Kontrollera temperatur
        //2.Kontrollera ord
        //3.Avsluta
        //Använd en switch-sats för att hantera användarens val.Om användaren anger något
        //annat än 1, 2 eller 3 ska programmet skriva ”Ogiltigt val”.
        //Om användaren väljer Kontrollera temperatur ska programmet:
        //• Be användaren mata in en temperatur i grader Celsius
        //• Använda TryParse för att kontrollera att inmatningen är numerisk
        //• Med hjälp av if-satser skriva ut:
        //o ”Kallt” om temperaturen är under 10
        //o ”Lagom” om temperaturen är mellan 10 och 25
        //o ”Varmt” om temperaturen är över 25
        //Om användaren väljer Kontrollera ord ska programmet:
        //• Be användaren skriva in ett valfritt ord
        //• Använda Trim() och ToUpper()
        //• Skriva ut om ordet är kort(färre än 5 tecken) eller långt(5 tecken eller fler)
        //• Skriva även ut hur många tecken ordet innehåller
        //Om användaren väljer Avsluta ska programmet skriva ut ett avslutsmeddelande och
        //avslutas.


        int val = 0;

        while (val != 3)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1.Kontrollera temperatur");
            Console.WriteLine("2.Kontrollera ord");
            Console.WriteLine("3.Avsluta");

            int.TryParse(Console.ReadLine(), out val);

            switch (val)
            {
                case 1:
                    {
                        int temp = 0;
                        Console.WriteLine("Ange antal grader i Celcius");
                        bool isNumeric = int.TryParse(Console.ReadLine(), out temp);

                        if (!isNumeric)
                        {
                            Console.WriteLine("--> " + "Ange temperaturen med siffror endast");
                        }

                        else if (temp < 10)
                        {
                            Console.WriteLine("--> " + temp + " grader är jäkligt kallt!");
                        }
                        else if (temp >= 10 && temp <= 25)
                        {
                            Console.WriteLine("--> " + temp + " grader är verkligen lagom!");
                        }
                        else
                        {
                            Console.WriteLine("--> " + temp + " grader är jättevarmt!"); 
                        }
                            break;
                    }
                case 2:
                    {
                        Console.WriteLine("Skriv ett ord"); 
                        string ord = Console.ReadLine().ToUpper().Trim();
                        
                        if(ord.Length < 5)
                        {
                            Console.WriteLine("--> Ditt ord: '" + ord + "' är ett kort ord med " + ord.Length + " tecken");
                        }
                        else
                        {
                            Console.WriteLine("--> Ditt ord: '" + ord + "' är ett långt ord med " + ord.Length + " tecken");
                        }

                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("--- Programmet avslutas ---");
                        Console.WriteLine("--- Bye Bye! ---");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("--> " + "Felaktikt val!"); break;
                    }

            }

        }


    }
}