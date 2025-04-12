using MovingAndGroovingApp.ViewModels;
using MovingAndGroovingApp.Services;

namespace MovingAndGroovingApp.Views;

public partial class WorkoutLogPage : ContentPage
{
	private readonly WorkoutLogViewModel _workoutLogViewModel;
	public WorkoutLogPage(DatabaseService databaseService)
	{
		InitializeComponent();
		_workoutLogViewModel = new WorkoutLogViewModel(databaseService);
		BindingContext = _workoutLogViewModel;
	}

	private async void OnAddWorkoutClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("AddWorkoutPage");
	}
}