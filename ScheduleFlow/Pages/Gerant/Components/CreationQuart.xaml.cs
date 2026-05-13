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
            var _dateTime = date.SelectedDate;
            if (_dateTime == null)
            {
                MessageBox.Show("Veuillez sélectionner une date.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var _dateOnly = DateOnly.FromDateTime(_dateTime.Value);

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
            if (_poste == "")
            {
                MessageBox.Show("Un post doit être entrer!", "Erreur, création interrompu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var _assignation = assignation.SelectedItem as Utilisateur;
            var _description = description.Text;
            if (_description == "")
            {
                MessageBox.Show("Il doit y avor une description!", "Erreur, création interrompu", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (this.DataContext is CreerQuartViewModel monView)
            {
                try
                {
                    monView.CreerQuart(_dateOnly, _heureDebut, _heureFin, _poste, _assignation, _description);

                    MessageBox.Show("Le quart a été créé avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Une erreur est survenue lors de la sauvegarde : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
