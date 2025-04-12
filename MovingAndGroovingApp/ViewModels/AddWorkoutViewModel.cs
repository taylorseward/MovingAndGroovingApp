using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GuitarStore.ViewModels;
using MovingAndGroovingApp.Models;
using MovingAndGroovingApp.Services;

namespace MovingAndGroovingApp.ViewModels;

public class AddWorkoutViewModel : BaseViewModel
{
    private readonly DatabaseService _databaseService;

    public ObservableCollection<string> WorkoutTypes { get; } = new ObservableCollection<string>
    {
        "Walking", 
        "Running", 
        "Weightlifting", 
        "Cycling", 
        "Dog Walk",
        "Elliptical",
        "Tennis"
    };

    private string _selectedWorkoutType;
    public string SelectedWorkoutType
    {
        get => _selectedWorkoutType;
        set => SetProperty(ref _selectedWorkoutType, value);
    }

    private DateTime _workoutDate = DateTime.Today;
    public DateTime WorkoutDate
    {
        get => _workoutDate;
        set => SetProperty(ref _workoutDate, value);
    }

    public AddWorkoutViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }
}
