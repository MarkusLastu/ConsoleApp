using System.Collections.Generic;
using System.Diagnostics;

namespace V2_Dag3_Ovn2_BioKassa
{
    public class Snack
    {
        public string Namn { get; set; }
        public int Pris { get; set; }
        public Snack(string namn, int pris)
        {
            Namn = namn;
            Pris = pris;
        }
    }

    public class Drink
    {
        public string Namn { get; set; }
        public int Pris { get; set; }

        public Drink(string namn, int pris)
        {
            Namn = namn;
            Pris = pris;
        }
    }

    public class Movie
    {
        public string Titel { get; set; }
        public int Pris { get; set; }
        public Movie(string titel, int pris)
        {
            Titel = titel;
            Pris = pris;
        }
    }

    public class Ticket
    {
        public string Typ { get; set; }
        public double rabatt { get; set; }

    }

    public class BioMeny
    {
        public List<Snack> Snacks { get; set; } = new List<Snack>
    {
        new Snack("Inget", 0),
        new Snack("Popcorn", 35),
        new Snack("Chips", 30),
        new Snack("Godis", 25)
    };

        public List<Drink> Drinks { get; set; } = new List<Drink>
    {
        new Drink("Inget", 0),
        new Drink("Läsk", 25),
        new Drink("Vatten", 10),
        new Drink("Juice", 20)
    };

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public List<Ticket> Tickets { get; set; } = new List<Ticket>
    {
        new Ticket { Typ = "Barn", rabatt = 0.5 },
        new Ticket { Typ = "Vuxen", rabatt = 0 }
    };

        public BioMeny()
        {
            string filePath = Path.Combine(
                AppContext.BaseDirectory,
                "ImportFiler",
                "filmer.txt");

            using StreamReader sr = new StreamReader(filePath);

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                Movies.Add(new Movie(line, 100));
            }
        }
    }
}