using Domaine.Entity;

namespace Domaine.Interface
{
    public interface IUtilisateurRepository
    {
        void AjouterUtilisateur(Utilisateur nouvelUtilisateur);
        void ModifierUtilisateur(Utilisateur utilisateur);
        void SupprimerUtilisateur(Utilisateur utilisateur);
        IEnumerable<Utilisateur> ObtenirUtilisateurs();
        Utilisateur VerifierConnexion(string courrielEntreprise, string motDePasse);
        IEnumerable<Utilisateur> ObtenirEmploye();
        Task<Utilisateur?> ObtenirParId(int id);
        Utilisateur ObtenirUtilisateurParId(int id);
    }
}
