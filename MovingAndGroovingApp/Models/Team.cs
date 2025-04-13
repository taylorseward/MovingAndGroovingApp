using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAndGroovingApp.Models
{
    public class Team
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TeamPhotoPath { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public int TeamTotalMinutes { get; set; }
    }
}
