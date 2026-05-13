using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.Pages.Employee;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScheduleFlow.NavBar
{
    public partial class NavEmploye : UserControl
    {
        private AccueilEmploye accueilEmploye = App.ServiceProvider.GetRequiredService<AccueilEmploye>();
        private Dispo dispo = App.ServiceProvider.GetRequiredService<Dispo>();
        private Page_Quart_Employee quart = App.ServiceProvider.GetRequiredService<Page_Quart_Employee>();
        private PageDemandeConge conge = App.ServiceProvider.GetRequiredService<PageDemandeConge>();
        private PageProfil compte = App.ServiceProvider.GetRequiredService<PageProfil>();

        private SolidColorBrush backColorCurPage = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1561AF"));
        private SolidColorBrush backColorOtherPage = new SolidColorBrush(Colors.Transparent);

        private readonly GestionnaireSession _session;

        public NavEmploye(GestionnaireSession session)
        {
            _session = session;
            InitializeComponent();
            EmployeArea.Content = accueilEmploye;
            PageAccueil.Background = backColorCurPage;
        }

        private void ResetColor()
        {
            PageAccueil.Background = backColorOtherPage;
            PageDispo.Background = backColorOtherPage;
            PageQuart.Background = backColorOtherPage;
            PageConge.Background = backColorOtherPage;
            PageCompte.Background = backColorOtherPage;
        }

        private void PageAccueil_Click(Object sender, MouseButtonEventArgs e)
        {
            EmployeArea.Content = accueilEmploye;
            ResetColor();
            PageAccueil.Background = backColorCurPage;
        }

        private void PageCompte_Click(Object sender, MouseButtonEventArgs e) 
        {
            EmployeArea.Content = compte;
            ResetColor();
            PageCompte.Background = backColorCurPage;
        }
        
        private void PageDispo_Click(Object sender, MouseButtonEventArgs e)
        {
            EmployeArea.Content = dispo;
            ResetColor();
            PageDispo.Background = backColorCurPage;
        }

        private void PageQuart_Click(Object sender, MouseButtonEventArgs e) 
        {
            EmployeArea.Content = quart;
            ResetColor();
            PageQuart.Background = backColorCurPage;
        }
        
        private void PageConge_Click(Object sender, MouseButtonEventArgs e)
        {
            EmployeArea.Content = conge;
            ResetColor();
            PageConge.Background = backColorCurPage;
        }
        
        private void PageNotif_Click(Object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            _session.Reinitialiser();

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            var connexion = App.ServiceProvider.GetRequiredService<Connexion>();
            mainWindow.MainArea.Content = connexion;
        }


    }
}
