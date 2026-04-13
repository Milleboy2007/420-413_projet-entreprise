using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entity
{
    public class CreneauDispo
    {
        [Key]
        public int IdCreneau { get; set; }
        public int IdFeuille { get; set; }
        [Required]
        public string HeureDebut { get; set; }
        [Required]
        public string HeureFin {  get; set; }
    }
}
