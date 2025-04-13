using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using MovingAndGroovingApp.Models;
using MovingAndGroovingApp.Services;
using MovingAndGroovingApp.Views;

namespace MovingAndGroovingApp.ViewModels
{
    public class CreateTeamViewModel
    {
        private readonly DatabaseService _databaseService;

        public string TeamName { get; set; }
        public string TeamDescription { get; set; }

        public Command CreateTeamCommand { get; }

        public CreateTeamViewModel()
        {
            _databaseService = new DatabaseService();
            CreateTeamCommand = new Command(OnCreateTeam);
        }

        private async void OnCreateTeam()
        {
            if (string.IsNullOrWhiteSpace(TeamName) || string.IsNullOrWhiteSpace(TeamDescription))
            {
                // Show an error message to the user (e.g., via an Alert)
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all fields", "OK");
                return;
            }

            var team = new Team
            {
                TeamName = TeamName,
                TeamDescription = TeamDescription,
                TeamTotalMinutes = 0, // Default starting value
                TeamPhotoPath = "" // You can handle team photo path if necessary
            };

            await _databaseService.AddTeamAsync(team);

            // Navigate back to the TeamPage (or wherever appropriate)
            await Shell.Current.GoToAsync(nameof(TeamPage));
        }
    }
}
