using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Access.Abstract;
using Access.Contexts;
using Core.DataAccess;
using Data.Models;

namespace Access.Concrete
{
    public class DrillColorDao : EntityRepository<DrillColor, TrainingDbContext>, IDrillColorDao { }
}
