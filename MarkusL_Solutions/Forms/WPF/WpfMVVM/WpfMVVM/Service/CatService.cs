using System;
using System.Collections.Generic;
using System.Text;
using WpfMVVM.Models;
using static Supabase.Postgrest.Constants;

namespace WpfMVVM.Service
{
    public class CatService
    {
        private readonly Supabase.Client _client;

        public CatService()
        {
            _client = new Supabase.Client(
                "https://mjmcqdfgsydprdhayxur.supabase.co",
                "sb_publishable_fj51hH9OZ7HMyfrAkiea7g_Ehq3uWgn");
        }

        public async Task<List<Cat>> GetCats()
        {
            var result = await _client
                .From<Cat>()
                .Get();
            return result.Models;
        }

        public async Task<List<Cat>> GetCatsByColor(string color)
        {
            var result = await _client
                .From<Cat>()
                //.Where(c => c.Color == color)
                .Filter(c => c.Color, Operator.ILike, $"%{color}%")
                .Get();
            return result.Models;
        }

        public async Task<List<Shelter>> GetShelters()
        {
            var result = await _client
                .From<Shelter>()
                .Get();
            return result.Models;
        }

        public async Task<List<Cat>> GetCatsByShelter(long shelterId)
        {
            var result = await _client
                .From<Cat>()
                //.Filter(c => c.Shelter.Id, Operator.Equals, shelterId)
                .Filter(c => c.ShelterId, Operator.Equals, shelterId)
                //.Filter("shelter_id", Operator.Equals, shelterId)
                //.Where(c => c.ShelterId == shelterId)
                .Get();
            return result.Models;
        }

        public async Task<List<Cat>> GetCatsByShelterAndColor(long shelterId, string color)
        {
            var result = await _client
                .From<Cat>()
                .Filter("shelter_id", Operator.Equals, shelterId)
                .Filter(c => c.Color, Operator.ILike, $"%{color}%")
                //.Where(c => c.ShelterId == shelterId && c.Color == color)
                .Get();

            return result.Models;
        }
    }
}
