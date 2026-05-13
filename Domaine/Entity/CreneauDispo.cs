using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entity
{
    public class CreneauDispo
    {
        [Key]
        public int IdCreneau { get; set; }
        [ForeignKey("Feuille")]
        public int IdFeuille { get; set; }
        public virtual FeuilleDispo Feuille { get; set; }
        [Required]
        public string Jour { get; set; }
        [Required]
        public TimeSpan HeureDebut { get; set; }
        [Required]
        public TimeSpan HeureFin {  get; set; }
    }
}
