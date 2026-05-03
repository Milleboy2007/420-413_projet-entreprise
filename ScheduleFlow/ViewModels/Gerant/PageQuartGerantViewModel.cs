using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domaine.Entity;
using Domaine.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using Domaine.dto;

namespace ScheduleFlow.ViewModels.Gerant
{
    public partial class PageQuartGerantViewModel : ObservableObject
    {
        private readonly IQuartRepository _quartRepo;
        private readonly IUtilisateurRepository _userRepo;

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
                    Heures = q.Heures,
                    Post = q.Post,
                    Status = q.UserId == null ? StatusQuart.NonAssigner: q.IsPub? StatusQuart.AttenteEchange: StatusQuart.Assigner,
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
