using Domaine.Entity;
using System;
using Domaine.Enum;

namespace ScheduleFlow.Pages.Global
{
    public class GestionnaireSession
    {
        public int IdUtilisateur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CourrielEntreprise { get; set; }
        public RoleUtilisateur Role { get; set; }
        public DateTime DateConnexion { get; set; }
        public int IdFeuille { get; set; }

        public bool EstConnecte => !string.IsNullOrEmpty(CourrielEntreprise);

        public void Reinitialiser()
        {
            IdUtilisateur = 0;
            Nom = null;
            Prenom = null;
            CourrielEntreprise = null;
            Role = default;
            IdFeuille = -1;
            DateConnexion = DateTime.MinValue;
        }
    }
}