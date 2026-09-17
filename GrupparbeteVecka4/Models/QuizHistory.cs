using System;
using System.Text.Json.Serialization;

namespace GrupparbeteVecka4.Models
{
    public class QuizHistory
    {
        [JsonPropertyName("quiz_session_id")]
        public long QuizSessionId { get; set; }

        [JsonPropertyName("quiz_type_id")]
        public long QuizTypeId { get; set; }

        [JsonPropertyName("player_name")]
        public string? PlayerName { get; set; }

        [JsonPropertyName("player_image_url")]
        public string? PlayerImageUrl { get; set; }

        [JsonPropertyName("start_time")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("end_time")]
        public DateTime? EndTime { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("question_order")]
        public int QuestionOrder { get; set; }

        [JsonPropertyName("question_id")]
        public long QuestionId { get; set; }

        [JsonPropertyName("question_text")]
        public string? QuestionText { get; set; }

        [JsonPropertyName("question_image_url")]
        public string? QuestionImageUrl { get; set; }

        [JsonPropertyName("answer_id")]
        public long AnswerId { get; set; }

        [JsonPropertyName("answer_text")]
        public string? AnswerText { get; set; }

        [JsonPropertyName("is_correct")]
        public bool IsCorrect { get; set; }

        [JsonPropertyName("response_time_ms")]
        public int ResponseTimeMs { get; set; }

        [JsonPropertyName("category_name")]
        public string? CategoryName { get; set; }

        [JsonPropertyName("category_image_url")]
        public string? CategoryImageUrl { get; set; }

        [JsonPropertyName("quiz_type_text")]
        public string? QuizTypeText { get; set; }

        // Beräknade/Aggregerade egenskaper för gränssnittet
        public int TotalQuestions { get; set; }
        public int CorrectAnswersCount { get; set; }
        public string FormattedDate => StartTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm");
        public string DurationText
        {
            get
            {
                if (EndTime.HasValue)
                {
                    var duration = EndTime.Value - StartTime;
                    return $"{duration.Minutes}m {duration.Seconds}s";
                }
                return "-";
            }
        }
    }
}