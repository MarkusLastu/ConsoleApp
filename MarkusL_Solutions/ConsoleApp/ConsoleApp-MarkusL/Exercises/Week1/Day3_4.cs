namespace ConsoleApp_MarkusL.Exercises.Week1
{
    public class Day3_4
    {
        public static void Exc1()
        {
            string[] filmerArray = { "Avatar", "Bilar", "Shrek", "Dune", "Alien", "Jaws" };
            List<string> filmerLista = new List<string>();

            for (int i = 0; i < filmerArray.Length; i++)
            {
                Console.WriteLine(filmerArray[i]);
                filmerLista.Add(filmerArray[i]);
            }

            while (true)
            {
                Console.Write("Lägg till en film (eller skriv 'klar'): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "klar")
                {
                    break;
                }

                filmerLista.Add(input);
            }

            var resultat = filmerLista
                .Where(film => film.ToLower().Contains("a"))
                .Select(film => "Film: " + film.ToString());

            Console.WriteLine("Filmer som innehåller bokstaven 'a':");
            foreach (var item in resultat)
            {
                Console.WriteLine(item);
            }
        }

        public static void Exc2()
        {
            string[] talArray = { "12", "5", "27", "44", "8", "31", "16" };

            List<int> talLista = new List<int>();

            for (int i = 0; i < talArray.Length; i++)
            {
                int konverteratTal = int.Parse(talArray[i]);
                talLista.Add(konverteratTal);
            }

            while (true)
            {
                Console.Write("Skriv ett tal (eller 'stop'): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "stop")
                {
                    break;
                }

                talLista.Add(int.Parse(input));
            }

            var filtreradeTal = talLista
                .Where(tal => tal > 20)
                .Select(tal => "Talet är " + tal.ToString());

            foreach (var item in filtreradeTal)
            {
                Console.WriteLine(item);
            }
        }

        public static void Exc3()
        {
            string[] djurArray = { "hund", "katt", "elefant", "kanin", "häst", "krokodil" };

            List<string> djurLista = new List<string>();

            for (int i = 0; i < djurArray.Length; i++)
            {
                djurLista.Add(djurArray[i]);
                Console.WriteLine(djurArray[i]);
            }

            while (true)
            {
                Console.Write("Lägg till ett djur ('klar' för att avsluta): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "klar")
                {
                    break;
                }

                djurLista.Add(input);
            }

            var resultat = djurLista
                .Where(djur => djur.Length > 5)
                .OrderBy(djur => djur)
                .Select(djur => djur.ToString().ToUpper());
            //.OrderBy(djur => djur)

            foreach (var item in resultat)
            {
                Console.WriteLine(item);
            }
        }

        public static void Exc4()
        {
            string[] poangArray = { "10", "75", "42", "100", "33", "68" };

            List<int> poangLista = new List<int>();

            for (int i = 0; i < poangArray.Length; i++)
            {
                poangLista.Add(int.Parse(poangArray[i]));
            }

            while (true)
            {
                Console.Write("Lägg till poäng ('klar' för att avsluta): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "klar")
                {
                    break;
                }

                poangLista.Add(int.Parse(input));
            }

            var vinnandePoang = poangLista
                .Where(poang => poang >= 50)
                .OrderBy(poang => poang)
                .Select(poang => "Poäng: " + poang.ToString());

            Console.WriteLine("\n--- Slutresultat ---");
            foreach (var item in vinnandePoang)
            {
                Console.WriteLine(item);
            }
        }
    }
}