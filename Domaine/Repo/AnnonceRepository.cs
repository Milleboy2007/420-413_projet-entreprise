using Domaine.Context;
using Domaine.Interface;
using Domaine.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domaine.Repo
{
    public class AnnonceRepository : IAnnonceRepository
    {
        private readonly ScheduleFlowDBContexte _context;

        public AnnonceRepository(ScheduleFlowDBContexte context)
        {
            _context = context;
        }
        public async Task PublierAnnonce(Annonce annonce)
        {
            _context.Add(annonce);
            await _context.SaveChangesAsync();
        }


        public async Task ModifierAnnonce(Annonce annonce)
        {
            _context.Annonces.Update(annonce);
            await _context.SaveChangesAsync();
        }

        public async Task<Annonce?> RechercherAnnonce(int annonceId)
        {
            return await _context.Annonces.FindAsync(annonceId);
        }

        public async Task SupprimerAnnonce(int annonceID)
        {
            var annonce = await _context.Annonces.FindAsync(annonceID);

            if(annonce != null)
            {
                _context.Annonces.Remove(annonce);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Annonce[]> GetAllAnonceAsync()
        {
            return await _context.Annonces.ToArrayAsync();
        }
    }
}
