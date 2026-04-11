using System;
using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;

namespace Domaine.Entity
{
    public class Gerant
    {

        public int Id { get; set; }

        [Required]
        public string Nom {  get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        public string Naissance { get; set; }
        [Required]
        public string Poste { get; set; }
        DateTime DateEmb { get; set; }
        [Required]
        public string Depart { get; set; }
        [Required]
        public string TypeContrat { get; set; }
        [Required]
        public string AdrPost { get; set; }
        [Required]
        public string Pays { get; set; }
        [Required]
        public string Prov { get; set; }
        [Required]
        public string Ville { get; set; }
        [Required]
        public string CodePost { get; set; }
        [Required]
        public string NomContUrg { get; set; }
        [Required]
        public string NumContUrg { get; set; }
        [Required]
        public string LienContUrg { get; set; }
        [Required]
        public string FormSupp { get; set; }

        public Gerant()
        {
            DateEmb = DateTime.Now;
        }
    }
}
    