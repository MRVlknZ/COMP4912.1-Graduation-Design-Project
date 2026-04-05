using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CFocusDrill : Drill
    {
        public int UserId { get; set; }
        public User? User { get; set; } = null!;
        public int TargetColorCount { get; set; }
        public string TargetColors { get; set; } = string.Empty;

        public string ActionsForTargetColors { get; set; } = string.Empty;

        public double SwitchIntervalSec { get; set; }

        public int TotalDurationSec { get; set; }

        public string DifficultyLevel { get; set; } = "Easy";

        public bool AutoIncreaseDifficulty { get; set; }
    }
}
