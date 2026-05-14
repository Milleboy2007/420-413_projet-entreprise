using Domaine.Context;
using Domaine.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Interface
{
    public interface IDemandeCongeRepository
    {
        Task AjouterDemandeCongeAsync(DemandeConge demandeConge);

        Task<DemandeConge> RechercherParIdAsync(int demandeID);

        Task<List<DemandeConge>> GetDemandesParUtilisateurAsync(int userId);

        Task ModifierDemandeCongeAsync(DemandeConge demandeCongeID);

        Task SupprimerDemandeCongeAsync(DemandeConge demandeCongeID);

    }
}
