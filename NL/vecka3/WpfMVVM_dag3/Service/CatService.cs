using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using System.Text;

using WpfMVVM_dag3.Models;

namespace WpfMVVM_dag3.Service
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

        public async Task<List<Cat>> GetCats()
        {
            var result = await _client
                .From<Cat>()
                .Select("*, shelter:shelters(*)")
                .Get();

            return result.Models;
        }

        public async Task<List<Cat>> GetCatsByColor(string color)
        {
            var result = await _client
                .From<Cat>()
                .Where(x => x.Color == color)
                .Get();
            return result.Models;
        }

        public async Task<List<Shelter>> GetShelters()
        {
            var result = await _client.From<Shelter>().Get();
            return result.Models;
        }

        public async Task<List<Cat>> GetCatsByShelter(long shelterId)
        {
            var result = await _client
                .From<Cat>()
                .Where(x => x.Shelter.Id == shelterId)
                .Get();
            return result.Models;
        }
    }
}