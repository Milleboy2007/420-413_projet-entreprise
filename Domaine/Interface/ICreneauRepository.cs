using Domaine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Interface
{
    public interface ICreneauRepository
    {
        bool CreneauExiste(int idCreneau);
        Task AjouterCreneau(CreneauDispo creneauDispo);
        Task ModifierCreneau(CreneauDispo creneauDispo);
        Task SupprimerCreneau(int idCreneau);
    }
}
