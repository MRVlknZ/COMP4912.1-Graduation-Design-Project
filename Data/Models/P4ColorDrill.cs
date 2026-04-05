using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class P4ColorDrill : Drill
    {
        public int UserId { get; set; }
        public User? User { get; set; } = null!;
        public int TotalDurationSec { get; set; }

        public double SwitchIntervalSec { get; set; }

        public bool IsRandomOrder { get; set; }

        public string DifficultyLevel { get; set; } = "Easy";

        public string ActionsPerColor { get; set; } = string.Empty;
    }
}
