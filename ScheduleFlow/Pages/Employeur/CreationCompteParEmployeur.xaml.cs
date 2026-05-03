using Domaine.Interface;
using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.ViewModels.Employe;
using ScheduleFlow.ViewModels.Employeur;
using System.Windows.Controls;

namespace ScheduleFlow.Pages.Employeur
{
    public partial class CreationCompteParEmployeur : UserControl
    {
        public CreationCompteParEmployeur()
        {
            InitializeComponent();

            var repo = App.ServiceProvider.GetService<IUtilisateurRepository>();
            DataContext = new CreationCompteParEmployeurViewModel(repo);
        }
    }
}
