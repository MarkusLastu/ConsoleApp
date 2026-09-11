using MauiTest_dag4.Commands;
using MauiTest_dag4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace MauiTest_dag4.ViewModels
{
    public class SearchCatViewModel : INotifyPropertyChanged
    {
        private readonly CatService _catService;
        private List<Cat> _cats;
        private string _searchText;

        public List<Cat> Cats
        {
            get => _cats;
            set { _cats = value; OnPropertyChanged(nameof(Cats)); }
        }

        public string SearchText
        {
            get => _searchText;
            set { _searchText = value; OnPropertyChanged(nameof(SearchText)); }
        }

        public ICommand SearchCommand { get; }
        public ICommand BackCommand { get; }

        public SearchCatViewModel(CatService catService)
        {
            _catService = catService;
            SearchCommand = new RelayCommand(async () => await SearchCat());
            BackCommand = new RelayCommand(async () => await Shell.Current.GoToAsync(".."));
        }

        private async Task SearchCat()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                Cats = await _catService.GetCatsAsync();
            else
                Cats = await _catService.SearchCatsAsync(SearchText);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
