using MovingAndGroovingApp.ViewModels;
using MovingAndGroovingApp.Models;
using MovingAndGroovingApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAndGroovingApp.ViewModels
{
    public class WorkoutLogViewModel : BaseViewModel
    {
        public ObservableCollection<WorkoutLog> Workouts { get; } = new();

        public WorkoutLogViewModel(DatabaseService databaseService)
        {
            LoadWorkouts(databaseService);
        }

        private async void LoadWorkouts(DatabaseService databaseService)
        {
            var workoutsFromDb = await databaseService.GetWorkoutAsync();
            foreach (var workout in workoutsFromDb)
            {
                Workouts.Add(workout);
            }
        }
    }

}
