using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.Pages.Global;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ScheduleFlow.Pages.Employeur;
using ScheduleFlow.Pages.Gerant;
using ScheduleFlow.Pages.Global;


namespace ScheduleFlow.NavBar
{
    public partial class NavEmployeur : UserControl
    {

        private readonly GestionnaireSession _session;

        private AccueilGerant acceuil = App.ServiceProvider.GetRequiredService<AccueilGerant>();
        private PageProfil compte = App.ServiceProvider.GetRequiredService<PageProfil>();
        private CreationCompteParEmployeur creaCompte = App.ServiceProvider.GetRequiredService<CreationCompteParEmployeur>();
        private PubAnnonceGerant annonce = App.ServiceProvider.GetRequiredService<PubAnnonceGerant>();
        private Notification notif = App.ServiceProvider.GetRequiredService<Notification>();

        private SolidColorBrush backColorCurPage = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1561AF"));
        private SolidColorBrush backColorOtherPage = new SolidColorBrush(Colors.Transparent);

        public NavEmployeur(GestionnaireSession session)
        {
            _session = session;
            InitializeComponent();

            EmployeurArea.Content = acceuil;
            PageAccueil.Background = backColorCurPage;
        }

        private void BtnDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            _session.Reinitialiser();

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            var connexion = App.ServiceProvider.GetRequiredService<Connexion>();
            mainWindow.MainArea.Content = connexion;
        }


        public void ResetColor()
        {
            PageAccueil.Background = backColorOtherPage;
            PageCompte.Background = backColorOtherPage;
            PageCreaCompte.Background = backColorOtherPage;
            PageAnnonces.Background = backColorOtherPage;
            PageNotifications.Background = backColorOtherPage;
        }

        public void PageAccueil_Click(Object sender, MouseButtonEventArgs e)
        {
            EmployeurArea.Content = acceuil;
            ResetColor();
            PageAccueil.Background = backColorCurPage;
        }

        public void PageCompte_Click (Object sender, MouseButtonEventArgs e){
            EmployeurArea.Content = compte;
            ResetColor();
            PageCompte.Background = backColorCurPage;
        }

        public void PageCreaCompte_Click (Object sender, MouseButtonEventArgs e){
            EmployeurArea.Content = creaCompte;
            ResetColor();
            PageCreaCompte.Background = backColorCurPage;
        }

        public void PageAnnonces_Click (Object sender, MouseButtonEventArgs e){
            EmployeurArea.Content = annonce;
            ResetColor();
            PageAnnonces.Background = backColorCurPage;
        }

        public void PageNotifications_Click(Object sender, MouseButtonEventArgs e)
        {
            EmployeurArea.Content = notif;
            ResetColor();
            PageNotifications.Background = backColorCurPage;
        }

    }
}
