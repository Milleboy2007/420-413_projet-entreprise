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
    public class QuartRepository: IRepository
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
         * Ne vérifie pas encore que l'utilisateur est existe
         */
        public async Task AssignerUserAsync(int idQuart, int idUser)
        {
            Quart? quart = await _db.Quarts.FindAsync(idQuart);

            if (quart != null)
            {
                quart.UserId = idUser;
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

        public async Task<Quart[]> GetAllPubQuartAsync()
        {
            return await _db.Quarts.Where(quart => quart.IsPub).ToArrayAsync();
        }
    }
}
