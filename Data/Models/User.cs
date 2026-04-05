using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User : BaseCard
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public ICollection<CColorDrill> CColorDrills { get; set; } = new List<CColorDrill>();
        public ICollection<CSoundDrill> CSoundDrills { get; set; } = new List<CSoundDrill>();
        public ICollection<CTextDrill> CTextDrills { get; set; } = new List<CTextDrill>();
        public ICollection<CFocusDrill> CFocusDrills { get; set; } = new List<CFocusDrill>();
        public ICollection<CCombDrill> CCombDrills { get; set; } = new List<CCombDrill>();
        public ICollection<P4ColorDrill> P4ColorDrills { get; set; } = new List<P4ColorDrill>();
        public ICollection<PSoundDrill> PSoundDrills { get; set; } = new List<PSoundDrill>();
        public ICollection<PTextDrill> PTextDrills { get; set; } = new List<PTextDrill>();
        public ICollection<PFocusDrill> PFocusDrills { get; set; } = new List<PFocusDrill>();
        public ICollection<PCombDrill> PCombDrills { get; set; } = new List<PCombDrill>();
    }
}
