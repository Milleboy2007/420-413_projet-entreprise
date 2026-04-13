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
