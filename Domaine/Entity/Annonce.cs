using System.ComponentModel.DataAnnotations;
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
            Titre = "Annonce";
            Contenu = "Remplacer le contenu...";
            Createur = RoleUtilisateur.Employeur;
        }
    }
}
