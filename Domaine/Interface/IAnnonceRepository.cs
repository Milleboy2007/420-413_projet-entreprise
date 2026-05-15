using Domaine.Entity;

namespace Domaine.Interface
{
    public interface IAnnonceRepository 
    {

        Task PublierAnnonce(Annonce annonce);

        Task<Annonce?> RechercherAnnonce(int annonceId);

        Task ModifierAnnonce(Annonce annonce);

        Task SupprimerAnnonce(int annonceID);

        Task<Annonce[]> GetAllAnonceAsync();
    }
}
