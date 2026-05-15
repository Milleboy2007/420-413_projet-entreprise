using Domaine.Context;
using Domaine.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Entity;

namespace Domaine.Interface
{
    public interface IDemandeCongeRepository
    {
        Task AjouterDemandeCongeAsync(DemandeConge demandeConge);

        Task<DemandeConge?> RechercherDemandeCongeAsync(int demandeCongeID);

        Task ModifierDemandeCongeAsync(DemandeConge demandeConge);

        Task SupprimerDemandeCongeAsync(int demandeCongeID);

    }
}
