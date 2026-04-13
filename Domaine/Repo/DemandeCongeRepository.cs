using Domaine.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Interface;

namespace Domaine.Repo
{
    internal class DemandeCongeRepository: IDemandeCongeRepository
    {
        private DemandeCongeDbContext _db;

        public DemandeCongeRepository(DemandeCongeDbContext dbContext)
        {
            _db = dbContext;
        }


        public async Task AjouterDemandeCongeAsync(DemandeConge demandeConge)
        {
            await _db.DemandeConges.AddAsync(demandeConge);
            _db.SaveChangesAsync();
        }
    }
}
