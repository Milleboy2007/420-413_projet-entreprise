using Domaine.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Context
{
    internal class DemandeCongeDbContext : DbContext
    {
        public DemandeCongeDbContext(DbContextOptions<DemandeCongeDbContext> options) 
            : base(options)
        {
        }
        public DbSet<DemandeConge> DemandeConges { get; set; }

    }
}
