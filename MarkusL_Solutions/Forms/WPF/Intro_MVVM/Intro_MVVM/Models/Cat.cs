using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intro_MVVM.Models
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
        public override string ToString()
        {
            return Name;
        }
    }
}