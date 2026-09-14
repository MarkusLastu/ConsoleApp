using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using V3_Dag3_Tutorial_MVVM2.Models;

namespace V3_Dag3_Tutorial_MVVM2.Service
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

        
        public async Task<List<Cat>> GetCats()
        {
            var result = await _client
                .From<Cat>()                
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

        public async Task<List<Cat>> GetCatsByColor(string color)
        {
            Debug.WriteLine("Kör GetCatsByColor");
            Debug.WriteLine(color);
            var result = await _client
                .From<Cat>()
                .Where(cat => cat.Color == color)
                .Get();

            return result.Models;
        }

        public async Task<List<Cat>> GetCatsByShelter(Shelter shelter)
        {
            Debug.WriteLine("Kör GetCatsByShelter");
            Debug.WriteLine(shelter.Name);
            var result = await _client
                .From<Cat>()
                .Select("*,Shelter(*)")
                .Where(cat => cat.ShelterId == shelter.Id)
                .Get();

            return result.Models;
        }
    }
}
