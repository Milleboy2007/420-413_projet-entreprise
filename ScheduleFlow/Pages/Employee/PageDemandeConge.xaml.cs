using ScheduleFlow.ViewModels.Employe;
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

namespace ScheduleFlow.Pages.Employee
{
    /// <summary>
    /// Logique d'interaction pour PageDemandeConge.xaml
    /// </summary>
    public partial class PageDemandeConge : UserControl
    {
        public PageDemandeConge(DemandeCongeViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel = new DemandeCongeViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
