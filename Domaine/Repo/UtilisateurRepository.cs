using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Entity;
using Domaine.Interface;
using Domaine.Context;
using Microsoft.EntityFrameworkCore;
using Domaine.Enum;

namespace Domaine.Repo
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private ScheduleFlowDBContexte _dbContext;
        public UtilisateurRepository(ScheduleFlowDBContexte contexte)
        {
            _dbContext = contexte;
        }


        public Utilisateur ObtenirUtilisateurParId(int id)
        {
            return _dbContext.Utilisateurs.FirstOrDefault(x => x.IdUtilisateur == id);
        }

        public void AjouterUtilisateur(Utilisateur nouvelUtilisateur)
        {
            _dbContext.Utilisateurs.Add(nouvelUtilisateur);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Utilisateur> ObtenirUtilisateurs()
        {
            return _dbContext.Utilisateurs.ToList();
        }

        public Utilisateur VerifierConnexion(string courrielEntreprise, string motDePasse)
        {
            {
                return _dbContext.Utilisateurs.FirstOrDefault(u => u.CourrielEntreprise == courrielEntreprise && u.MotDePasse == motDePasse);
            }
        }



        public IEnumerable<Utilisateur> ObtenirEmploye(){
            return _dbContext.Utilisateurs.Where(u => u.Role == RoleUtilisateur.Employe);
        }

        public async Task<Utilisateur?> ObtenirParId(int id) {
            return await _dbContext.Utilisateurs.FirstOrDefaultAsync(u => u.IdUtilisateur == id);
        }
    }
}
