using Domaine.Interface;
using ScheduleFlow.Pages.Global;
using Domaine.Enum;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Domaine.Entity;

namespace ScheduleFlow.ViewModels.Employe
{
    public class DemandeCongeViewModel: INotifyPropertyChanged
    {
        private readonly IDemandeCongeRepository _repository;
        private DemandeConge _demandeMetier;
        private int USERID;


        public DemandeCongeViewModel(IDemandeCongeRepository repository, GestionnaireSession session)
        {
            _repository = repository;
            _demandeMetier = new DemandeConge();

            _demandeMetier.IdEmployee = session.IdUtilisateur;
            USERID = session.IdUtilisateur;

            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            _demandeMetier.DateDebut = today;
            _demandeMetier.DateFin = today;

        }
        public int DemandeCongeID
        {
            get => _demandeMetier.IDDemandeConge;
            set
            {
                _demandeMetier.IDDemandeConge = value;
                OnPropertyChanged();
            }
        }

        public int IdUtilisateur
        {
            get => _demandeMetier.IdEmployee;
            set
            {
                _demandeMetier.IdEmployee = value;
                OnPropertyChanged();
            }
        }

        public RoleUtilisateur Approbateur
        {
            get => _demandeMetier.Approbateur;
            set
            {
                _demandeMetier.Approbateur = value;
                OnPropertyChanged();
            }
        }
        public string TypeConge
        {
            get => _demandeMetier.TypeConge;
            set
            {
                _demandeMetier.TypeConge = value;
                OnPropertyChanged();
            }
        }

        public DateTime? DateDebut
        {
            get => _demandeMetier.DateDebut.ToDateTime(TimeOnly.MaxValue);
            set
            {
                if (value.HasValue) 
                {
                    _demandeMetier.DateDebut = DateOnly.FromDateTime(value.Value);
                    OnPropertyChanged();
                }
            }
        }

        public DateTime? DateFin
        {
            get => _demandeMetier.DateFin.ToDateTime(TimeOnly.MaxValue);
            set
            {
                if (value.HasValue)
                {
                    _demandeMetier.DateFin = DateOnly.FromDateTime(value.Value);
                    OnPropertyChanged();
                }
            }
        }

        public string Raison
        {
            get => _demandeMetier.Motif;
            set
            {
                _demandeMetier.Motif = value;
                OnPropertyChanged();
            }
        }

        public string Statut
        {
            get => _demandeMetier.Statut;
            set
            {
                _demandeMetier.Statut = value;
                OnPropertyChanged();
            }
        }

        public async Task EnvoyerDemandeAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TypeConge))
                {
                    MessageBox.Show("Veuillez spécifier le type de congé (ex: Maladie, Vacances).", "Champ manquant");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Raison))
                {
                    MessageBox.Show("Veuillez entrez une raison pour votre demande.", "Champ manquant");
                    return;
                }

                if (_demandeMetier.DateDebut == default || _demandeMetier.DateFin == default)
                {
                    MessageBox.Show("Veuillez sélectionner une date de début et de fin.", "Dates manquantes");
                    return;
                }

                if (DateDebut > DateFin)
                {
                    MessageBox.Show("La date de début doit être avant la date de fin.");
                    return;
                }
                if (DateDebut == DateFin)
                {
                    MessageBox.Show("La date de début ne doit pas être la même que la date de fin.");
                    return;
                }

                await _repository.AjouterDemandeCongeAsync(_demandeMetier);

                MessageBox.Show("Demande envoyée avec succès !");
                ReinitialiserChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'envoi : {ex.Message}");
            }
;
            
        }



        private void ReinitialiserChamps()
        {
            int idUser = _demandeMetier.IdEmployee;
            _demandeMetier.IdEmployee = idUser;

            _demandeMetier = new DemandeConge();
            _demandeMetier.IdEmployee = idUser;
            DateTime today = DateTime.Today;
            DateDebut = today;
            DateFin = today;

            OnPropertyChanged(nameof(TypeConge));
            OnPropertyChanged(nameof(DateDebut));
            OnPropertyChanged(nameof(DateFin));
            OnPropertyChanged(nameof(Raison));
            OnPropertyChanged(nameof(Statut));
        }
            
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "null")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
