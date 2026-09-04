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

        public static Gamer CreateNiklas()
        {
            Gamer niklas = new Gamer("Niklas", "Counter-Strike");

            niklas.SuperPower = "Full Focus: låster ute värden och focuserar bara på skärmen";
            niklas.SpecialAttack = "Gamer rage: Vrålar och skriver otrevliga kommentarer mot alla i närheten";
            niklas.Specialisering = "Point and Click: Clickar med extrem perscition på vald pixel";
            niklas.Weakness = "Energitjuv : Överbelastar säkringar i en radie";

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
