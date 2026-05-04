using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domaine.dto;
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

        [ObservableProperty]
        private ObservableCollection<QuartEmploye_DTO> _mesQuarts;

        public QuartEmployeViewModel(IQuartRepository quartRepo)
        {
            _quartRepo = quartRepo;
            ChargerQuarts();
            ChargerMonHoraire();
        }

        private async void ChargerQuarts()
        {
            QuartsDisponibles = new ObservableCollection<Quart>(await _quartRepo.GetAllPubQuartAsync());
        }

        private async void ChargerMonHoraire()
        {
            var mesQuart = await _quartRepo.GetAllQuartOfOnePersonAsync(USERID);
            var listeAAfficher = new ObservableCollection<QuartEmploye_DTO>();

            foreach(var q in mesQuart)
            {
                int col = (int)q.Date.DayOfWeek;
                int ligne = q.Heures[0].Hour - 8;
                int duree = q.Heures[1].Hour - q.Heures[0].Hour;

                if (ligne >= 0 && ligne + duree <= 15)
                {
                    listeAAfficher.Add(new QuartEmploye_DTO
                    {
                        Quart = q,
                        ColonneGrid = col,
                        LigneGrid = ligne,
                        HauteurGrid = duree
                    });
                }
            }

            MesQuarts = listeAAfficher;
        }

        [RelayCommand]
        public async void PrendreQuart(Quart quart)
        {
            await _quartRepo.AssignerUserAsync(quart.Id,USERID);
            ChargerQuarts();
        }
    }
}
