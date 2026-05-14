using Domaine.Context;
using Domaine.Entity;
using Domaine.Repo;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
