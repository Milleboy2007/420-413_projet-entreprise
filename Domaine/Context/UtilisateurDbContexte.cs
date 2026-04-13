using Domaine.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Context
{
    public class UtilisateurDbContexte : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string folderPath = @"C:\Users\rym40\OneDrive\Bureau\420-413_projet-entreprise\ScheduleFlow\Data";


            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string dbPath = Path.Combine(folderPath, "ScheduleFlow.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
