using Domaine.Entity;

namespace Domaine.Interface
{
    public interface IDispoRepository
    {
        bool FeuilleDispoExiste(int idFeuille);
        Task AjouterDispo(FeuilleDispo feuilleDispo);
        Task ModifierDispo(FeuilleDispo feuilleDispo);
        Task SupprimerDispo(int idFeuille);
    }
}
