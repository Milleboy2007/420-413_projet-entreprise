using Domaine.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using ScheduleFlow.ViewModels.Employeur;

namespace ScheduleFlow.Pages.Employeur
{
    public partial class CreationCompteParEmployeur : UserControl
    {
        public CreationCompteParEmployeur(CreationCompteParEmployeurViewModel monView)
        {
            InitializeComponent();

            DataContext = monView;
        }
    }
}
