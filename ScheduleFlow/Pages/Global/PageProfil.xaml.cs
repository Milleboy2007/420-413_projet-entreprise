using Domaine.Entity;
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
using ScheduleFlow.ViewModels.Employe;

namespace ScheduleFlow.Pages.Global
{
    /// <summary>
    /// Logique d'interaction pour PageProfil.xaml
    /// </summary>
    public partial class PageProfil : UserControl
    {
        public PageProfil()
        {
            InitializeComponent();
            var userTest = new Utilisateur
            {
                Nom = "Doe",
                Prenom = "Jane",
                Genre = "Féminin",
                Courriel = "jane.doe@example.com",


            };

            this.DataContext = new UtilisateurViewModel(userTest);
        }
    }
}
