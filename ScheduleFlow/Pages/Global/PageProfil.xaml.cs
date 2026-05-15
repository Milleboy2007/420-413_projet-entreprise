using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.ViewModels.Global;
using System.Windows.Controls;
using ScheduleFlow.ViewModels.Global;
using System.Windows.Controls;

namespace ScheduleFlow.Pages.Global
{
    public partial class PageProfil : UserControl
    {
        public PageProfil()
        {
            InitializeComponent();

            this.DataContext = App.ServiceProvider.GetService<PageProfilViewModel>();
        }
    }
}