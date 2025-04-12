using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAndGroovingApp.Models
{
    public class CompetitionSettings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Year { get; set; }
        public string CompetitionDescription { get; set; }
    }
}
