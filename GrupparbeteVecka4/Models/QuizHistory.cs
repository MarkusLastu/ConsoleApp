using System;
using System.Collections.Generic;
using System.Text;

namespace GrupparbeteVecka4.Models
{
    public class QuizHistory
    {
        public long QuizSessionId { get; set; }
        public int Score { get; set; }
        public DateTime StartTime { get; set; }
        public int TotalQuestions { get; set; }

        public string ScoreText => $"{Score} av {TotalQuestions} rätt";
        public string FormattedDate => StartTime.ToString("yyyy-MM-dd HH:mm");
    }
}
