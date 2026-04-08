using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domaine.Entity
{
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MotDePasse { get; set; }

        public DateTime DateCreation { get; set; }

        public Utilisateur()
        {
            DateCreation = DateTime.Now;
        }

    }
}
