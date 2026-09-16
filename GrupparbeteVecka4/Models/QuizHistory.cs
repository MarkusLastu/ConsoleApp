using System.Text.Json.Serialization;
using GrupparbeteVecka4.Converters;

namespace GrupparbeteVecka4.Models;

public class QuizHistory
{
    [JsonPropertyName("quiz_session_id")]
    public long QuizSessionId { get; set; }

    [JsonPropertyName("score")]
    [JsonConverter(typeof(FlexibleIntConverter))]
    public int Score { get; set; }

    [JsonPropertyName("start_time")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("total_questions")]
    [JsonConverter(typeof(FlexibleIntConverter))]
    public int TotalQuestions { get; set; }

    [JsonPropertyName("is_correct")]
    public bool IsCorrect { get; set; } // Om din SQL JOIN skickar med is_correct per rad

    public string ScoreText => $"{Score} av {TotalQuestions} rätt";

    public string FormattedDate => StartTime.HasValue
        ? StartTime.Value.ToLocalTime().ToString("yyyy-MM-dd HH:mm")
        : "Okänt datum";
}
