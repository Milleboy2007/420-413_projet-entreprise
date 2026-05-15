using System.Windows.Controls;
using ScheduleFlow.ViewModels.Employe;

namespace ScheduleFlow.Pages.Employee
{
    /// <summary>
    /// Logique d'interaction pour Page_Quart_Employee.xaml
    /// </summary>
    public partial class Page_Quart_Employee : UserControl
    {
        public Page_Quart_Employee(QuartEmployeViewModel monView)
        {
            InitializeComponent();
            DataContext = monView;
        }
    }
}
