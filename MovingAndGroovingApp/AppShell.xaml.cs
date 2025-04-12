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
            Routing.RegisterRoute(nameof(WorkoutLogPage), typeof(WorkoutLogPage));
            Routing.RegisterRoute(nameof(AddWorkoutPage), typeof(AddWorkoutPage));

            // Login & Register Routing
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));

            // Home Routing
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }
    }
}
