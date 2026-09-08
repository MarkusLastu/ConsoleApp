using Intro_MVVM.Models;
using Supabase;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Intro_MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly Supabase.Client _client;

        private List<Cat> _cats;
        private Cat _selectedCat;

        public List<Cat> Cats
        {
            get { return _cats; }
            set
            {
                _cats = value;
                OnPropertyChanged();
            }
        }

        public Cat SelectedCat
        {
            get { return _selectedCat; }
            set
            {
                _selectedCat = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            _client = new Supabase.Client(
                "https://mjmcqdfgsydprdhayxur.supabase.co",
                "sb_publishable_fj51hH9OZ7HMyfrAkiea7g_Ehq3uWgn"
            );
        }

        public async Task InitializeAsync()
        {
            await _client.InitializeAsync();
            await LoadCats();
        }

        private async Task LoadCats()
        {
            var result = await _client
                .From<Cat>()
                .Get();

            Cats = result.Models;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}