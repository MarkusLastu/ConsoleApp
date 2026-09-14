using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GrupparbeteVecka4.Models
{
    [Table("questions")]
    public class Question : BaseModel
    {
        [PrimaryKey("question_id")]
        public long Id { get; set; }

        [Column("question")]
        public string QuestionText { get; set; }

        [Column("category_id")]
        public long CategoryId { get; set; }

        [Column("question_image_url")]
        public string QuestionImageUrl { get; set; }

        [Reference(typeof(Category))]
        public Category Category { get; set; }

        [Reference(typeof(Answer))]
        public List<Answer> Answers { get; set; }
    }
}


