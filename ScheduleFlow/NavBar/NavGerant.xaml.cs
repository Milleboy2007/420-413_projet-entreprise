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

using ScheduleFlow.Pages.Gerant;
using ScheduleFlow.Pages.Global;

namespace ScheduleFlow.NavBar
{
    public partial class NavGerant : UserControl
    {

        private AccueilGerant accueilGerant = new AccueilGerant();
        private Conge conge = new Conge();
        private CreationCompteParGerant creationCompteParGerant = new CreationCompteParGerant();
        private Page_Quart_Gerant quart = new Page_Quart_Gerant();
        private PageProfil compte = new PageProfil();

        private SolidColorBrush backColorCurPage = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1561AF"));
        private SolidColorBrush backColorOtherPage = new SolidColorBrush(Colors.Transparent);

        public NavGerant()
        {
            InitializeComponent();
            GerantArea.Content = accueilGerant;
            PageAccueil.Background = backColorCurPage;
        }

        private void ResetColor()
        {
            PageAccueil.Background = backColorOtherPage;
            PageCompte.Background = backColorOtherPage;
            PageCreaCompte.Background = backColorOtherPage;
            PageQuart.Background = backColorOtherPage;
            PageConge.Background = backColorOtherPage;
            PageAnnonces.Background = backColorOtherPage;
            PageNotifications.Background = backColorOtherPage;
        }

        private void PageAccueil_Click(Object sender, MouseButtonEventArgs e)
        {
            GerantArea.Content = accueilGerant;
            ResetColor();
            PageAccueil.Background = backColorCurPage;
        }

        private void PageCompte_Click(Object sender, MouseButtonEventArgs e)
        {
            GerantArea.Content = compte;
            ResetColor();
            PageCompte.Background = backColorCurPage;
        }
        
        private void PageCreaCompte_Click(Object sender, MouseButtonEventArgs e)
        {
            GerantArea.Content = creationCompteParGerant;
            ResetColor();
            PageCreaCompte.Background = backColorCurPage;
        }
        
        private void PageQuart_Click(Object sender, MouseButtonEventArgs e)
        {
            GerantArea.Content = quart;
            ResetColor();
            PageQuart.Background = backColorCurPage;
        }
        
        private void PageConge_Click(Object sender, MouseButtonEventArgs e)
        {
            GerantArea.Content = conge;
            ResetColor();
            PageConge.Background = backColorCurPage;
        }
        
        private void PageAnnonces_Click(Object sender, MouseButtonEventArgs e)
        {
            
        }
        
        private void PageNotifications_Click(Object sender, MouseButtonEventArgs e)
        {

        }
    }
}
