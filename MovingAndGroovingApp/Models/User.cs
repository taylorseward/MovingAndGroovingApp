using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MovingAndGroovingApp.Models
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserPhotoPath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int TeamId { get; set; }
        public int TotalMinutes { get; set; }
        public bool IsAdmin { get; set; }
    }
}
