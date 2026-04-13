using Domaine.Context;
using Domaine.Entity;
using Domaine.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Repo
{
    public class CreneauRepository : ICreneauRepository
    {
        private readonly CreneauDbContext _db;

        public CreneauRepository(CreneauDbContext dbContext)
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
    }
}
