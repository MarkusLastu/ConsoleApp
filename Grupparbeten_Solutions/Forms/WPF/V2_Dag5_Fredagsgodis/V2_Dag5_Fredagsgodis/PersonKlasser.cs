using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Controls;

namespace V2_Dag5_Fredagsgodis
{
    


    public abstract class PersonClass
    {
        public string Name { get; set; }
        public string SuperPower { get; set; }
        public string Specialisering {  get; set; }
        public string SpecialAttack { get; set; }   
        public string Weakness { get; set; }    

        public PersonClass(string name)
        {
            Name = name;            
        }
        public abstract string Presentera();
        public abstract void AnvandSuperkraft();
    }

    public class Musiker : PersonClass
    {
        public string Instrument { get; set; } = string.Empty;
        public Musiker(string name, string instrument) : base(name)
        {
            Instrument = instrument;
        }
        public override string Presentera()
        {
            return $"{Name} är musiker och spelar {Instrument}.";
        }
        public override void AnvandSuperkraft()
        {
            System.Windows.MessageBox.Show(
                $"{Name} använder sin superkraft\n\n" +
                $"{SuperPower} \n\n" +
                $"och utför specialattacken\n\n" +
                $"{SpecialAttack}."
            );
        }
    }

    public class Gymmare : PersonClass
    {
        public int PbBank { get; set; } = 0;
        public Gymmare(string name, int pbBank) : base(name)
        {
            PbBank = pbBank;
        }

        public override string Presentera()
        {
            return 
                $"{Name} är gymmare och har {PbBank} pb i bänken.\n\n" +
                $"{Name} har specialisering {Specialisering}.\n\n" +
                $"{Name} har svaghet: {Weakness}.";
        }

        public override void AnvandSuperkraft()
        {
            System.Windows.MessageBox.Show(
                $"{Name} använder sin superkraft\n\n" +
                $"{SuperPower} \n\n" +
                $"och utför specialattacken\n\n" +
                $"{SpecialAttack}."
            );
        }
    }
}
