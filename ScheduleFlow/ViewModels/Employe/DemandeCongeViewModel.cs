using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Context;
using Domaine.Interface;
using ScheduleFlow.Pages.Global;

namespace ScheduleFlow.ViewModels.Employe
{
    public class DemandeCongeViewModel
    {
        private readonly IDemandeCongeRepository _repository;
        private DemandeConge _demandeMetier;


        public DemandeCongeViewModel(IDemandeCongeRepository repository, GestionnaireSession session)
        {
            _repository = repository;

            idSession = session.IdUtilisateur;
            demande = repository.RechercherDemandeCongeAsync(idSession);
            //ChargerDemande();
        }

        public int DemandeCongeID
        {
            get => _demandeMetier.DemandeCongeID;
            set
            {
                _demandeMetier.DemandeCongeID = value;
                OnPropertyChanged();
            }
        }

        public int IdUtilisateur
        {
            get => _demandeMetier.IdUtilisateur;
            set
            {
                _demandeMetier.IdUtilisateur = value;
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

        public DateOnly DateDebut
        {
            get => _demandeMetier.DateDebut;
            set
            {
                _demandeMetier.DateDebut = value;
                OnPropertyChanged();
            }
        }

        public DateOnly DateFin
        {
            get => _demandeMetier.DateFin;
            set
            {
                _demandeMetier.DateFin = value;
                OnPropertyChanged();
            }
        }

        public string Raison
        {
            get => _demandeMetier.Raison;
            set
            {
                _demandeMetier.Raison = value;
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

        public void ChargerDemande(int id)
        {
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
