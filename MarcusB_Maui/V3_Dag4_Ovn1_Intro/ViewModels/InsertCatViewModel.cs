using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel;
using V3_Dag4_Ovn1_Intro.Commands;
using V3_Dag4_Ovn1_Intro.Models;
using V3_Dag4_Ovn1_Intro.Service;
using V3_Dag4_Ovn1_Intro.Views;

namespace V3_Dag4_Ovn1_Intro.ViewModels
{
    public class InsertCatViewModel : INotifyPropertyChanged
    {
        private readonly CatService _service;
        private string name;
        private string age;
        private string color;
        private Shelter selectedShelter;


        private ObservableCollection<Shelter> shelters;
        public ObservableCollection<Shelter> Shelters
        {
            get { return shelters; }
            set
            {
                shelters = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Shelters)));
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Age)));
            }
        }

        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Color)));
            }
        }

        public Shelter SelectedShelter
        {
            get { return selectedShelter; }
            set
            {
                selectedShelter = value;
                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(SelectedShelter)));
            }
        }
        /*
        private async Task LoadShelters()
        {
            Debug.WriteLine("1. LoadShelters körs");
            Shelters = await _service.GetSheltersAsync();
            Debug.WriteLine($"2. Antal shelters: {Shelters.Count}");
        }

        */

        private async Task LoadShelters()
        {
            var shelters = await _service.GetSheltersAsync();

            foreach (var shelter in shelters)
            {
                Shelters.Add(shelter);
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }

        public InsertCatViewModel(CatService service)
        {
            _service = service;
            Shelters = new ObservableCollection<Shelter>();
            SaveCommand = new RelayCommand(SaveCat);
            BackCommand = new RelayCommand(GoBack);
            Debug.WriteLine("InsertCatViewModel skapas");

            _ = LoadShelters();
        }


        private async Task SaveCat()
        {
            Debug.WriteLine("1. SaveCat körs");
            // Kommer senare:
            // skapa Cat-objekt
            var newCat = new Cat
            {
                Name = name,
                Age = int.Parse(age),
                Color = color,
                ShelterId = SelectedShelter.Id
            };
            Debug.WriteLine("2. Cat-objekt skapat");

            // skicka det till Service
            await _service.InsertCatAsync(newCat);

            Debug.WriteLine("3. InsertCatAsync klar");
        }
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
