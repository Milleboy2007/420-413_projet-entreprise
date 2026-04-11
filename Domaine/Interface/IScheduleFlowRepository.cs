using Domaine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Interface
{
    public interface IScheduleFlowRepository
    {
        List<Gerant> ObtenirTousGerants();
        Gerant ObtenirGerantParId(int id);
        void AjouterGerant(Gerant gerant);
        void ModifierGerant(Gerant gerant);
        void SupprimerGerant(int id);
    }
}
