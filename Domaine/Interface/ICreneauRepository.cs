using Domaine.Entity;

namespace Domaine.Interface
{
    public interface ICreneauRepository
    {
        bool CreneauExiste(int idCreneau);
        Task AjouterCreneau(CreneauDispo creneauDispo);
        Task ModifierCreneau(CreneauDispo creneauDispo);
        Task SupprimerCreneau(int idCreneau);
        Task<List<CreneauDispo>> GetCreneauxByFeuilleId(int idFeuille);
    }
}
