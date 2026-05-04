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

        [ObservableProperty]
        private DateTime _dateFiltre = DateTime.Today;

        [ObservableProperty]
        private string _texteFiltre;
        public DateOnly PremierJour { get; private set; }
        public DateOnly DernierJour { get; private set; }
        public QuartEmployeViewModel(IQuartRepository quartRepo)
        {
            _quartRepo = quartRepo;
            TrouverSemaine(_dateFiltre);
            ChargerQuartsDispo();
        }

        private async void ChargerQuartsDispo()
        {
            QuartsDisponibles = new ObservableCollection<Quart>(await _quartRepo.GetAllPubQuartAsync(USERID));
        }

        private async void ChargerMonHoraire()
        {
            var mesQuart = await _quartRepo.GetAllQuartOfOnePersonForAWeekAsync(USERID, PremierJour, DernierJour);
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
                        Status = q.IsPub? StatusQuart.AttenteEchange: StatusQuart.Assigner,
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
            await _quartRepo.AssignerUserAsync(quart.Id, USERID);
            ChargerQuartsDispo();
            ChargerMonHoraire();
        }

        [RelayCommand]
        public async void PublierQuart(Quart quart)
        {
            if (quart.IsPub)
            {
                await _quartRepo.AssignerUserAsync(quart.Id, USERID);
            }
            else
            {
                await _quartRepo.PublierQuartAsync(quart.Id);
            }

            ChargerMonHoraire();
        }

        [RelayCommand]
        public void Next()
        {
            DateFiltre = DateFiltre.AddDays(7);
        }

        [RelayCommand]
        public void Prev()
        {
            DateFiltre = DateFiltre.AddDays(-7);
        }

        partial void OnDateFiltreChanged(DateTime value)
        {
            TrouverSemaine(value);
        }

        protected void TrouverSemaine(DateTime date)
        {
            int decalage = (int)date.DayOfWeek;

            DateTime debut = date.AddDays(-decalage);
            DateTime fin = debut.AddDays(6);

            PremierJour = DateOnly.FromDateTime(debut);
            DernierJour = DateOnly.FromDateTime(fin);

            TexteFiltre = $"Semaine du {debut:d MMMM} au {fin:d MMMM}";
            ChargerMonHoraire();
        }
    }
}
