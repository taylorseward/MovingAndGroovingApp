using MovingAndGroovingApp.ViewModels;
using MovingAndGroovingApp.Views;
using MovingAndGroovingApp.Models;
using MovingAndGroovingApp.Services;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using System;

namespace MovingAndGroovingApp
{
    public partial class AppShell : Shell
    {
        private readonly DatabaseService _databaseService;
        public AppShell()
        {
            InitializeComponent();

            _databaseService = new DatabaseService();

            // Workout Routing
            Routing.RegisterRoute(nameof(WorkoutLog), typeof(WorkoutLog));
            Routing.RegisterRoute(nameof(AddWorkoutPage), typeof(AddWorkoutPage));
        }
    }
}
