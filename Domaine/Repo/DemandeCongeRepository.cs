using Domaine.Context;
using Domaine.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task ModifierDemandeCongeAsync(DemandeConge demandeCongeID)
        {
            _db.DemandeConges.Update(demandeCongeID);
            await _db.SaveChangesAsync();
        }

        public async Task<DemandeConge> RechercherDemandeCongeAsync(DemandeConge demandeCongeID)
        {
            return await _db.DemandeConges.FindAsync(demandeCongeID);
        }

        public async Task SupprimerDemandeCongeAsync(DemandeConge demandeCongeID)
        {
            var demande = await _db.DemandeConges.FindAsync(demandeCongeID);

            if (demande != null)
            {
                _db.DemandeConges.Remove(demande);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<DemandeConge>> ObtenirToutesLesDemandesAsync()
        {
            return await _db.DemandeConges
                           .Include(d => d.utilisateur) 
                           .ToListAsync();
        }
    }
}
