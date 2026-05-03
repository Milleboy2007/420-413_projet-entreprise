using ScheduleFlow.NavBar;
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

namespace ScheduleFlow.Pages.Global
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : UserControl
    {
        public Connexion()
        {
            InitializeComponent();
        }


        private void BtnConnexion_Click(object sender, RoutedEventArgs e)
        {
            // C'est ici que tu géreras la connexion plus tard
        }


        private void BtnEmploye_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainArea.Content = new NavEmploye();
        }

        private void BtnGerant_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainArea.Content = new NavGerant();
        }
    }
}




