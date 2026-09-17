using System;
using System.Collections.Generic;
using System.Text;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;

namespace GrupparbeteVecka4.Models
{
    [Table("quiz_sessions")]
    public class QuizSession : BaseModel
    {
        [PrimaryKey("quiz_session_id")]
        public long Id { get; set; }

        [Column("start_time")]
        public DateTime StartTime { get; set; }

        [Column("end_time")]
        public DateTime? EndTime { get; set; }

        [Column("score")]
        public int? Score { get; set; }

        [Column("player_id")]
        public long PlayerId { get; set; }

        [Column("quiz_type_id")]
        public long QuizTypeId{ get; set; }

        [Column("duration_seconds")]
        public int? DurationSeconds { get; set; }

        [Reference(typeof(Player))]
        public Player Player { get; set; }
        
        [Reference(typeof(QuizType))]
        public QuizType QuizType { get; set; }
    }
}