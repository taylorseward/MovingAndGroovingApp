﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MovingAndGroovingApp.ViewModels;
using Microsoft.Maui.Controls;
using MovingAndGroovingApp.Services;
using MovingAndGroovingApp.Views;

namespace MovingAndGroovingApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;
        private string _username;
        private string _password;

        public LoginViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            LoginCommand = new Command(OnLogin);
            NavigateToRegisterCommand = new Command(NavigateToRegister);
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }

        private async void OnLogin()
        {
            // checks for empty fields when logging in
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Please enter both username and password.", "OK");
                return;
            }
            var user = await _databaseService.GetUserAsync(Username, Password);
            if (user != null)
            {
                UserService.Instance.CurrentUser = user;
                string fullName = $"{user.FirstName} {user.LastName}";
                await Shell.Current.DisplayAlert("Success", $"Login successful {fullName}!", "OK");
                // Navigate to the main page or dashboard
                await Shell.Current.GoToAsync("//HomePage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Invalid username or password.", "OK");
            }
        }

        private async void NavigateToRegister()
        {
            await Shell.Current.Navigation.PushAsync(new RegisterPage(_databaseService));
        }
    }
}
