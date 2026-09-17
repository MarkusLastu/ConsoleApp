using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GrupparbeteVecka4.Models
{
    [Table("players")]
    public class Player : BaseModel
    {
        [PrimaryKey("player_id")]   //Andra parametern (false): Är en flagga för om värdet skapas automatiskt av databasen (till exempel en räknare som ökar med 1 för varje ny spelare, s.k. auto-increment eller identity).
        public long Id { get; set; }

        [Column("player_name")]
        public string PlayerName { get; set; }

        [Column("player_image_url")]
        public string PlayerImageUrl { get; set; }
    }
}