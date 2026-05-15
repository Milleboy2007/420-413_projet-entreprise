using ScheduleFlow.ViewModels.Employe;
using System.Windows;
using System.Windows.Controls;

namespace ScheduleFlow.Pages.Employee
{
    public partial class Dispo : UserControl
    {
        
        public Dispo(CreneauViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            Loaded += async (s, e) => await viewModel.LoadCreneaux();
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
            PopupOverlay.Visibility = Visibility.Collapsed;
        }
    }
}
