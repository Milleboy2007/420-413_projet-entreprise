using Domaine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        Task<Quart[]> GetAllPubQuartAsync();

        Task<Quart[]> GetAllQuartByDate(DateOnly date);
    }
}
