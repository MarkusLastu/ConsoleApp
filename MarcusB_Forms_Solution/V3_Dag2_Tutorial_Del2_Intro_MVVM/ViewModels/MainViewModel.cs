using System.Collections.ObjectModel;
using System.Diagnostics;
using Supabase;
using V3_Dag2_Tutorial_Del2_Intro_MVVM.Models;

namespace V3_Dag2_Tutorial_Del2_Intro_MVVM.ViewModels
{
    public class MainViewModel
    {
        private readonly Supabase.Client _client;        
        public ObservableCollection<Cat> Cats { get; set; }
        public ObservableCollection<Shelter> Shelters { get; set; }
        public Cat SelectedCat { get; set; }
        public Shelter SelectedShelter { get; set; }
        public MainViewModel()
        {
            _client = new Supabase.Client(            
            "https://hslfdhpruwakjtjjeliu.supabase.co",
            "sb_publishable_HiCLJR1gIrUCO5uM4_Z87A_l_nteqZS");
            Cats = new ObservableCollection<Cat>();
            Shelters = new ObservableCollection<Shelter>();
            //LoadCats();
            //LoadShelters();
            InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            await _client.InitializeAsync();
            await LoadCats();
            await LoadShelters();
        }
        private async Task LoadCats()
        {
            Debug.WriteLine("Laddar Cats från DB");
            await _client.InitializeAsync();
            var result = await _client
            .From<Cat>()
            .Get();

            foreach (Cat cat in result.Models)
            {
                Cats.Add(cat);
                Debug.WriteLine(cat.Name);
            }
        }

        private async Task LoadShelters()
        {
            Debug.WriteLine("Laddar Shelters från DB");
            await _client.InitializeAsync();
            var result = await _client
            .From<Shelter>()
            .Get();

            foreach (Shelter shelter in result.Models)
            {
                Shelters.Add(shelter);
                Debug.WriteLine(shelter.Name);
            }
        }
    }
}