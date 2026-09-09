using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace vecka3_1.Models
{
    [Table("shelters")]
    public class Shelter : BaseModel
    {
        [PrimaryKey("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("city")]
        public string City { get; set; }
        public override string ToString()
        {
            return $" {Name} ( {City} )";
        }
    }
}