using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CColorDrill : Drill
    {
        public int UserId { get; set; }
        public User? User { get; set; } = null!;

        public int TotalDurationSec { get; set; }
        public int ColorCount { get; set; }
        public string? SelectedColorIds { get; set; }
        public double SwitchIntervalSec { get; set; }
        public bool IsRandomOrder { get; set; }

        public string ActionsPerColor { get; set; } = string.Empty;
        public string DifficultyLevel { get; set; } = "Easy";
    }

}
