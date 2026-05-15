using Domaine.Context;
using Domaine.Entity;
using Domaine.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Repo
{
    public class CreneauRepository : ICreneauRepository
    {
        private readonly ScheduleFlowDBContexte _db;

        public CreneauRepository(ScheduleFlowDBContexte dbContext)
        {
            _db = dbContext;
        }
        public bool CreneauExiste(int idCreneau)
        {
            return _db.CreneauDispos.Any(creneau => creneau.IdCreneau == idCreneau);
        }

        public async Task AjouterCreneau(CreneauDispo creneauDispo)
        {
            await _db.CreneauDispos.AddAsync(creneauDispo);
            await _db.SaveChangesAsync();
        }

        public async Task ModifierCreneau(CreneauDispo creneauDispo)
        {
            _db.CreneauDispos.Update(creneauDispo);
            await _db.SaveChangesAsync();
        }

        public async Task SupprimerCreneau(int idCreneau)
        {
            CreneauDispo creneauDispo = await _db.CreneauDispos.FindAsync(idCreneau);
            if (creneauDispo != null)
            {
                _db.CreneauDispos.Remove(creneauDispo);
                await _db.SaveChangesAsync();
            }
        }
        public async Task<List<CreneauDispo>> GetCreneauxByFeuilleId(int idFeuille)
        {
            return await _db.CreneauDispos
                .Where(c => c.IdFeuille == idFeuille)
                .ToListAsync();
        }
    }
}
