using Supabase.Postgrest.Attributes;
using System.Text.Json.Serialization;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiTest_dag4.Models
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

        // Denna egenskap formaterar namnet och staden snyggt
        [JsonIgnore]
        public string DisplayName => string.IsNullOrWhiteSpace(City)
                ? Name
                : $"{Name} ({City})";
    }
}