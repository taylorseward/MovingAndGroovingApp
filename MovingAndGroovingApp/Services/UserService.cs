using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MovingAndGroovingApp.Models;

namespace MovingAndGroovingApp.Services
{
    public class UserService
    {
        private static UserService _instance;
        public static UserService Instance => _instance ??= new UserService();

        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set => _currentUser = value; // might want to implement INotifyPropertyChanged for this property
        }
    }
}
