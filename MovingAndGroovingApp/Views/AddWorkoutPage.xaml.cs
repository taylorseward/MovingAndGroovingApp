using MovingAndGroovingApp.Models;
using MovingAndGroovingApp.Services;
using MovingAndGroovingApp.ViewModels;
using MovingAndGroovingApp.Views;

namespace MovingAndGroovingApp.Views;

public partial class AddWorkoutPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public AddWorkoutPage(DatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
        BindingContext = new AddWorkoutViewModel(_databaseService);
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var viewModel = (AddWorkoutViewModel)BindingContext;

        bool isMinutesValid = int.TryParse(minutesEntry.Text, out int minutes);
        bool isHoursValid = int.TryParse(hoursEntry.Text, out int hours);

        if (isMinutesValid && isHoursValid)
        {
            var workout = new WorkoutLog
            {
                WorkoutType = viewModel.SelectedWorkoutType,
                Hours = hours,
                Minutes = minutes,
                Date = viewModel.WorkoutDate
            };

            await _databaseService.AddWorkoutAsync(workout);
            await DisplayAlert("Success", "Workout logged!", "OK");
            await Shell.Current.GoToAsync("..");
        }
        else
        {
            await DisplayAlert("Error", "Please enter valid hours and minutes.", "OK");
        }
    }


    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
