using Domaine.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Context
{
    public class DispoDbContext : DbContext
    {
        internal DbSet<FeuilleDispo> FeuilleDispos {  get; set; }

        public DispoDbContext(DbContextOptions<DispoDbContext> options)
        : base(options) 
        {
        }
    }
}
