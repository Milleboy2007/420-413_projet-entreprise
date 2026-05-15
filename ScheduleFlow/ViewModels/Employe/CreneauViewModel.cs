using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domaine.Entity;
using Domaine.Interface;
using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.Pages.Global;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScheduleFlow.ViewModels.Employe
{
    public partial class CreneauViewModel : ObservableObject
    {
        private readonly ICreneauRepository _creneauRepository;
        private int FeuilleID = App.ServiceProvider.GetRequiredService<GestionnaireSession>().IdFeuille;

        [ObservableProperty]
        private string jour = "Lundi";

        [ObservableProperty]
        private TimeSpan heureDebut = new TimeSpan(8, 0, 0);

        [ObservableProperty]
        private TimeSpan heureFin = new TimeSpan(17, 0, 0);

        [ObservableProperty]
        private ObservableCollection<CreneauDispo> creneauExiste = new();

        public CreneauViewModel(ICreneauRepository creneauRepository)
        {
            _creneauRepository = creneauRepository;
        }

        public async Task LoadCreneaux()
        {
            if (FeuilleID <= 0)
            {
                CreneauExiste = new ObservableCollection<CreneauDispo>();
                return;
            }

            var data = await _creneauRepository.GetCreneauxByFeuilleId(FeuilleID);
            CreneauExiste = new ObservableCollection<CreneauDispo>(data);
        }

        [RelayCommand]
        public async Task SupprimerCreneau(CreneauDispo creneau)
        {
            if (creneau == null) return;

            // The Prompt
            var result = MessageBox.Show(
                $"Voulez-vous vraiment supprimer la disponibilité du {creneau.Jour} de {creneau.HeureDebut:hh\\:mm} à {creneau.HeureFin:hh\\:mm} ?",
                "Confirmation de suppression",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Delete from Database via Repository
                await _creneauRepository.SupprimerCreneau(creneau.IdCreneau);

                // Refresh the UI list
                await LoadCreneaux();
            }
        }

        [RelayCommand]
        public async Task AjouterCreneau()
        {
            if (HeureFin <= HeureDebut)
            {
                MessageBox.Show("L'heure de fin doit être après l'heure de début.");
                return;
            }
            var creneau = new CreneauDispo
            {
                IdFeuille = FeuilleID,
                Jour = this.Jour,
                HeureDebut = this.HeureDebut,
                HeureFin = this.HeureFin
            };
            await _creneauRepository.AjouterCreneau(creneau);
            await LoadCreneaux();
        }
    }
}
