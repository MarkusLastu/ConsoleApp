using System;
using System.Collections.Generic;
using System.Text;
using WpfMvvmDemo.Models;
using Supabase;
using System.Collections.ObjectModel;

namespace WpfMvvmDemo.ViewModels
{
    public class MainViewModel
    {

        //internal class MainViewModel
        //{
        //}


        private readonly Supabase.Client _client;
        //public List<Cat> Cats { get; set; }
        public ObservableCollection<Cat> Cats { get; set; }
        public Cat SelectedCat { get; set; }

        public MainViewModel()
        {
            _client = new Supabase.Client(
            "https://ezfckwjovbziivgdngge.supabase.co",
            "sb_publishable_bPfNWbHp5ProIAxBSAo2Ug_TyXN5n0m");

            Cats = new ObservableCollection<Cat>();
            LoadCats();

        }
        private async void LoadCats()
        {
            await _client.InitializeAsync();
            var result = await _client
            .From<Cat>()
            .Get();
            foreach (Cat cat in result.Models)
            {
                Cats.Add(cat);
            }
        }
    }
    
}

