using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MovingAndGroovingApp.Models
{
    public class WorkoutLog
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string WorkoutType { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public DateTime Date { get; set; }

        // Format Time as xh ym
        public string FormattedTime
        {
            get
            {
                if (Hours > 0 && Minutes > 0)
                    return $"{Hours}h {Minutes}m";
                if (Hours > 0)
                    return $"{Hours}h";
                return $"{Minutes}m";
            }
        }

    }
}
