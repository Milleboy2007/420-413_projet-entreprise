using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entity
{
    public class FeuilleDispo
    {
        [Key]
        public int IdFeuille { get; set; }
        public int IdEmploye { get; set; }
        public virtual ICollection<CreneauDispo> Creneaux { get; set; } = new List<CreneauDispo>();
    }
}
