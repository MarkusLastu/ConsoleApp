using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GrupparbeteVecka4.Models
{
    [Table("players")]
    public class PlayerModel : BaseModel
    {
        [PrimaryKey("player_id", false)]
        public int PlayerId { get; set; }

        [Column("player_name")]
        public string PlayerName { get; set; }

        [Column("player_image_url")]
        public string PlayerImageUrl { get; set; }
    }
}
