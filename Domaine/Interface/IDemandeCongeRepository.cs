using Domaine.Entity;

namespace Domaine.Interface
{
    public interface IDemandeCongeRepository
    {
        Task AjouterDemandeCongeAsync(DemandeConge demandeConge);

        Task<DemandeConge?> RechercherParIdAsync(int demandeID);

        Task<List<DemandeConge>> GetDemandesParUtilisateurAsync(int userId);

        Task ModifierDemandeCongeAsync(DemandeConge demandeConge);
        Task<List<DemandeConge>> ObtenirToutesLesDemandesAsync();
        Task SupprimerDemandeCongeAsync(int demandeCongeID);

    }
}
