using MovingAndGroovingApp.Services;
using MovingAndGroovingApp.ViewModels;
using Microsoft.Maui.Controls;

namespace MovingAndGroovingApp.Views
{
    public partial class TeamPage : ContentPage
    {
        private readonly TeamViewModel _viewModel;

        public TeamPage(DatabaseService databaseService)
        {
            InitializeComponent();
            _viewModel = new TeamViewModel(databaseService);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadTeamsAsync();
        }

        // Navigate to CreateTeamPage
        private async void OnCreateTeamClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CreateTeamPage));
        }

        // Navigate to JoinTeamPage
        private async void OnJoinTeamClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(JoinTeamPage));
        }
    }
}
