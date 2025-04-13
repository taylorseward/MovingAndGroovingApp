using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using MovingAndGroovingApp.Models;
using MovingAndGroovingApp.Services;
using MovingAndGroovingApp.Views;
using System.Threading.Tasks;

namespace MovingAndGroovingApp.ViewModels
{
    public class JoinTeamViewModel
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Team> Teams { get; } = new ObservableCollection<Team>();

        public Command<Team> JoinTeamCommand { get; }

        public JoinTeamViewModel()
        {
            _databaseService = new DatabaseService();
            JoinTeamCommand = new Command<Team>(OnJoinTeam);
        }

        // Load the teams from the database
        public async Task LoadTeamsAsync()
        {
            var teamsFromDb = await _databaseService.GetAllTeamsAsync();
            Teams.Clear();
            foreach (var team in teamsFromDb)
            {
                Teams.Add(team);
            }
        }

        // Handle joining the team
        private async void OnJoinTeam(Team selectedTeam)
        {
            if (selectedTeam != null)
            {
                // Assuming you have a method to get the current user (e.g., from UserService)
                var currentUser = await _databaseService.GetCurrentUserAsync();

                if (currentUser != null)
                {
                    // Join the selected team by passing both the selected team and the current user
                    await _databaseService.JoinTeamAsync(selectedTeam, currentUser);

                    // Navigate back to the TeamPage or elsewhere
                    await Shell.Current.GoToAsync(nameof(TeamPage));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No user logged in.", "OK");
                }
            }
        }

    }
}
