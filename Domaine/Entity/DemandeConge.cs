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

namespace Domaine.Context
{
    public class DemandeConge
    {
        [Key]
        [Required]
        public int DemandeCongeID { get; set; }

        [Required]
        public int IdUtilisateur { get; set; }
  
        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateDebut { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateFin { get; set; }

        [Required]
        public string Raison { get; set; }

        public string Statut { get; set; }

        [Required]
        public string TypeConge { get; set; }

        
        public DateTime DateCreation { get; set; }
        public RoleUtilisateur Approbateur { get; set; }


        public DemandeConge()
        {
            DateCreation = DateTime.Now;
            Statut = EtatStatut.EnAttente.ToString();
            Raison = string.Empty;
            TypeConge = string.Empty;
        }
    }
}
