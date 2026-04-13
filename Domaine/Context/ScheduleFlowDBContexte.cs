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

        public ScheduleFlowDBContexte(DbContextOptions<ScheduleFlowDBContexte> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=ScheduleFlowDB.db");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string folderPath = Path.Combine(AppContext.BaseDirectory, "Data");

        //    if (!Directory.Exists(folderPath))
        //    {
        //        Directory.CreateDirectory(folderPath);
        //    }

        //    string dbPath = Path.Combine(folderPath, "ScheduleFlow.db");
        //    optionsBuilder.UseSqlite($"Data Source={dbPath}");
        //}

        //public override int SaveChanges()
        //{
        //    // Crée la BD si elle n'existe pas
        //    Database.EnsureCreated();
        //    return base.SaveChanges();
        //}
    }
}
