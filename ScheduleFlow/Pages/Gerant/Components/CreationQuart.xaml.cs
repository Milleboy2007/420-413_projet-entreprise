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

namespace ScheduleFlow.Pages.Gerant.Components
{
    /// <summary>
    /// Logique d'interaction pour CreationQuart.xaml
    /// </summary>
    public partial class CreationQuart : UserControl
    {
        public CreationQuart(CreerQuartViewModel monView)
        {
            InitializeComponent();
            this.DataContext = monView;
        }
        public void BtnCreer(object sender, RoutedEventArgs e)
        {
            var _heureFin = heureFin.Text;
        }
    }
}
