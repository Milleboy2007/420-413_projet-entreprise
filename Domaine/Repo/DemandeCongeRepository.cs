using Domaine.Context;
using Domaine.Interface;
using Microsoft.EntityFrameworkCore;
using Domaine.Interface;
using Domaine.Entity;
using Microsoft.EntityFrameworkCore;

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

        //public async Task<DemandeConge?> RechercherDemandeCongeAsync(int demandeCongeID)
        public async Task<DemandeConge?> RechercherParIdAsync(int demandeID)
        {
            return await _db.DemandeConges.FindAsync(demandeID);
        }

        public async Task<List<DemandeConge>> GetDemandesParUtilisateurAsync(int userId)
        {
            if(userId != 0)
            {
                return await _db.DemandeConges
                        .Where(u => u.IdEmployee == userId)
                        .ToListAsync();
            }
            else
            {
                return null;
            }
            
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

        public async Task<List<DemandeConge>> ObtenirToutesLesDemandesAsync()
        {
            return await _db.DemandeConges
                           .Include(d => d.utilisateur) 
                           .ToListAsync();
        }
    }
}
