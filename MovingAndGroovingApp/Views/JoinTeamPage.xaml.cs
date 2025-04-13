using MovingAndGroovingApp.ViewModels;
using Microsoft.Maui.Controls;

namespace MovingAndGroovingApp.Views
{
    public partial class JoinTeamPage : ContentPage
    {
        private readonly JoinTeamViewModel _viewModel;

        public JoinTeamPage()
        {
            InitializeComponent();
            _viewModel = new JoinTeamViewModel();
            BindingContext = _viewModel;
        }
    }
}
