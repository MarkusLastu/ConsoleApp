using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization; // För JsonIgnore
using Microsoft.Maui.Controls;
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

        // Hjälpegenskap som hanterar både webb-URLer och lokala bildfiler säkert
        [JsonIgnore]
        public ImageSource AvatarSource
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(PlayerImageUrl))
                {
                    // Kolla om det är en fullständig URL (http:// eller https://)
                    if (Uri.TryCreate(PlayerImageUrl, UriKind.Absolute, out Uri validUri)
                        && (validUri.Scheme == Uri.UriSchemeHttp || validUri.Scheme == Uri.UriSchemeHttps))
                    {
                        return ImageSource.FromUri(validUri);
                    }

                    // Om det är ett filnamn/relativ sökväg (t.ex. "avatar.png")
                    return ImageSource.FromFile(PlayerImageUrl);
                }

                // Standardbild om bild saknas helt i databasen
                return ImageSource.FromFile("user_placeholder.png");
            }
        }
    }
}
    
