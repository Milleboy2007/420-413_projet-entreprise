using Domaine.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Interface;
using Domaine.Entity;

namespace Domaine.Repo
{
    public class DemandeCongeRepository: IDemandeCongeRepository
    {
        private readonly ScheduleFlowDBContexte _db;

        public DemandeCongeRepository(ScheduleFlowDBContexte dbContext)
        {
            _db = dbContext;
        }


        public async Task AjouterDemandeCongeAsync(DemandeConge demandeConge)
        {
            _db.DemandeConges.Add(demandeConge);
            await _db.SaveChangesAsync();
        }

        public async Task ModifierDemandeCongeAsync(DemandeConge demandeConge)
        {
            _db.DemandeConges.Update(demandeConge);
            await _db.SaveChangesAsync();
        }

        public async Task<DemandeConge?> RechercherDemandeCongeAsync(int demandeCongeID)
        {
            return await _db.DemandeConges.FindAsync(demandeCongeID);
        }

        public async Task SupprimerDemandeCongeAsync(int demandeCongeID)
        {
            var demande = await _db.DemandeConges.FindAsync(demandeCongeID);

            if (demande != null)
            {
                _db.DemandeConges.Remove(demande);
                await _db.SaveChangesAsync();
            }
        }
    }
}
