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
public async Task<List<Question>> GetQuestionAsync()
        {
            var result = await _client
                .From<Question>()
                .Select("*, answers(*), categories(*)")
                .Get();

            return result.Models;
        }
    }
}