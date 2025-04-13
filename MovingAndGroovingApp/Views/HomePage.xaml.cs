using Microsoft.Maui.Controls;
using MovingAndGroovingApp.ViewModels;
using MovingAndGroovingApp.Services;
using MovingAndGroovingApp.Models;
using MovingAndGroovingApp.Views;

namespace MovingAndGroovingApp.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        BindingContext = new HomeViewModel();
    }

	public async void OnWorkoutsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(WorkoutLogPage));
    }

    public async void OnTeamClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(TeamPage));
    }
}