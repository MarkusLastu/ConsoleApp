using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace V3_Dag2_Tutorial_Del2_Intro_MVVM.Models

{
    [Table("cats")]
    public class Cat : BaseModel
    {
        [PrimaryKey("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("age")]
        public int Age { get; set; }
        [Column("color")]
        public string Color { get; set; }
    }
}