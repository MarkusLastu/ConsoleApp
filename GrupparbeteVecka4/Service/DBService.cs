using System;
using System.Collections.Generic;
using System.Text;
//using static Android.Graphics.Paint;
using System.Diagnostics;
using GrupparbeteVecka4.Models;


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


        public async Task<List<long>> GetRandomQuestionIdsAsync(int numberOfQuestions)
        {
            var result = await _client
                .From<Question>()
                .Select("question_id")
                .Get();

            return result.Models
                .OrderBy(q => Random.Shared.Next())
                .Take(numberOfQuestions)
                .Select(q => q.Id)
                .ToList();
        }
        //public async Task<List<Question>> GetQuestionsAsync(List<long> randomQuestions)
        //{
        //    string questionIds = $"({string.Join(",", randomQuestions)})";

        //    var result = await _client
        //        .From<Question>()
        //        .Select("*, answers(*), categories(*)")
        //        .Filter(
        //            "question_id",
        //            Supabase.Postgrest.Constants.Operator.In,
        //            questionIds)
        //        .Get();

        //    return result.Models;
        //}

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
    }
}