
using System.Windows.Controls;

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
