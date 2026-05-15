using System.Windows;
using System.Windows.Controls;

namespace ScheduleFlow.Pages.Gerant
{
    /// <summary>
    /// Logique d'interaction pour CreationCompteParGerant.xaml
    /// </summary>
    public partial class CreationCompteParGerant : UserControl
    {
        public CreationCompteParGerant(CreationCompteParGerantViewModel monView)
        {
            InitializeComponent();
            DataContext = monView;
        }


        private void BtnEnvoyer_Click(object sender, RoutedEventArgs e)
        {
            // Action minimale pour Envoyer
            MessageBox.Show("Formulaire envoyé", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
