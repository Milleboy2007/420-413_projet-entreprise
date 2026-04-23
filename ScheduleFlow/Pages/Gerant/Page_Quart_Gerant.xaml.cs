using ScheduleFlow.Pages.Gerant.Components;
using ScheduleFlow.ViewModels.Gerant;
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
    public partial class Page_Quart_Gerant : UserControl
    {
        PageQuartGerantViewModel monView = new PageQuartGerantViewModel();
        public Page_Quart_Gerant()
        {
            InitializeComponent();

            this.DataContext = monView;
            Panel.Content = new CreationQuart();
        }
    }
}
