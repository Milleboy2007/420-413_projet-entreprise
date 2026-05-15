using System.Windows.Controls;
using Domaine.Context;
using ScheduleFlow.Pages.Global;

namespace ScheduleFlow.Pages.Gerant
{
    public partial class AccueilGerant : UserControl
    {
        public AccueilGerant()
        {
            InitializeComponent();
        }

        public void ChargerDonnees(ScheduleFlowDBContexte dbContext, GestionnaireSession session)
        {
            TxtNomUtilisateur.Text = $"Bienvenue, {session.Prenom} {session.Nom} !";
            TxtNombreUtilisateurs.Text = dbContext.Utilisateurs.Count().ToString();
            TxtNombreDemandesConge.Text = dbContext.DemandeConges.Count().ToString();
            TxtNombreAnnonces.Text = "0";
        }
    }
}
