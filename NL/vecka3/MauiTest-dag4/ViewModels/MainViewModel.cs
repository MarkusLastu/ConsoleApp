using MauiTest_dag4.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace MauiTest_dag4.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand InsertCatCommand { get; }
        public ICommand SearchCatCommand { get; }

        public MainViewModel()
        {
            InsertCatCommand = new RelayCommand(async () => await GoToInsertCat());
            SearchCatCommand = new RelayCommand(async () => await GoToSearchCat());
        }

        private async Task GoToInsertCat() => await Shell.Current.GoToAsync("InsertCatPage");
        private async Task GoToSearchCat() => await Shell.Current.GoToAsync("SearchCatPage");

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
