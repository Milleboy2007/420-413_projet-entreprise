using CommunityToolkit.Mvvm.ComponentModel;
using Domaine.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.dto;

namespace ScheduleFlow.ViewModels.Gerant
{
    public partial class DetailQuartViewModel: ObservableObject
    {
        private readonly IQuartRepository _quartRepo;

        [ObservableProperty]
        private AffichageQuartGerant_DTO _quartSelec;

        public DetailQuartViewModel(IQuartRepository quartRepo)
        {
            _quartRepo = quartRepo;
        }
    }
}
