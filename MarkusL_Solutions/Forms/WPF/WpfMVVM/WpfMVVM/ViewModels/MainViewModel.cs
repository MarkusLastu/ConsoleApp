using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM.Models;
using WpfMVVM.Service;
using WpfMVVM.Commands;

namespace WpfMVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Cat> listaMedKatter;
        public List<Cat> Cats
        {
            get { return listaMedKatter; }
            set
            {
                listaMedKatter = value;

                OnPropertyChanged(nameof(Cats));
            }
        }

        private List<Shelter> listaMedKatthem;
        public List<Shelter> Shelters
        {
            get { return listaMedKatthem; }
            set
            {
                listaMedKatthem = value;
                OnPropertyChanged(nameof(Shelters));
            }
        }

        private List<string> colors;
        public List<string> Colors
        {
            get { return colors; }
            set
            {
                colors = value;
                OnPropertyChanged(nameof(Colors));
            }
        }




        private Cat valdKatt;
        public Cat SelectedCat
        {
            get { return valdKatt; }
            set
            {
                valdKatt = value;
                OnPropertyChanged(nameof(SelectedCat));
            }
        }

        private Shelter valtShelter;
        public Shelter SelectedShelter
        {
            get { return valtShelter; }
            set
            {
                valtShelter = value;
                OnPropertyChanged(nameof(SelectedShelter));
            }
        }

        private string valdColor;
        public string SelectedColor
        {
            get { return valdColor; }
            set
            {
                valdColor = value;
                OnPropertyChanged(nameof(SelectedColor));
            }
        }


        public ICommand LoadCatsCommand { get; }
        public ICommand SearchCommand { get; }
        //public ICommand LoadShelterCommand { get; }
        //public ICommand LoadCatsByColorCommand { get; }
        //public ICommand LoadCatsByShelterIdCommand { get; }


        public event PropertyChangedEventHandler PropertyChanged;

        private CatService catService;
        public MainViewModel()
        {
            catService = new CatService();

            _ = LoadShelters();
            //_ = LoadCats();

            LoadCatsCommand = new RelayCommand(async () => await LoadCats());
            SearchCommand = new RelayCommand(async () => await Search());
            //LoadCatsByColorCommand = new RelayCommand(async () => await LoadCatsByColor());
            //LoadCatsByShelterIdCommand = new RelayCommand(async () => await LoadCatsByShelterId());
            //LoadShelterCommand = new RelayCommand(async () => await LoadShelters());
        }


        public async Task LoadCats()
        {

            SelectedShelter = null;
            SelectedColor = null;

            Cats = await catService.GetCats();
            await LoadColors();
        }

        public async Task Search()
        {
            bool hasShelter = SelectedShelter != null;
            bool hasColor = !string.IsNullOrEmpty(SelectedColor);

            if (hasShelter && hasColor)
            {
                Cats = await catService.GetCatsByShelterAndColor(SelectedShelter.Id, SelectedColor);
            }
            else if (hasShelter)
            {
                Cats = await catService.GetCatsByShelter(SelectedShelter.Id);
            }
            else if (hasColor)
            {
                Cats = await catService.GetCatsByColor(SelectedColor);
            }
            else
            {
                await LoadCats();
            }
        }

        
        public Task LoadColors()
        {
            if (Cats != null)
            {
                Colors = Cats
                    .Where(c => !string.IsNullOrEmpty(c.Color))
                    .Select(c => c.Color)
                    .Distinct()
                    .ToList();
            }

            return Task.CompletedTask;
        }

        /*
        public async Task LoadCatsByColor()
        {
            if (!string.IsNullOrEmpty(SelectedColor))
            {
                Cats = await catService.GetCatsByColor(SelectedColor);
            }
        }
        */

        public async Task LoadShelters()
        {
            Shelters = await catService.GetShelters();
        }

        /*
        public async Task LoadCatsByShelterId()
        {
            if (SelectedShelter != null)
            {
                Cats = await catService.GetCatsByShelter(SelectedShelter.Id);
            }
        }
        */


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this, 
                new PropertyChangedEventArgs(propertyName));
        }

    }

}
