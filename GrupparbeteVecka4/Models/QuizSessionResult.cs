using System;
using System.Text.Json.Serialization;

namespace GrupparbeteVecka4.Models
{
    public class QuizSessionResult
    {
        [JsonPropertyName("quiz_session_id")]
        public long QuizSessionId { get; set; }

        [JsonPropertyName("start_time")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("end_time")]
        public DateTime? EndTime { get; set; }

        [JsonPropertyName("score")]
        public int? Score { get; set; }

        [JsonPropertyName("quiz_type_id")]
        public long QuizTypeId { get; set; }

        [JsonPropertyName("duration_seconds")]
        public int? DurationSeconds { get; set; }

        [JsonPropertyName("quiz_type_text")]
        public string QuizTypeText { get; set; }

        [JsonPropertyName("question_order")]
        public int QuestionOrder { get; set; }

        [JsonPropertyName("question_id")]
        public long QuestionId { get; set; }

        [JsonPropertyName("answer_id")]
        public long AnswerId { get; set; }

        [JsonPropertyName("response_time_ms")]
        public int ResponseTimeMs { get; set; }

        [JsonPropertyName("question_text")]
        public string QuestionText { get; set; }

        [JsonPropertyName("category_name")]
        public string CategoryName { get; set; }

        [JsonPropertyName("category_image_url")]
        public string CategoryImageUrl { get; set; }

        [JsonPropertyName("player_name")]
        public string PlayerName { get; set; }

        [JsonPropertyName("player_image_url")]
        public string PlayerImageUrl { get; set; }

        [JsonPropertyName("selected_answer_text")]
        public string SelectedAnswerText { get; set; }

        [JsonPropertyName("selected_answer_is_correct")]
        public bool SelectedAnswerIsCorrect { get; set; }

        [JsonPropertyName("correct_answer_text")]
        public string CorrectAnswerText { get; set; }
    }
}