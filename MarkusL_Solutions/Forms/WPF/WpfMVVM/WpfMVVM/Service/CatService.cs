using System;
using System.Collections.Generic;
using System.Text;
using WpfMVVM.Models;
using WpfMVVM.Models;

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
    }
}
