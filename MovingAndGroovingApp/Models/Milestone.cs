using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAndGroovingApp.Models
{
    public class Milestone
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ThresholdMinutes { get; set; }
        public string RewardName { get; set; }
        public string RewardDescription { get; set; }
    }
}
