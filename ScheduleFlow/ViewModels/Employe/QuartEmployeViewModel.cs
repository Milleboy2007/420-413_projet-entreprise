using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domaine.Entity;
using Domaine.Interface;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleFlow.ViewModels.Employe
{
    public partial class QuartEmployeViewModel : ObservableObject
    {
        private readonly IQuartRepository _quartRepo;

        //SIMULATION
        private int USERID = 1;

        [ObservableProperty]
        private ObservableCollection<Quart> _quartsDisponibles;

        public QuartEmployeViewModel(IQuartRepository quartRepo)
        {
            _quartRepo = quartRepo;
            ChargerQuarts();
        }

        private async void ChargerQuarts()
        {
            QuartsDisponibles = new ObservableCollection<Quart>(await _quartRepo.GetAllPubQuartAsync());
        }

        [RelayCommand]
        public async void PrendreQuart(Quart quart)
        {
            await _quartRepo.AssignerUserAsync(quart.Id,USERID);
            ChargerQuarts();
        }
    }
}
