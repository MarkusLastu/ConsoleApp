using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Controls;

namespace V2_Dag5_Fredagsgodis
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string SuperPower { get; set; }
        public string Specialisering {  get; set; }
        public string SpecialAttack { get; set; }   
        public string Weakness { get; set; }    

        public Person(string name)
        {
            Name = name;            
        }
        public abstract string Presentera();
        public abstract void AnvandSuperkraft();
    }

    public class Musiker : Person
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
            // Musikerns superkraft
        }
    }

    public class Gymmare : Person
    {
        public int PbBank { get; set; } = 0;
        public Gymmare(string name, int pbBank) : base(name)
        {
            PbBank = pbBank;
        }

        public override string Presentera()
        {
            return 
                $"{Name} är gymmare och har {PbBank} pb i bänken." +
                $"{Name} har specialisering {Specialisering}." +
                $"{Name} har svaghet: {Weakness}.";
        }

        public override void AnvandSuperkraft()
        {
            System.Windows.MessageBox.Show(
                $"{Name} använder sin superkraft {SuperPower} och utför specialattacken {SpecialAttack}."
            );
        }
    }
}
