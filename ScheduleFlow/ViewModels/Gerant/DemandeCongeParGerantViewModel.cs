using CommunityToolkit.Mvvm.Input;
using Domaine.Interface;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Domaine.Entity;

namespace ScheduleFlow.ViewModels.Gerant
{
    public partial class DemandeCongeParGerantViewModel : INotifyPropertyChanged
    {
        private readonly IDemandeCongeRepository _congeRepo;
        private DemandeConge _selectDemande;
        public ObservableCollection<DemandeConge> ListeDemandes { get; set; }

        public DemandeConge SelectDemande
        {
            get => _selectDemande;
            set
            {
                _selectDemande = value;
                OnPropertyChanged();
            }
        }

        public ICommand ApprouverCommand { get; }
        public ICommand RefuserCommand { get; }
        public ICommand MettreAJourCommand { get; }

        public DemandeCongeParGerantViewModel(IDemandeCongeRepository repository)
        {
            _congeRepo = repository;
            ListeDemandes = new ObservableCollection<DemandeConge>();

            ApprouverCommand = new AsyncRelayCommand(() => ChangerStatut("Approuvé"));
            RefuserCommand = new AsyncRelayCommand(() => ChangerStatut("Refusé"));
            MettreAJourCommand = new AsyncRelayCommand(EnregistrerModifications);

            ChargerDonnees();
        }

        private async Task ChargerDonnees()
        {
            var items = await _congeRepo.ObtenirToutesLesDemandesAsync();
            ListeDemandes.Clear();
            foreach (var item in items) ListeDemandes.Add(item);
        }

        private async Task ChangerStatut(string nouveauStatut)
        {
            if (SelectDemande != null)
            {
                SelectDemande.Statut = nouveauStatut;
                await _congeRepo.ModifierDemandeCongeAsync(SelectDemande);
                OnPropertyChanged(nameof(SelectDemande));
                ChargerDonnees(); 
            }
        }

        private async Task EnregistrerModifications()
        {
            if (SelectDemande != null)
            {
                await _congeRepo.ModifierDemandeCongeAsync(SelectDemande);
                ChargerDonnees();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
