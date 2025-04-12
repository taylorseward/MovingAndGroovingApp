using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovingAndGroovingApp.ViewModels;
using MovingAndGroovingApp.Services;

namespace MovingAndGroovingApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            var currentUser = UserService.Instance.CurrentUser;
            FirstName = currentUser?.FirstName;
            LastName = currentUser?.LastName;
        }

        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (SetProperty(ref _firstName, value))
                {
                    OnPropertyChanged(nameof(WelcomeMessage));
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (SetProperty(ref _lastName, value))
                {
                    OnPropertyChanged(nameof(WelcomeMessage));
                }
            }
        }

        public string WelcomeMessage => $"Welcome {FirstName} {LastName}";
    }
}
