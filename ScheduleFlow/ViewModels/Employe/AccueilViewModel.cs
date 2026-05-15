using Domaine.Context;
using Domaine.Interface;
using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.Pages.Global;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleFlow.ViewModels.Employe
{
    internal class AccueilViewModel : INotifyPropertyChanged
    {
        private readonly IDemandeCongeRepository _repository;
        private readonly GestionnaireSession _session;

        private ObservableCollection<DemandeConge> _listeDemandes;
        public ObservableCollection<DemandeConge> ListeDemandes
        {
            get => _listeDemandes;
            set
            {
                _listeDemandes = value;
                OnPropertyChanged();
            }
        }

        public AccueilViewModel()
        {
            _repository = App.ServiceProvider.GetRequiredService<IDemandeCongeRepository>();
            _session = App.ServiceProvider.GetRequiredService<GestionnaireSession>();

            ListeDemandes = new ObservableCollection<DemandeConge>();

            _ = ChargerDemandesAsync();
        }


        public async Task ChargerDemandesAsync()
        {
            try
            {
                var demandes = await _repository.GetDemandesParUtilisateurAsync(_session.IdUtilisateur);

                if (demandes != null)
                {
                    ListeDemandes = new ObservableCollection<DemandeConge>(demandes);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Erreur chargement accueil :{ex.Message}");

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
