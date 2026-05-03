using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domaine.Entity
{
    public enum RoleUtilisateur
    {
        Employeur,
        Gerant,
        Employe

    }
    public class Utilisateur
    {
        [Key]
        public int IdUtilisateur { get; set; }
        public RoleUtilisateur Role { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        [Required]
        public string Courriel { get; set; } = string.Empty;

        public string CourrielEntreprise { get; set; }

        public string Genre { get; set; }

        public string NumeroTelephoneProfessionnel { get; set; }

        [Required]
        public string MotDePasse { get; set; }

        public string NumeroTelephonePersonnel { get; set; }

        public string DateNaissance { get; set; }

        public string Adresse { get; set; }

        public string Ville { get; set; }
        public string RegionProvince { get; set; }

        public string CodePostal { get; set; }

        public string Pays { get; set; }

        public string NomContactUrgence { get; set; }

        public string TelephoneContactUrgence { get; set; }

        public string LienParente { get; set; }

        public DateTime DateCreation { get; set; }




        public Utilisateur()
        {
            DateCreation = DateTime.Now;
        }

    }
}
