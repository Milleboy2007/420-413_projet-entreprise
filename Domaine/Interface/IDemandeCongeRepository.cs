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

        Task<DemandeConge> RechercherDemandeCongeAsync(DemandeConge demandeCongeID);

        Task ModifierDemandeCongeAsync(DemandeConge demandeCongeID);

        Task SupprimerDemandeCongeAsync(DemandeConge demandeCongeID);

    }
}
