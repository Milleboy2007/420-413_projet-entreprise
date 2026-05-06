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
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Quart> Quarts { get; set; }
        internal DbSet<FeuilleDispo> FeuilleDispos { get; set; }
        internal DbSet<CreneauDispo> CreneauDispos { get; set; }
        public DbSet<DemandeConge> DemandeConges { get; set; }
        public DbSet<Annonce> Annonces { get; set; }

        public ScheduleFlowDBContexte(DbContextOptions<ScheduleFlowDBContexte> options) : base(options)
        {
        }
    }
}
