using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovingAndGroovingApp.ViewModels;
using MovingAndGroovingApp.Models;
using MovingAndGroovingApp.Services;
using System.Windows.Input;

namespace MovingAndGroovingApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;
        private string _username;
        private string _firstName;
        private string _lastName;
        private string _password;

        public RegisterViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            RegisterCommand = new Command(OnRegister);
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand RegisterCommand { get; }

        private async void OnRegister()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Please fill in all required fields.", "OK");
                return;
            }

            var user = new User
            {
                UserName = Username,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName
            };

            try
            {
                await _databaseService.SaveUserAsync(user);
                UserService.Instance.CurrentUser = user;
                await Shell.Current.DisplayAlert("Success", "Registration successful!", "OK");
                await Shell.Current.Navigation.PopAsync(); // Navigate back to the previous page
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Registration failed: " + ex.Message, "OK");
            }
        }
    }
}
