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
        void ModifierUtilisateur(Utilisateur utilisateur);
        void SupprimerUtilisateur(Utilisateur utilisateur);
    }
}
