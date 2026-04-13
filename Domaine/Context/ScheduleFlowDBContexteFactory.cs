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

            optionsBuilder.UseSqlite(@"Data Source=ScheduleFlowDB.db");

            return new ScheduleFlowDBContexte(optionsBuilder.Options);
        }
    }
}