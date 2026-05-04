using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domaine.dto;
using Domaine.Entity;
using Domaine.Interface;
using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.Pages.Gerant.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScheduleFlow.ViewModels.Gerant
{
    public partial class PageQuartGerantViewModel : ObservableObject
    {
        private readonly IQuartRepository _quartRepo;
        private readonly IUtilisateurRepository _userRepo;

        [ObservableProperty]
        private object _panel;

        private AffichageQuartGerant_DTO? _quartSelec;

        [ObservableProperty]
        private DateTime _dateFiltre = DateTime.Today;

        [ObservableProperty]
        private string _texteFiltre;
        public DateOnly PremierJour { get; private set; }
        public DateOnly DernierJour { get; private set; }

        [ObservableProperty]
        private ObservableCollection<AffichageQuartGerant_DTO> _quartsDimanche;

        [ObservableProperty]
        private ObservableCollection<AffichageQuartGerant_DTO> _quartsLundi;

        [ObservableProperty]
        private ObservableCollection<AffichageQuartGerant_DTO> _quartsMardi;

        [ObservableProperty]
        private ObservableCollection<AffichageQuartGerant_DTO> _quartsMercredi;

        [ObservableProperty]
        private ObservableCollection<AffichageQuartGerant_DTO> _quartsJeudi;

        [ObservableProperty]
        private ObservableCollection<AffichageQuartGerant_DTO> _quartsVendredi;

        [ObservableProperty]
        private ObservableCollection<AffichageQuartGerant_DTO> _quartsSamedi;

        public PageQuartGerantViewModel(IQuartRepository quartRepo, IUtilisateurRepository userRepo)
        {
            _quartRepo = quartRepo;
            _userRepo = userRepo;
            TrouverSemaine(_dateFiltre);
            Panel = App.ServiceProvider.GetRequiredService<CreationQuart>();
        }

        [RelayCommand]
        public void SelecQuart(AffichageQuartGerant_DTO quart)
        {
            if (quart == _quartSelec)
            {
                _quartSelec = null;
                Panel = App.ServiceProvider.GetRequiredService<CreationQuart>();
            }
            else
            {
                _quartSelec = quart;
                var vueDetail = App.ServiceProvider.GetRequiredService<DetailQuart>();
                var detailVM = (DetailQuartViewModel)vueDetail.DataContext;
                detailVM.QuartSelec = quart;

                Panel = vueDetail;
            }
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
            ChargerSemaine();
        }

        protected async Task<ObservableCollection<AffichageQuartGerant_DTO>> ChargerJournee(DateOnly date)
        {
            var quarts = await _quartRepo.GetAllQuartByDateAsync(date);
            var listAAfficher = new ObservableCollection<AffichageQuartGerant_DTO>();
            Utilisateur? emp = null;

            foreach (var q in quarts)
            {
                
                if (q.UserId is int id) emp = await _userRepo.ObtenirParId(id);

                listAAfficher.Add(new AffichageQuartGerant_DTO
                {
                    Date = q.Date,
                    Heures = q.Heures,
                    Poste = q.Poste,
                    Status = q.UserId == null ? StatusQuart.NonAssigner: q.IsPub? StatusQuart.AttenteEchange: StatusQuart.Assigner,
                    Description = q.Description,
                    Nom = emp != null? emp.Nom: "N/A",
                    Prenom = emp != null ? emp.Prenom : "N/A"
                });
            }

            return listAAfficher;
        }

        protected async void ChargerSemaine()
        {
            var temp = PremierJour;
            QuartsDimanche = new ObservableCollection<AffichageQuartGerant_DTO>(await ChargerJournee(temp));
            QuartsLundi = new ObservableCollection<AffichageQuartGerant_DTO>(await ChargerJournee(temp.AddDays(1)));
            QuartsMardi = new ObservableCollection<AffichageQuartGerant_DTO>(await ChargerJournee(temp.AddDays(2)));
            QuartsMercredi = new ObservableCollection<AffichageQuartGerant_DTO>(await ChargerJournee(temp.AddDays(3)));
            QuartsJeudi = new ObservableCollection<AffichageQuartGerant_DTO>(await ChargerJournee(temp.AddDays(4)));
            QuartsVendredi = new ObservableCollection<AffichageQuartGerant_DTO>(await ChargerJournee(temp.AddDays(5)));
            QuartsSamedi = new ObservableCollection<AffichageQuartGerant_DTO>(await ChargerJournee(temp.AddDays(6)));
        }
    }
}
