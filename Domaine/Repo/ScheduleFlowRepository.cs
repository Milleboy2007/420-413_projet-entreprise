using Domaine.Context;
using Domaine.Entity;
using Domaine.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Repo
{
    class ScheduleFlowRepository : IScheduleFlowRepository
    {
        private readonly ScheduleFlowDbContext _context;

        public ScheduleFlowRepository(ScheduleFlowDbContext context)
        {
            _context = context;
        }

        public List<Gerant> ObtenirTousGerants()
        {
            return _context.gerants.ToList();
        }

        public Gerant ObtenirGerantParId(int id) 
        {
            return _context.gerants.Find(id);
        }
        public void AjouterGerant(Gerant gerant)
        {
            _context.gerants.Add(gerant);
            _context.SaveChanges();
        }

        public void ModifierGerant(Gerant gerant) 
        {
            _context.gerants.Update(gerant);
            _context.SaveChanges();
        }

        public void SupprimerGerant(int id)
        {
            var gerant = _context.gerants.Find(id);
            if(gerant != null)
            {
                _context.gerants.Remove(gerant);
                _context.SaveChanges();
            }
        }


    }
}
