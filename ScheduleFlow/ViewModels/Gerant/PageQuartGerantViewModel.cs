using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
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
        [ObservableProperty]
        private DateTime _dateFiltre = DateTime.Today;

        [ObservableProperty]
        private string _texteFiltre;

        public DateOnly PremierJour { get; private set; }
        public DateOnly DernierJour { get; private set; }

        public PageQuartGerantViewModel()
        {
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

        public void TrouverSemaine(DateTime date)
        {
            int decalage = (int)date.DayOfWeek;

            DateTime debut = date.AddDays(-decalage);
            DateTime fin = debut.AddDays(6);

            PremierJour = DateOnly.FromDateTime(debut);
            DernierJour = DateOnly.FromDateTime(fin);

            TexteFiltre = $"Semaine du {debut:d MMMM} au {fin:d MMMM}";
        }
    }
}
