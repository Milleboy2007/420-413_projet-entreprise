using Domaine.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Enum;

namespace Domaine.Entity
{
    public class Annonce
    {
        [Key]
        [Required]
        public int AnnonceId { get; set; }

        [Required]
        public string Titre { get; set; }
        
        [Required]
        public string Contenu { get; set; }

        [Required]
        public RoleUtilisateur Createur { get; set; }

        [DataType(DataType.Date)]
        public DateOnly DatePublication { get; set; }

        public Annonce()
        {
            AnnonceId += 1;
            Titre = "Annonce";
            Contenu = "Remplacer le contenu...";
            Createur = RoleUtilisateur.Employeur;
        }
    }
}
