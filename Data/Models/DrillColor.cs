using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DrillColor : BaseCard
    {
        public string Name { get; set; } = null!;      
        public string Code { get; set; } = "#FF0000";  
        public bool IsActive { get; set; } = true;
    }
}
