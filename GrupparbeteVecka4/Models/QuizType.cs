using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GrupparbeteVecka4.Models
{
    [Table("quiz_types")]
    public class QuizType: BaseModel
    {
        [PrimaryKey("quiz_type_id")]
        public long Id { get; set; }

        [Column("quiz_type_text")]
        public string QuizTypeText { get; set; }

        [Column("wrong_answer_penalty")]
        public int WrongAnswerPenalty { get; set; }
    }
}