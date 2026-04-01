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
using ScheduleFlow.Pages.Employee;
using ScheduleFlow.Pages.Global;

namespace ScheduleFlow.NavBar
{
    public partial class NavEmploye : UserControl
    {
        private AccueilEmploye accueilEmploye = new AccueilEmploye();
        private Dispo dispo = new Dispo();
        private Page_Quart_Employee quart = new Page_Quart_Employee();
        private PageDemandeConge conge = new PageDemandeConge();
        private PageProfil compte = new PageProfil();

        private SolidColorBrush backColorCurPage = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1561AF"));
        private SolidColorBrush backColorOtherPage = new SolidColorBrush(Colors.Transparent);


        public NavEmploye()
        {
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
    }
}
