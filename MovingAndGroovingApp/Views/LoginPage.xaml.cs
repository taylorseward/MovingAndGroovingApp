using MovingAndGroovingApp.ViewModels;
using MovingAndGroovingApp.Services;
using Microsoft.Maui.Controls;

namespace MovingAndGroovingApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(DatabaseService databaseService)
	{
		InitializeComponent();
		BindingContext = new LoginViewModel(databaseService);
    }
}