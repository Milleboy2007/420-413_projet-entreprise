using System.ComponentModel.DataAnnotations;

namespace Domaine.Entity
{
    public class FeuilleDispo
    {
        [Key]
        public int IdFeuille { get; set; }
        public int IdEmploye { get; set; }
        public virtual ICollection<CreneauDispo> Creneau { get; set; } = new List<CreneauDispo>();
    }
}
