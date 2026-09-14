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
        [PrimaryKey("player_id")]
        public long Id { get; set; }

        [Column("player_name")]
        public string PlayerName { get; set; }

        [Column("player_image_url")]
        public string PlayerImageUrl { get; set; }
    }
}