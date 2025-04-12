using MovingAndGroovingApp.ViewModels;
using MovingAndGroovingApp.Services;
using Microsoft.Maui.Controls;

namespace MovingAndGroovingApp.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(DatabaseService databaseService)
	{
		InitializeComponent();
        BindingContext = new RegisterViewModel(databaseService);
    }
}