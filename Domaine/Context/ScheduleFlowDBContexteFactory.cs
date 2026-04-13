using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Domaine.Context
{
    // EF Core détectera automatiquement cette interface lors du Add-Migration
    public class ScheduleFlowDBContexteFactory : IDesignTimeDbContextFactory<ScheduleFlowDBContexte>
    {
        public ScheduleFlowDBContexte CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ScheduleFlowDBContexte>();

            // Indiquez ici le vrai moteur de base de données que vous comptez utiliser (ex: SQLite)
            // La chaîne de connexion ici n'a pas besoin d'être complexe, elle sert juste pour la génération.
            optionsBuilder.UseSqlite(@"Data Source=ScheduleFlowDB.db");

            return new ScheduleFlowDBContexte(optionsBuilder.Options);
        }
    }
}