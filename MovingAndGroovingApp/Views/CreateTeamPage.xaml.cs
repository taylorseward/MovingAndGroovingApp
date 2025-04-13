using MovingAndGroovingApp.ViewModels;
using Microsoft.Maui.Controls;

namespace MovingAndGroovingApp.Views
{
    public partial class CreateTeamPage : ContentPage
    {
        private readonly CreateTeamViewModel _viewModel;

        public CreateTeamPage()
        {
            InitializeComponent();
            _viewModel = new CreateTeamViewModel();
            BindingContext = _viewModel;
        }
    }
}
