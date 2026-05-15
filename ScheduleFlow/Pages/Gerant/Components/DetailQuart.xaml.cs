using System.Windows.Controls;
using ScheduleFlow.ViewModels.Gerant;

namespace ScheduleFlow.Pages.Gerant.Components
{
    /// <summary>
    /// Logique d'interaction pour DetailQuart.xaml
    /// </summary>
    public partial class DetailQuart : UserControl
    {
        public DetailQuart(DetailQuartViewModel monView)
        {
            InitializeComponent();
            DataContext = monView;
        }
    }
}
