using Domaine.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Context
{
    enum Role
    {
        Employeur,
        Gerant
    }
    enum EtatStatut { 
        EnAttente,
        Approuve,
        Refuse
    }
    public class DemandeConge
    {
        [Key]
        [Required]
        public int IdConge { get; set; }

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
        public Role Approbateur { get; set; }


        public DemandeConge()
        {
            DateCreation = DateTime.Now;
            Statut = EtatStatut.EnAttente.ToString();
            Raison = string.Empty;
            TypeConge = string.Empty;
        }
    }
}
