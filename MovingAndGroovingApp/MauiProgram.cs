﻿using Microsoft.Extensions.Logging;
using MovingAndGroovingApp.Models;
using MovingAndGroovingApp.Services;
using MovingAndGroovingApp.ViewModels;
using MovingAndGroovingApp.Views;

namespace MovingAndGroovingApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Database
            builder.Services.AddSingleton<DatabaseService>();

            // Workouts
            builder.Services.AddSingleton<WorkoutLog>();
            builder.Services.AddSingleton<AddWorkoutPage>();
            builder.Services.AddSingleton<WorkoutLogViewModel>();
            builder.Services.AddTransient<AddWorkoutViewModel>();

            // Login & Register
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<RegisterViewModel>();

            // Home
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomeViewModel>();

            // Team
            builder.Services.AddSingleton<TeamPage>();
            builder.Services.AddSingleton<CreateTeamPage>();
            builder.Services.AddSingleton<JoinTeamPage>();
            builder.Services.AddSingleton<TeamViewModel>();
            builder.Services.AddSingleton<CreateTeamViewModel>();
            builder.Services.AddSingleton<JoinTeamViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
