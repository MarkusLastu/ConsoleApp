using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;
using V3_Dag3_Tutorial_MVVM2.Models;
using V3_Dag3_Tutorial_MVVM2.Service;
using V3_Dag3_Tutorial_MVVM2.Commands;
using System.Windows.Media;
using System.Diagnostics;

namespace V3_Dag3_Tutorial_MVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        // Listor som populerar comboboxar och listboxar
        private List<Cat> listaMedKatter;
        public List<Cat> Cats
        {
            get { return listaMedKatter; }
            set
            {
                listaMedKatter = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Cats)));
            }
        }
        private List<string> catColorList;
        public List<string> CatColors
        {
            get { return catColorList; }
            set
            {
                catColorList = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(CatColors)));
            }
        }

        private List<Shelter> shelterList;
        public List<Shelter> Shelters
        {
            get { return shelterList; }
            set
            {
                shelterList = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(Shelters)));
            }
        }

        // Variabler som visar valda objekt
        private Cat valdKatt;

        public Cat SelectedCat
        {
            get { return valdKatt; }

            set
            {
                valdKatt = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(SelectedCat)));
            }
        }

        private string valdFarg;

        public string SelectedColor
        {
            get { return valdFarg; }

            set
            {
                valdFarg = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(SelectedColor)));
            }
        }
        private Shelter valtShelter;

        public Shelter SelectedShelter
        {
            get { return valtShelter; }

            set
            {
                valtShelter = value;

                PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(SelectedShelter)));
            }
        }


        // Om något värde ändras så uppdateras boxarna
        public event PropertyChangedEventHandler PropertyChanged;

        // Variabel som håller i instancen av CatService 
        private CatService catService;
        public ICommand LoadCatsCommand { get; }
        public ICommand LoadCatsByColorCommand { get; }
        public ICommand LoadCatsByShelterCommand { get; }
        public MainViewModel()
        {
            catService = new CatService();
            // _ = LoadShelters();
            LoadCatsCommand = new RelayCommand(() => LoadCats());
            LoadCatsByColorCommand = new RelayCommand(() => LoadCatsByColor(valdFarg));
            LoadCatsByShelterCommand = new RelayCommand(() => LoadCatsByShelter(valtShelter));
        }

        // Laddar allt genom att anropa catService
        public async Task LoadCats()
        {
            Debug.WriteLine("Kör LoadCats");
            Debug.WriteLine("Kallar på GetCats");
            Cats = await catService.GetCats();
            foreach (Cat c in Cats)
            {
                Debug.WriteLine(c);
            }
            await LoadColors();
            await LoadShelters();
        }
        public async Task LoadColors()
        {
            Debug.WriteLine("Kör LoadColors");
            CatColors = Cats
            .Select(cat => cat.Color)
            .Distinct()
            .OrderBy(color => color)
            .ToList();

            // CatColors.Insert(0, "");

            foreach (string color in CatColors)
            {
                Debug.WriteLine(color);
            }
        }

        public async Task LoadShelters()
        {
            Debug.WriteLine("Kör LoadShelters");
            Shelters = await catService.GetShelters();
            foreach (Shelter s in Shelters)
            {
                Debug.WriteLine($"{s.Name} - {s.City}");
            }
        }

        public async Task LoadCatsByColor(string color)
        {
            Cats = await catService.GetCatsByColor(color);
        }

        public async Task LoadCatsByShelter(Shelter shelter)
        {
            Cats = await catService.GetCatsByShelter(shelter);
            foreach (Shelter s in Shelters)
            {
                Debug.WriteLine($"{s.Name} - {s.City}");
            }
        }
    }
}





