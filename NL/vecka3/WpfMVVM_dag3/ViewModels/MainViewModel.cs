using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM_dag3.Commands;
using WpfMVVM_dag3.Models;
using WpfMVVM_dag3.Service;

namespace WpfMVVM_dag3.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private CatService catService;

        public event PropertyChangedEventHandler PropertyChanged;

        private List<Cat> cats;
        public List<Cat> Cats
        {
            get => cats;
            set
            {
                cats = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Cats)));
            }
        }

        private Cat selectedCat;
        public Cat SelectedCat
        {
            get => selectedCat;
            set
            {
                selectedCat = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCat)));
            }
        }

        private string selectedColor;
        public string SelectedColor
        {
            get => selectedColor;
            set
            {
                selectedColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedColor)));
            }
        }

        private List<Shelter> shelters;
        public List<Shelter> Shelters
        {
            get => shelters;
            set
            {
                shelters = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Shelters)));
            }
        }

        private Shelter selectedShelter;
        public Shelter SelectedShelter
        {
            get => selectedShelter;
            set
            {
                selectedShelter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedShelter)));
            }
        }

        public ICommand LoadCatsCommand { get; }
        public ICommand LoadCatsByColorCommand { get; }
        public ICommand LoadSheltersCommand { get; }
        public ICommand LoadCatsByShelterCommand { get; }

        public MainViewModel()
        {
            catService = new CatService();

            LoadCatsCommand = new RelayCommand(() => _ = LoadCats());
            LoadCatsByColorCommand = new RelayCommand(() => _ = LoadCatsByColor());
            LoadSheltersCommand = new RelayCommand(() => _ = LoadShelters());
            LoadCatsByShelterCommand = new RelayCommand(() => _ = LoadCatsByShelter());

            // Hämtar hemmen direkt vid start så att ComboBoxen har data
            _ = LoadShelters();
            _ = LoadCatsByColor();
        }

        public async Task LoadCats()
        {
            Cats = await catService.GetCats();
        }

        public async Task LoadCatsByColor()
        {
            if (!string.IsNullOrEmpty(SelectedColor))
                Cats = await catService.GetCatsByColor(SelectedColor);
        }

        public async Task LoadShelters()
        {
            Shelters = await catService.GetShelters();
        }

        public async Task LoadCatsByShelter()
        {
            if (SelectedShelter != null)
                Cats = await catService.GetCatsByShelter(SelectedShelter.Id);
        }
    }
}