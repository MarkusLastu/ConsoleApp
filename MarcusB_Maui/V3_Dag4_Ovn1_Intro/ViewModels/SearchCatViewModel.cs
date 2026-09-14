using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using V3_Dag4_Ovn1_Intro.Commands;
using V3_Dag4_Ovn1_Intro.Models;
using V3_Dag4_Ovn1_Intro.Service;


namespace V3_Dag4_Ovn1_Intro.ViewModels
{
    public class SearchCatViewModel : INotifyPropertyChanged
    {
        private readonly CatService _service;
        private List<Cat> cats;
        public List<Cat> Cats
        {
            get { return cats; }
            set
            {
                cats = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Cats)));
            }
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(SearchText)));
            }
        }

        public ICommand SearchCommand { get; }
        public ICommand BackCommand { get; }

        public SearchCatViewModel(CatService service)
        {
            _service = service;
            SearchCommand = new RelayCommand(SearchCats);            
        }

        //private async Task SearchCatsList()
        //{
        //    Cats = await _service.GetCatsAsync();
        //}

        private async Task SearchCats()
        {
            Cats = await _service.SearchCatsAsync(SearchText);
        }
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
