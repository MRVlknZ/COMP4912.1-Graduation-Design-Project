using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class PSoundDrill : Drill
    {
        public int UserId { get; set; }
        public User? User { get; set; } = null!;
        public int VoiceCommandCount { get; set; }

        public string VoiceCommandList { get; set; } = string.Empty;

        public double CommandIntervalSec { get; set; }

        public int TotalDurationSec { get; set; }

        public bool IsRandomOrder { get; set; }

        public string DifficultyLevel { get; set; } = "Easy";

    }
}
