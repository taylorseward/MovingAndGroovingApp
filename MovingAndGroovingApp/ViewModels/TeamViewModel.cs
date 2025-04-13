using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MovingAndGroovingApp.Models;
using MovingAndGroovingApp.Services;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using MovingAndGroovingApp.Views;

namespace MovingAndGroovingApp.ViewModels
{
    public class TeamViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Team> Teams { get; } = new ObservableCollection<Team>();

        public ICommand CreateTeamCommand { get; }
        public ICommand JoinTeamCommand { get; }

        public TeamViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            CreateTeamCommand = new Command(OnCreateTeam);
            JoinTeamCommand = new Command(OnJoinTeam);
        }

        private async void OnCreateTeam()
        {
            await Shell.Current.GoToAsync(nameof(CreateTeamPage));
        }

        private async void OnJoinTeam()
        {
            await Shell.Current.GoToAsync(nameof(JoinTeamPage));
        }

        public async Task LoadTeamsAsync()
        {
            Teams.Clear();
            var teamsFromDb = await _databaseService.GetAllTeamsAsync();
            foreach (var team in teamsFromDb)
            {
                Teams.Add(team);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
