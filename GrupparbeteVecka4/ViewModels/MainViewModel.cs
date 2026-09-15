using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using GrupparbeteVecka4.Commands;

namespace GrupparbeteVecka4.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand InsertCatCommand { get; }
        public ICommand SearchCatCommand { get; }

        public MainViewModel()
        {
            //InsertCatCommand = new RelayCommand(InsertCat);
            //SearchCatCommand = new RelayCommand(SearchCat);
        }

        private async Task InsertCat()
        {
            await Shell.Current.GoToAsync("InsertCatPage");
        }

        private async Task SearchCat()
        {
            await Shell.Current.GoToAsync("SearchCatPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

