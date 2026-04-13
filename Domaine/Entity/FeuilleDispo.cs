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
        [Key]
        public int IdEmploye { get; set; }
        public CreneauDispo creneauDispo { get; set; }
    }
}
