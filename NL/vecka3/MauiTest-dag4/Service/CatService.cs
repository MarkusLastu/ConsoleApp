using MauiTest_dag4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiTest_dag4
{
    public class CatService
    {
        private readonly Supabase.Client _client;

        public CatService()
        {
            _client = new Supabase.Client(
            "https://ezfckwjovbziivgdngge.supabase.co",
            "sb_publishable_bPfNWbHp5ProIAxBSAo2Ug_TyXN5n0m");
        }

        public async Task<List<Shelter>> GetSheltersAsync()
        {
            var result = await _client
                .From<Shelter>()
                .Get();

            return result.Models;
        }

        public async Task<List<Cat>> GetCatsAsync()
        {
            var result = await _client
                .From<Cat>()
                .Select("*, shelter:shelters(*)")
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

        public async Task InsertCatAsync(Cat cat)
        {
            await _client.From<Cat>().Insert(cat);
        }
    }
}
