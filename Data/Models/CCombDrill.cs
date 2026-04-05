using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CCombDrill : Drill
    {
        public int UserId { get; set; }
        public User? User { get; set; } = null!;
        public int CommandCount { get; set; }

        public string CommandList { get; set; } = string.Empty;

        public int CommandsPerCombination { get; set; }

        public double CombinationDisplaySec { get; set; }

        public double TransitionSec { get; set; }

        public bool IsRandomOrder { get; set; }

        public bool AllowRepetition { get; set; }

        public int TotalDurationSec { get; set; }

        public string DifficultyLevel { get; set; } = "Easy";
    }
}
