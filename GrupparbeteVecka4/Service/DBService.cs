using System;
using System.Collections.Generic;
//using static Android.Graphics.Paint;
using System.Diagnostics;
using System.Text;
using GrupparbeteVecka4.Models;
//using static Android.Graphics.Paint;


namespace GrupparbeteVecka4.Service
{
    public class DBService
    {
        private readonly Supabase.Client _client;

        public DBService()
        {
            _client = new Supabase.Client(
        "https://ktpuemywoxwbvgfmxubq.supabase.co",
        "sb_publishable_iOrATByFyeZdE6qcbiUdNw_H_UymafK");

        }


        public async Task<List<Question>> GetRandomQuestionsAsync(int numberOfQuestions)
        {
            try
            {
                var result = await _client
                    .From<Question>()
                    .Select("*")
                    .Get();

                Debug.WriteLine($"Antal frågor från DB: {result.Models.Count}");

                return result.Models
                    .OrderBy(q => Random.Shared.Next())
                    .Take(numberOfQuestions)
                    .ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("========== SUPABASE ERROR ==========");
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("====================================");

                throw;
            }
        }

        public async Task SaveQuestionAnswerAsync(QuestionInSession newAnswer){
            Debug.WriteLine($"Skriver tiil DB: {newAnswer}");
            var result = await _client
                .From<QuestionInSession>()
                .Insert(newAnswer);
            Debug.WriteLine($"Skriver tiil DB: KLART!");
        }
    }
}