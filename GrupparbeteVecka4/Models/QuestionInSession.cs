using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace GrupparbeteVecka4.Models
{
    [Table("questions_in_session")]
    public class QuestionInSession : BaseModel
    {
        [PrimaryKey("questions_in_session_id")]
        public long Id { get; set; }

        [Column("quiz_session_id")]
        public long QuizSessionId { get; set; }

        [Column("question_id")]
        public long QuestionId { get; set; }

        [Column("answer_id")]
        public long? AnswerId { get; set; }

        [Column("question_order")]
        public int QuestionOrder { get; set; }

        [Column("response_time_ms")]
        public int ResponseTimeMs { get; set; }

        [Reference(typeof(QuizSession))]
        public QuizSession QuizSession { get; set; }

        [Reference(typeof(Question))]
        public Question Question { get; set; }

        [Reference(typeof(Answer))]
        public Answer Answer { get; set; }
    }
}