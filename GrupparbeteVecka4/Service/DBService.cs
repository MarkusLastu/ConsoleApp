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

        // ========================================== 
        // SELECT FROM DB
        // ========================================== 

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
        public async Task<List<Player>> GetPlayersAsync()
        {
            Debug.WriteLine($"Hämtar players från DB:");
            var result = await _client
                    .From<Player>()
                    .Select("*")
                    .Order(p => p.PlayerName, Supabase.Postgrest.Constants.Ordering.Ascending)
                    .Get();
            Debug.WriteLine($"{result.Count} players hämtade.");

            return result.Models;
        }


        // ========================================== 
        // INSERT INTO DB
        // ========================================== 



        public async Task<QuizSession> CreateQuizSessionAsync(QuizSession newSession)
        {
            Debug.WriteLine($"Skapar ny session: ");
            //StartTime & PlayerId
            var result = await _client
                .From<QuizSession>()
                .Insert(newSession);

            Debug.WriteLine($"Ny session skapad med ID: {result.Models.First().Id}");


            return result.Models.First();
        }
        public async Task SaveQuestionAnswerAsync(QuestionInSession newAnswer){
            Debug.WriteLine($"Skriver tiil DB: {newAnswer}");
            var result = await _client
                .From<QuestionInSession>()
                .Insert(newAnswer);
            Debug.WriteLine($"Skriver tiil DB: KLART!");
        }



        // ========================================== 
        // UPDATE DB
        // ========================================== 

        public async Task UpdateFinishedQuizSessionAsync(QuizSession finishedSession)
        {
            Debug.WriteLine("========== UPPDATERAR QUIZSESSION ==========");
            Debug.WriteLine($"SessionId: {finishedSession.Id}");
            Debug.WriteLine($"EndTime: {finishedSession.EndTime}");
            Debug.WriteLine($"Score: {finishedSession.Score}");

            try
            {
                var result = await _client
                        .From<QuizSession>()
                        .Where(s => s.Id == finishedSession.Id)
                        .Set(s => s.EndTime, finishedSession.EndTime)
                        .Set(s => s.Score, finishedSession.Score)
                        .Update();

                Debug.WriteLine($"Antal uppdaterade modeller: {result.Models.Count}");

                foreach (var session in result.Models)
                {
                    Debug.WriteLine($"Uppdaterad SessionId: {session.Id}");
                    Debug.WriteLine($"EndTime: {session.EndTime}");
                    Debug.WriteLine($"Score: {session.Score}");
                }

                Debug.WriteLine("============================================");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("========== UPDATE ERROR ==========");
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("==================================");

                throw;
            }
        }

        public async Task<List<QuizSession>> GetSessionsAsync(long playerId)
        {
            Debug.WriteLine($"Hämtar sessions från DB:");
            var result = await _client
                    .From<QuizSession>()
                    .Where(x => x.PlayerId == playerId)
                    .Select("*")
                    .Order(q => q.StartTime, Supabase.Postgrest.Constants.Ordering.Descending)
                    .Limit(4)
                    .Get();
                    
            Debug.WriteLine($"{result.Count} sessions hämtade.");

            return result.Models;
        }

        public async Task<dynamic> GetPlayerHistoryAsync(
            long playerId,
            int numberOfSessions)
        {
            var result = await _client.Rpc(
                "get_player_history",
                new Dictionary<string, object>
                {
                    { "p_player_id", playerId },
                    { "p_number_of_sessions", numberOfSessions }
                });
            Debug.WriteLine($"Hämtar historik för playerId: {playerId}, antal sessions: {numberOfSessions}");
            Debug.WriteLine(result.ToString());
            return result;
        }

        public async Task UpdateQuizSessionAsync()
        {
            Debug.WriteLine($"Uppdaterar sessionen med end_time och score.");

            Debug.WriteLine($"Sessionen uppdaterad");
        }   
    }
}