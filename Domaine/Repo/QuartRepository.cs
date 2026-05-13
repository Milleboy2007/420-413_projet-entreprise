using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Context;
using Domaine.Entity;
using Domaine.Interface;
using Microsoft.EntityFrameworkCore;

namespace Domaine.Repo
{
    public class QuartRepository: IQuartRepository
    {
        private readonly ScheduleFlowDBContexte _db;

        public QuartRepository(ScheduleFlowDBContexte context)
        {
            _db = context;
        }

        public async Task CreateQuartAsync(Quart quart)
        {
            await _db.Quarts.AddAsync(quart);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteQuartAsync(int idQuart)
        {
            Quart? quart = await _db.Quarts.FindAsync(idQuart);

            if (quart != null)
            {
                _db.Quarts.Remove(quart);
                await _db.SaveChangesAsync();
            }
        }

        /*
         * Ne vérifie pas encore que l'utilisateur est existent
         */
        public async Task AssignerUserAsync(int idQuart, int idUser)
        {
            Quart? quart = await _db.Quarts.FindAsync(idQuart);

            if (quart != null)
            {
                quart.UserId = idUser;
                quart.IsPub = false;
                await _db.SaveChangesAsync();
            }
        }

        public async Task PublierQuartAsync(int idQuart)
        {
            Quart? quart = await _db.Quarts.FindAsync(idQuart);

            if (quart != null)
            {
                quart.IsPub = true;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Quart[]> GetAllQuartAsync()
        {
            return await _db.Quarts.ToArrayAsync();
        }

        public async Task<Quart?> GetOneQuartAsync(int idQuart)
        {
            return await _db.Quarts.FindAsync(idQuart);
        }

        public async Task<Quart[]> GetAllUnassignateQuartsAsync()
        {
            return await _db.Quarts.Where(quart => quart.UserId == null).ToArrayAsync();
        }

        public async Task<Quart[]> GetAllPubQuartAsync(int idUser)
        {
            return await _db.Quarts.Where(quart => quart.IsPub && quart.UserId != idUser).ToArrayAsync();
        }

        public async Task<Quart[]> GetAllQuartByDateAsync(DateOnly date)
        {
            return await _db.Quarts.Where(quart => quart.Date == date).ToArrayAsync();
        }

        public async Task<Quart[]> GetAllQuartOfOnePersonForAWeekAsync(int id, DateOnly debut, DateOnly fin)
        {
            return await _db.Quarts.Where(quart => quart.UserId == id && quart.Date >= debut && quart.Date <= fin).ToArrayAsync();
        }
    }
}
