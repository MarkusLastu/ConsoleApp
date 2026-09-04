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



        public static Gymmare CreateMarkusL()
        {
            Gymmare markusL = new Gymmare("Markus L", 500);

            markusL.SuperPower = "Finger Styrka: Trycker HÅRT på datortangenterna";
            markusL.SpecialAttack = "CapsLock-vrålet: Trycker in CapsLock med en sån enorm kraft att tryckvågen får motståndarens kod att sluta kompilera.";
            markusL.Specialisering = "Mekanisk Hållfasthet: Kan skriva tusentals rader kod på ett mekaniskt tangentbord utan att fingrarna tar slut på glykogen.";
            markusL.Weakness = "Merge Conflicts i gymmet: Blir helt handlingsförlamad om någon har lämnat kvar vikter på skivstången utan att städa sin branch först.";

            AddPersonToList(markusL);

            return markusL;

        }

        public static Gamer CreateNiklas()
        {
            Gamer niklas = new Gamer("Niklas", "Counter-Strike");

            niklas.SuperPower = "xxx";
            niklas.SpecialAttack = "yyy";
            niklas.Specialisering = "zzz";
            niklas.Weakness = "xxx";

            AddPersonToList(niklas);

            return niklas;

        }

        public static Musiker CreateMarcusB()
        {
            Musiker marcusB = new Musiker("Marcus B", "Piano");

            marcusB.SuperPower = "Gehör: Kan spela en låt direkt efter att ha hört den.";
            marcusB.SpecialAttack = "Fortissimo: Slår an ett ackord med enorm kraft.";
            marcusB.Specialisering = "Improvisation: Kan skapa musik utan att behöva veta vad som ska spelas i förväg.";
            marcusB.Weakness = "Kan inte prata och spela samtidigt. Det blir kaos i hjärnan.";

            AddPersonToList(marcusB);

            return marcusB;

        }

        public static Musiker CreateSebbe()
        {
            Musiker sebbe = new Musiker("Sebbe", "Luftbastuba");

            sebbe.SuperPower = "xxx";
            sebbe.SpecialAttack = "yyy";
            sebbe.Specialisering = "zzz";
            sebbe.Weakness = "xxx";

            AddPersonToList(sebbe);

            return sebbe;
        }

    }

}
