using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.Pages.Global;
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

namespace ScheduleFlow.NavBar
{
    /// <summary>
    /// Logique d'interaction pour NavEmployeur.xaml
    /// </summary>
    public partial class NavEmployeur : UserControl
    {

        private readonly GestionnaireSession _session;
        public NavEmployeur(GestionnaireSession session)
        {
            _session = session;
            InitializeComponent();
        }

        private void BtnDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            _session.Reinitialiser();

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            var connexion = App.ServiceProvider.GetRequiredService<Connexion>();
            mainWindow.MainArea.Content = connexion;
        }



    }
}
