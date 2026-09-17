using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GrupparbeteVecka4.Models;
using GrupparbeteVecka4.Service;

namespace GrupparbeteVecka4.ViewModels
{
    public class ProfileSelectViewModel : INotifyPropertyChanged
    {
        private readonly DBService _dbService;

        public ObservableCollection<Player> Players { get; set; } = new();

        private Player _selectedPlayer;
        public Player SelectedPlayer
        {
            get => _selectedPlayer;
            set
            {
                _selectedPlayer = value;
                OnPropertyChanged();
                if (_selectedPlayer != null)
                {
                    // Händelse när en befintlig spelare valts, t.ex. gå vidare till spelet
                    OnPlayerSelected(_selectedPlayer);
                }
            }
        }

        private string _newPlayerName;
        public string NewPlayerName
        {
            get => _newPlayerName;
            set { _newPlayerName = value; OnPropertyChanged(); }
        }

        public ICommand CreatePlayerCommand { get; }

        public ProfileSelectViewModel()
        {
            _dbService = new DBService();
            CreatePlayerCommand = new Command(async () => await CreateNewPlayer());
            _ = LoadPlayersAsync();
        }

        private async Task LoadPlayersAsync()
        {
            var list = await _dbService.GetPlayersAsync();
            Players.Clear();
            foreach (var p in list)
            {
                Players.Add(p);
            }
        }

        private async Task CreateNewPlayer()
        {
            if (string.IsNullOrWhiteSpace(NewPlayerName)) return;

            // Skapa i databasen
            var createdPlayer = await _dbService.CreatePlayerAsync(NewPlayerName);

            // Lägg till i listan och välj den
            Players.Add(createdPlayer);
            SelectedPlayer = createdPlayer;

            NewPlayerName = string.Empty;
        }

        private async void OnPlayerSelected(Player player)
        {
            // Exempel: Skicka med spelaren till nästa sida (Quiz-sidan)
            // await Shell.Current.GoToAsync($"QuizPage?playerId={player.PlayerId}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
