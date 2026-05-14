using Domaine.Entity;
using Domaine.Interface;
using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.ViewModels.Employe;
using ScheduleFlow.ViewModels.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Domaine.Entity;
using Domaine.Interface;
using ScheduleFlow.ViewModels.Global;
using System.Windows.Controls;

namespace ScheduleFlow.Pages.Global
{
    public partial class PageProfil : UserControl
    {
        private UtilisateurViewModel utilisateurViewModel;
        public PageProfil()
        {
            InitializeComponent();

            DataContext = App.ServiceProvider.GetService<UtilisateurViewModel>();
        }
    }
}