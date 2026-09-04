using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace V2_Dag5_Fredagsgodis
{
    public class Personer
    {

        // Listan med alla personer som skapas i Personer.cs
        public static List<PersonClass> personLista = new List<PersonClass>();

        // Lägg till en person i listan
        public static void AddPersonToList(PersonClass person)
        {
            personLista.Add(person);
            Debug.WriteLine($"Person {person.Name} har lagts till i listan.");
        }


        // Speglar json strukturen
        public class PersonInfo
        {
            public List<PersonData> personer { get; set; }
        }

        public class PersonData
        {
            public string namn { get; set; }
            public string klass { get; set; }
            public Egenskaper egenskaper { get; set; }
        }

        public class Egenskaper
        {
            public int pbBank { get; set; }
            public string instrument { get; set; }
            public string spel { get; set; }
            public string superPower { get; set; }
            public string specialAttack { get; set; }
            public string specialisering { get; set; }
            public string weakness { get; set; }
        }

        public static void CreatePersonsFromJson(string json)
        {
            PersonInfo data = JsonSerializer.Deserialize<PersonInfo>(json);

            foreach (PersonData person in data.personer)
            {
                PersonClass nyPerson;

                switch (person.klass)
                {
                    case "Musiker":
                        nyPerson = new Musiker(
                            person.namn,
                            person.egenskaper.instrument);
                        break;

                    case "Gamer":
                        nyPerson = new Gamer(
                            person.namn,
                            person.egenskaper.spel);
                        break;

                    case "Gymmare":
                        nyPerson = new Gymmare(
                            person.namn,
                            person.egenskaper.pbBank);
                        break;

                    default:
                        continue;
                }

                nyPerson.SuperPower = person.egenskaper.superPower;
                nyPerson.SpecialAttack = person.egenskaper.specialAttack;
                nyPerson.Specialisering = person.egenskaper.specialisering;
                nyPerson.Weakness = person.egenskaper.weakness;

                AddPersonToList(nyPerson);
            }
        }

    }

}
