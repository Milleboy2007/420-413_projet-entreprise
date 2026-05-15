
namespace Domaine.dto
{
    public enum StatusQuart
    {
        NonAssigner,
        Assigner,
        AttenteEchange
    }
    public class AffichageQuartGerant_DTO
    {
        public DateOnly? Date { get; set; }
        public TimeOnly[] Heures { get; set; }
        public string Poste { get; set; }
        public StatusQuart Status { get; set; }
        public string Description { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
