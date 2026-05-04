using Domaine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Interface
{
    public interface IUtilisateurRepository
    {
        void AjouterUtilisateur(Utilisateur nouvelUtilisateur);
        IEnumerable<Utilisateur> ObtenirEmploye();
        Task<Utilisateur?> ObtenirParId(int id);
        Utilisateur ObtenirUtilisateurParId(int id);
    }
}
