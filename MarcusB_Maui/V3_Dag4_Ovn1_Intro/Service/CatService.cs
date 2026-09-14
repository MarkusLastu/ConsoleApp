using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using V3_Dag4_Ovn1_Intro.Models;

namespace V3_Dag4_Ovn1_Intro.Service
{
    public class CatService
    {
        private readonly Supabase.Client _client;

        public CatService()
        {
            _client = new Supabase.Client(
                "https://hslfdhpruwakjtjjeliu.supabase.co",
                "sb_publishable_HiCLJR1gIrUCO5uM4_Z87A_l_nteqZS");
        }

        public async Task<List<Cat>> GetCatsAsync()
        {
            var result = await _client
                .From<Cat>()
                .Select("*, shelter:shelters(*)")
                .Get();

            return result.Models;
        }
        public async Task<List<Shelter>> GetSheltersAsync()
        {
            var result = await _client
                .From<Shelter>()                
                .Get();

            return result.Models;
        }
        public async Task<List<Cat>> SearchCatsAsync(string name)
        {
            var result = await _client
                .From<Cat>()
                .Select("*, shelter:shelters(*)")
                .Filter("name", Supabase.Postgrest.Constants.Operator.Equals, name)
                .Get();

            return result.Models;
        }

        public async Task InsertCatAsync(Cat newCat)
        {
            Debug.WriteLine("4. InsertCatAsync körs");
            await _client
                .From<Cat>()                
                .Insert(newCat);
            Debug.WriteLine("5. Supabase Insert klar");
        }
        
    }
}
