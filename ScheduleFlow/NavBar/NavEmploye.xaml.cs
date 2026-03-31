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

namespace ScheduleFlow.NavBar
{
    /// <summary>
    /// Logique d'interaction pour NavEmploye.xaml
    /// </summary>
    public partial class NavEmploye : UserControl
    {
        private AccueilEmploye accueilEmploye = new AccueilEmploye();
        private Dispo dispo = new Dispo();
        private Page_Quart_Employee quart = new Page_Quart_Employee();
        private PageDemandeConge conge = new PageDemandeConge();

        public NavEmploye()
        {
            InitializeComponent();
            EmployeArea.Content = accueilEmploye;
        }

        private void PageAccueil_Click()
        {

        }

        private void PageCompte_Click() 
        {
            
        }
        
        private void PageDispo_Click()
        {

        }

        private void PageQuart_Click() 
        {

        }
        
        private void PageConge_Click()
        {

        }
        
        private void PageNotif_Click()
        {

        }
    }
}
