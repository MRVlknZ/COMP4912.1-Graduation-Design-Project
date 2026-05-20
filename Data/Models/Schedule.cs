using Core.Entities;

namespace Data.Models
{
    public class Schedule : BaseCard
    {
        public int UserId { get; set; }

        public string DrillType { get; set; } = string.Empty;

        public int DrillId { get; set; }

        public string DrillName { get; set; } = string.Empty;

        public string Day { get; set; } = string.Empty;

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public User? User { get; set; }
    }
}