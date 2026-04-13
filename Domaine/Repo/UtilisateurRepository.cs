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
        private UtilisateurDbContexte _dbContext;
        public UtilisateurRepository()
        {
            _dbContext = new UtilisateurDbContexte();
        }

        public void AjouterUtilisateur(Utilisateur nouvelUtilisateur)
        {
            _dbContext.Utilisateurs.Add(nouvelUtilisateur);
            _dbContext.SaveChanges();
        }


    }
}
