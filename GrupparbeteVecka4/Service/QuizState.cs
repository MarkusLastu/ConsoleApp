using System;
using System.Collections.Generic;
using System.Text;

namespace GrupparbeteVecka4.Service
{
    public class QuizState
    {
        public long QuizSessionId { get; set; }
        public long QuizPlayerId { get; set; }
        public int QuizNumberOfQuestions { get; set; }
        public int QuizScore{ get; set; }
    }
}
