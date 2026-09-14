using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GrupparbeteVecka4.Models
{
    
    [Table("cats")]
    public class Xxx : BaseModel
    {
        [PrimaryKey("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("color")]
        public string Color { get; set; }

        [Column("shelter_id")]
        public long ShelterId { get; set; }


        // [Reference(typeof(Shelter))]
        // public Shelter Shelter { get; set; }

    }
}

