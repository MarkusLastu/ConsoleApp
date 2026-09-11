using MauiTest_dag4.Commands;
using MauiTest_dag4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace MauiTest_dag4.ViewModels
{
    public class InsertCatViewModel : INotifyPropertyChanged
    {
        private readonly CatService _service;

        private string name;
        private string age;
        private string color;
        private Shelter selectedShelter;
        private List<Shelter> shelters;

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Age
        {
            get => age;
            set { age = value; OnPropertyChanged(nameof(Age)); }
        }

        public string Color
        {
            get => color;
            set { color = value; OnPropertyChanged(nameof(Color)); }
        }

        // Listan som fyller dropdown-menyn
        public List<Shelter> Shelters
        {
            get => shelters;
            set { shelters = value; OnPropertyChanged(nameof(Shelters)); }
        }

        // Det valda katthemmet från dropdown-menyn
        public Shelter SelectedShelter
        {
            get => selectedShelter;
            set { selectedShelter = value; OnPropertyChanged(nameof(SelectedShelter)); }
        }

        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }

        public InsertCatViewModel(CatService service)
        {
            _service = service;

            SaveCommand = new RelayCommand(async () => await SaveCat());
            BackCommand = new RelayCommand(async () => await GoBack());

            // Ladda alla katthem när ViewModel skapas
            _ = LoadSheltersAsync();
        }

        private async Task LoadSheltersAsync()
        {
            Shelters = await _service.GetSheltersAsync();
        }

        private async Task SaveCat()
        {
            // Validera att fälten är ifyllda och ett katthem är valt
            if (string.IsNullOrWhiteSpace(Name) ||
                !int.TryParse(Age, out int parsedAge) ||
                SelectedShelter == null)
            {
                return;
            }

            var newCat = new Cat
            {
                Name = Name,
                Age = parsedAge,
                Color = Color,
                ShelterId = SelectedShelter.Id // Hämta ID från det valda katthemmet
            };

            await _service.InsertCatAsync(newCat);
            await GoBack();
        }

        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
