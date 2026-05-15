using ScheduleFlow.ViewModels.Gerant;
using System.Windows.Controls;

namespace ScheduleFlow.Pages.Gerant
{
    /// <summary>
    /// Logique d'interaction pour Conge.xaml
    /// </summary>
    public partial class Conge : UserControl
    {
        public Conge(DemandeCongeParGerantViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
