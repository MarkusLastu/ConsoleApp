using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
namespace vecka3_1.Models
{
    [Table("cats")]
    public class Cat : BaseModel
    {
        [PrimaryKey("id")]
        public long Id { get; set; }
        [Column("shelter_id")]
        public long ShelterId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("age")]
        public int Age { get; set; }
        [Column("color")]

        public string Color { get; set; }

        [Reference(typeof(Shelter))]
        public Shelter Shelter { get; set; }
        //public override string ToString()
        //{
        //return Name;
        //}

    }
}