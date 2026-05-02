using Domaine.Entity;
using ScheduleFlow.ViewModels.Gerant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScheduleFlow.Pages.Gerant.Components
{
    /// <summary>
    /// Logique d'interaction pour CreationQuart.xaml
    /// </summary>
    public partial class CreationQuart : UserControl
    {
        public CreationQuart(CreerQuartViewModel monView)
        {
            InitializeComponent();
            this.DataContext = monView;
        }
        public void BtnCreer(object sender, RoutedEventArgs e)
        {
            var _date = date.SelectedDate;

            TimeOnly _heureDebut;
            if (heureDebut.SelectedItem is TimeOnly itemDebut)
            {
                _heureDebut = itemDebut;
            }else if (!TimeOnly.TryParse(heureDebut.Text, out _heureDebut))
            {
                MessageBox.Show("L'heure de début est invalide!", "Erreur, création interrompu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            TimeOnly _heureFin;
            if (heureFin.SelectedItem is TimeOnly itemFin)
            {
                _heureFin = itemFin;
            } else if (!TimeOnly.TryParse(heureFin.Text, out _heureFin))
            {
                MessageBox.Show("L'heure de fin est invalide!", "Erreur, création interrompu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_heureFin <= _heureDebut && _heureFin != TimeOnly.MinValue)
            {
                MessageBox.Show("L'heure de fin doit être après l'heure de début!", "Erreur, création interrompu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var _poste = poste.Text;
            var _assignation = assignation.SelectedItem as Utilisateur;
            var _description = description.Text;


        }
    }
}
