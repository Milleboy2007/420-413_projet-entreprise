using Domaine.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Context
{
    public class ScheduleFlowDBContexte: DbContext
    {
        public DbSet<Quart> Quarts { get; set; }
        
        public ScheduleFlowDBContexte(DbContextOptions<ScheduleFlowDBContexte> options) : base(options)
        {

        }
    }
}
