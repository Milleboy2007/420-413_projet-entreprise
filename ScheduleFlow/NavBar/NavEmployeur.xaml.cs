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
        private AccueilGerant acceuil = new AccueilGerant();
        private PageProfil compte = new PageProfil();
        private CreationCompteParEmployeur creaCompte = new CreationCompteParEmployeur();
        private PubAnnonceGerant annonce = new PubAnnonceGerant();

        private SolidColorBrush backColorCurPage = (SolidColorBrush)(new BrushConverter().ConvertFrom("#1561AF"));
        private SolidColorBrush backColorOtherPage = new SolidColorBrush(Colors.Transparent);

        public NavEmployeur()
        {
            InitializeComponent();

            EmployeurArea.Content = acceuil;
            PageAccueil.Background = backColorCurPage;
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
