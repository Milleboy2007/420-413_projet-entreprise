using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleFlow.ViewModels.Gerant
{
    public partial class PageQuartGerantViewModel : ObservableObject
    {
        [ObservableProperty]
        private object panneauActif;

        public PageQuartGerantViewModel()
        {
            PanneauActif = new CreerQuartViewModel();
        }

    }
}
