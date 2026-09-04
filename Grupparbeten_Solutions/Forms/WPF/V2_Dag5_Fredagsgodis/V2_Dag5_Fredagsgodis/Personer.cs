using System;
using System.Collections.Generic;
using System.Text;
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

        public static Gymmare CreateNiklas()
        {
            Gymmare niklas = new Gymmare("Niklas", 500);

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

            marcusB.SuperPower = "xxx";
            marcusB.SpecialAttack = "yyy";
            marcusB.Specialisering = "zzz";
            marcusB.Weakness = "xxx";

            AddPersonToList(marcusB);

            return marcusB;           

        }

    }

}
