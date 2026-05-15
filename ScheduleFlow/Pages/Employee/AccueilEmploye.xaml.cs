using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.ViewModels.Employe;
using ScheduleFlow.Pages.Global;
using System.Windows;
using System.Windows.Controls;

namespace ScheduleFlow.Pages.Employee
{
    public partial class AccueilEmploye : UserControl
    {

        private readonly GestionnaireSession _session;
        public AccueilEmploye()
        {
            InitializeComponent();
            this.DataContext = App.ServiceProvider.GetRequiredService<AccueilViewModel>();

            _session = App.ServiceProvider.GetService<GestionnaireSession>();

            this.Loaded += AccueilEmploye_Loaded;
        }

        private async void AccueilEmploye_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is AccueilViewModel vm)
            {
                await vm.ChargerDemandesAsync();
            }

            ChargerDonnees();
        }

        private void ChargerDonnees()
        {
            if (_session == null)
            {
                txtBonjour.Text = "Bonjour Billy Umma";
                txtPoste.Text = "Poste occupé: Commis d'entrepôt";
                txtDepuis.Text = "Depuis: Janvier 2026";
                txtHeures.Text = "Nombre d'heures travaillées: 79h";
                txtArgentRecu.Text = "Argent reçu: 1296 $";
                txtArgentDu.Text = "Argent dû: 126 $";
                txtProchainQuart.Text = "Mar 24 mars, 9h-17h Entrepôt";

                return;
            }


            txtBonjour.Text = $"Bonjour {_session.Prenom} {_session.Nom}";
            txtPoste.Text = $"Poste occupé: {_session.Role}";
            txtDepuis.Text = $"Depuis: Exemple";
            txtHeures.Text = $"Nombre d'heures travaillées: {HeuresTravaillees()}h";
            txtArgentRecu.Text = $"Argent reçu: {ArgentRecu()}$";
            txtArgentDu.Text = $"Argent dû: {ArgentDu()}$";

            txtProchainQuart.Text = "Exemple de texte";
                //$"{employe.ProchainQuart.Date:ddd d MMM}, " +
                //$"{employe.ProchainQuart.HeureDebut}-{employe.ProchainQuart.HeureFin} " +
                //$"{employe.ProchainQuart.Departement}";

        }

        public int HeuresTravaillees()
        {
            return 0;
        }

        public int ArgentRecu()
        {
            return 0;
        }

        public int ArgentDu()
        {
            return 0;
        }

        private void BtnAfficherPublications_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "publications",
                "Publications",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
