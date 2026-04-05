using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CTextDrill : Drill
    {
        public int UserId { get; set; }
        public User? User { get; set; } = null!;
        public string ExNames { get; set; } = string.Empty;

        public string ExDurationsSec { get; set; } = string.Empty;

        public bool IsSequential { get; set; }

        public bool HasBreakBtwExs { get; set; }

        public int BreakBtwExsSec { get; set; }

        public int RepeatCount { get; set; }

        public bool HasBreakBtwRepeats { get; set; }

        public int BreakBtwRepeatsSec { get; set; }

        public string DemonstrationType { get; set; } = "Text";

        public int TotalDurationSec { get; set; }
    }
}
