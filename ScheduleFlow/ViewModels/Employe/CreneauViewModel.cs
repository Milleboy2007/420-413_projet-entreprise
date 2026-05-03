using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domaine.Entity;
using Domaine.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScheduleFlow.ViewModels.Employe
{
    public partial class CreneauViewModel : ObservableObject
    {
        private readonly ICreneauRepository _creneauRepository;

        [ObservableProperty]
        private string jour;

        [ObservableProperty]
        private TimeSpan heureDebut = new TimeSpan(8, 0, 0);

        [ObservableProperty]
        private TimeSpan heureFin = new TimeSpan(17, 0, 0);

        public CreneauViewModel(ICreneauRepository creneauRepository)
        {
            _creneauRepository = creneauRepository;
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
                Jour = this.Jour,
                HeureDebut = this.HeureDebut,
                HeureFin = this.HeureFin,
                IdFeuille = 1 // A changer, ne pas hardcode
            };

            await _creneauRepository.AjouterCreneau(creneau);
        }
    }
}
