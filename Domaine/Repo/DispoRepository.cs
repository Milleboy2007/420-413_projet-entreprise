using Domaine.Context;
using Domaine.Entity;
using Domaine.Interface;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Repo
{
    public class DispoRepository : IDispoRepository
    {
        private readonly ScheduleFlowDBContexte _db;

        public DispoRepository(ScheduleFlowDBContexte dbContext)
        {
            _db = dbContext;
        }
        
        public bool FeuilleDispoExiste(int idFeuille)
        {   
            return _db.FeuilleDispos.Any(dispo => dispo.IdFeuille == idFeuille);
        }

        public async Task AjouterDispo(FeuilleDispo feuilleDispo)
        {
            await _db.FeuilleDispos.AddAsync(feuilleDispo);
            await _db.SaveChangesAsync();
        }

        public async Task ModifierDispo(FeuilleDispo feuilleDispo)
        {
            _db.FeuilleDispos.Update(feuilleDispo);
            await _db.SaveChangesAsync();
        }

        public async Task SupprimerDispo(int idFeuille)
        {
            FeuilleDispo? feuilleDispo = await _db.FeuilleDispos.FindAsync(idFeuille);
            if (feuilleDispo != null)
            {
                _db.FeuilleDispos.Remove(feuilleDispo);
                await _db.SaveChangesAsync();
            }
        }

    }
}
