using Domaine.Entity;

namespace Domaine.Interface
{
    public interface IQuartRepository
    {
        Task CreateQuartAsync(Quart quart);

        Task DeleteQuartAsync(int idQuart);

        Task AssignerUserAsync(int idQuart, int idUser);

        Task PublierQuartAsync(int idQuart);

        Task<Quart[]> GetAllQuartAsync();

        Task<Quart?> GetOneQuartAsync(int idQuart);

        Task<Quart[]> GetAllUnassignateQuartsAsync();

        Task<Quart[]> GetAllPubQuartAsync(int idUser);

        Task<Quart[]> GetAllQuartByDateAsync(DateOnly date);

        Task<Quart[]> GetAllQuartOfOnePersonForAWeekAsync(int id, DateOnly debut, DateOnly fin);
    }
}
