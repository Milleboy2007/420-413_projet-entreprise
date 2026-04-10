using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScheduleFlow.Pages.Employeur
{
    /// <summary>
    /// Logique d'interaction pour CreationCompteParEmployeur.xaml
    /// </summary>
    public partial class CreationCompteParEmployeur : UserControl
    {
        public CreationCompteParEmployeur()
        {
            InitializeComponent();
            string Prenom = prenom.Text;
            string Nom = nom.Text;
            string Email = email.Text;
            string Pass = pass.Text;
            string Tel = tel.Text;
            string Naissance = naissance.Text;
            string Poste = poste.Text;
            string DateEmb = dateEmb.Text;
            string Depart = depart.Text;
            string TypeContrat = typeContrat.Text;
            string AdrPost = adrPost.Text;
            string Pays = pays.Text;
            string Prov = prov.Text;
            string Ville = ville.Text;
            string CodePost = codePost.Text;
            string NomContUrg = nomContUrg.Text;
            string NumContUrg = numContUrg.Text;
            string LienContUrg = lienContUrg.Text;
            string FormSupp = formSupp.Text;
        }
    }
}
