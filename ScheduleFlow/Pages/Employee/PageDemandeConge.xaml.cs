using Domaine.Interface;
using Microsoft.Extensions.DependencyInjection;
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
        public PageDemandeConge()
        {
            InitializeComponent();

            this.DataContext = App.ServiceProvider.GetRequiredService<DemandeCongeViewModel>();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is DemandeCongeViewModel vm)
            {
                try
                {
                    await vm.EnvoyerDemandeAsync();
                }
                catch (Exception ex) { 
                
                    MessageBox.Show($"Une erreur est survenue {ex.Message}");
                }
            }
        }
    }
}
