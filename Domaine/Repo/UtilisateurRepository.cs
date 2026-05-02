using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Entity;
using Domaine.Interface;
using Domaine.Context;

namespace Domaine.Repo
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private ScheduleFlowDBContexte _dbContext;
        public UtilisateurRepository(ScheduleFlowDBContexte contexte)
        {
            _dbContext = contexte;
        }

        public void AjouterUtilisateur(Utilisateur nouvelUtilisateur)
        {
            _dbContext.Utilisateurs.Add(nouvelUtilisateur);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Utilisateur> ObtenirEmploye(){
            return _dbContext.Utilisateurs.Where(u => u.Role == RoleUtilisateur.Employe);
        }

    }
}
