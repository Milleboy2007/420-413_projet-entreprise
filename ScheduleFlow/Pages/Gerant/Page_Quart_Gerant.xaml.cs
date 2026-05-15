using ScheduleFlow.ViewModels.Gerant;
using System.Windows.Controls;

namespace ScheduleFlow.Pages.Gerant
{
    public partial class Page_Quart_Gerant : UserControl
    {
        public Page_Quart_Gerant(PageQuartGerantViewModel monView)
        {
            InitializeComponent();

            this.DataContext = monView;
        }
    }
}
