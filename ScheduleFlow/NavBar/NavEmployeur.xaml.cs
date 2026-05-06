using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.Pages.Global;
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
using ScheduleFlow.Pages.Employeur;
using ScheduleFlow.Pages.Gerant;
using ScheduleFlow.Pages.Global;


namespace ScheduleFlow.NavBar
{
    public partial class NavEmployeur : UserControl
    {

        private readonly GestionnaireSession _session;
        private AccueilGerant acceuil = new AccueilGerant();
        private PageProfil compte = new PageProfil();
        private CreationCompteParEmployeur creaCompte = new CreationCompteParEmployeur();
        private PubAnnonceGerant annonce = new PubAnnonceGerant();

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

        }

    }
}
