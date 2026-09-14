using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GrupparbeteVecka4.Models
{
    [Table("answers")]
    public class Answer : BaseModel
    {
        [PrimaryKey("answer_id")]
        public long Id { get; set; }

        [Column("answer_text")]
        public string AnswerText { get; set; }

        [Column("question_id")]
        public long QuestionId { get; set; }

        [Column("is_correct")]
        public bool IsCorrect { get; set; }
    }
}

