
using System.ComponentModel;
using Domaine.Interface;
using System.Collections.ObjectModel;
using Domaine.Entity;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleFlow.ViewModels.Employer
{
    class EmployerViewModel : INotifyPropertyChanged
    {
        private readonly IScheduleFlowRepository _repository;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Gerant> Gerants { get; set; }

        public ICommand AjouterGerantCommand { get; set; }
        public ICommand SupprimerGerantCommand { get; set; }

        public EmployerViewModel(IScheduleFlowRepository repository)
        {
            _repository = repository;

            ChargerGerants();

            // ✅ Créer les commandes
            AjouterGerantCommand = new RelayCommand<string>(AjouterGerant);
            SupprimerGerantCommand = new RelayCommand<Gerant>(SupprimerGerant);
        }

        private void ChargerGerants()
        {
            var taches = _repository.ObtenirTousGerants();
            Gerants = new ObservableCollection<Gerant>(Gerants);
        }

        private void AjouterGerant()
        {

            var gerant = new Gerant {};

            // ✅ Le Repository s'occupe de la base de données
            _repository.AjouterGerant(gerant);

            // Ajouter à l'UI
            Gerants.Add(gerant);
        }

        private void SupprimerTache(Gerant gerant)
        {
            if (gerant == null)
                return;

            // ✅ Le Repository s'occupe de la base de données
            _repository.SupprimerGerant(gerant.Id);

            // Retirer de l'UI
            Gerants.Remove(gerant);
        }
    }
}
