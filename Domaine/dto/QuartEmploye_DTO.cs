using Domaine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.dto
{
    public class QuartEmploye_DTO
    {
        public Quart Quart { get; set; }
        public StatusQuart Status { get; set; }
        public string TexteBtn => Quart.IsPub ? "Reprendre" : "Publier";
        public int ColonneGrid { get; set; }
        public int LigneGrid { get; set; }
        public int HauteurGrid { get; set; }
    }
}
