using Domaine.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Context
{
    public class CreneauDbContext : DbContext
    {
        internal DbSet<CreneauDispo> CreneauDispos { get; set; }

        public CreneauDbContext(DbContextOptions<CreneauDbContext> options)
        : base(options)
        {
        }
    }
}
