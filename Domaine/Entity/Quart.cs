using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domaine.Entity
{
    public class Quart
    {
        [Key]
        public int Id { get; private set; }

        public required DateOnly Date { get; set; }

        public required TimeOnly[] Heure { get; set; }

        public required string Post { get; set; }
        public int? UserId { get; set; } = null;

        public required string Description { get; set; }
        public bool IsPub { get; set; } = false;

        public Quart() { 

        }
    }
}
