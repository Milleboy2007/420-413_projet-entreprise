using Domaine.Entity;
using Domaine.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Context
{
    public class DemandeConge
    {
        [Key]
        [Required]
        public int IDDemandeConge { get; set; }

        [ForeignKey("utilisateur")]
        public int IdEmployee { get; set; }
        public virtual Utilisateur utilisateur { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateDebut { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DateFin { get; set; }

        [Required]
        public string Motif { get; set; }

        public string Statut { get; set; }

        [Required]
        public string TypeConge { get; set; }

        [Required]
        public DateTime DateCreation { get; private set; }
        public RoleUtilisateur Approbateur { get; set; }


        public DemandeConge()
        {
            DateCreation = DateTime.Now;
            Statut = EtatStatut.EnAttente.ToString();
            Motif = string.Empty;
            TypeConge = string.Empty;
        }

        [NotMapped]
        public DateTime DateDebutDateTime
        {
            get => DateDebut.ToDateTime(TimeOnly.MinValue);
            set => DateDebut = DateOnly.FromDateTime(value);
        }

        [NotMapped]
        public DateTime DateFinDateTime
        {
            get => DateFin.ToDateTime(TimeOnly.MinValue);
            set => DateFin = DateOnly.FromDateTime(value);
        }
    }
}
