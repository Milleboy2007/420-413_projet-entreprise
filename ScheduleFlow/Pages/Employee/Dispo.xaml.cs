using Domaine.Context;
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
    public partial class Dispo : UserControl
    {
        
        public Dispo(CreneauViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private void OpenPopup_Click(object sender, RoutedEventArgs e)
        {
            PopupOverlay.Visibility = Visibility.Visible;
        }

        private void CancelPopup_Click(object sender, RoutedEventArgs e)
        {
            PopupOverlay.Visibility = Visibility.Collapsed;
        }

        private async void SaveDispo_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CreneauViewModel vm)
            {
                // Execute the RelayCommand
                await vm.AjouterCreneauCommand.ExecuteAsync(null);
            }
            PopupOverlay.Visibility = Visibility.Collapsed;
        }
    }
}
