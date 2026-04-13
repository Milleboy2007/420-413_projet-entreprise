using Domaine.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Domaine.Context
{
    public class UtilisateurDbContexte : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string folderPath = Path.Combine(AppContext.BaseDirectory, "Data");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string dbPath = Path.Combine(folderPath, "ScheduleFlow.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        public override int SaveChanges()
        {
            // Crée la BD si elle n'existe pas
            Database.EnsureCreated();
            return base.SaveChanges();
        }
    }
}
