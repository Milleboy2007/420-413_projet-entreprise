using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int ColumnIndex => Jour switch
        {
            "Lundi" => 0,
            "Mardi" => 1,
            "Mercredi" => 2,
            "Jeudi" => 3,
            "Vendredi" => 4,
            "Samedi" => 5,
            "Dimanche" => 6,
            _ => 0
        };

        public double TopOffset => (HeureDebut.TotalHours - 8) * 45;
        public double BlockHeight => (HeureFin - HeureDebut).TotalHours * 45;
    }
}
