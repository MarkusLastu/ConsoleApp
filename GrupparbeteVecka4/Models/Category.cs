using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GrupparbeteVecka4.Models
{
    [Table("categories")]
    public class Category : BaseModel
    {
        [PrimaryKey("category_id")]
        public long Id { get; set; }

        [Column("category_name")]
        public string CategoryName { get; set; }

        [Column("category_image_url")]
        public string CategoryImageUrl { get; set; }
    }
}