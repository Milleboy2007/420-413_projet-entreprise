using Domaine.Entity;
using Domaine.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace ScheduleFlow.ViewModels.Employe
{
    internal class UtilisateurViewModel: INotifyPropertyChanged
    {
        private Utilisateur _utilisateurMetier;
        private readonly IUtilisateurRepository _repository;

        public UtilisateurViewModel(Utilisateur utilisateurMetier)
        {
            _utilisateurMetier = utilisateurMetier;
            //_repository = repository;
        }

            public string Nom
        {
            get => _utilisateurMetier.Nom;
            set
            {
                _utilisateurMetier.Nom = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NomComplet));
            }

        }

        public string Prenom
        {
            get => _utilisateurMetier.Prenom;
            set
            {
                _utilisateurMetier.Prenom = value;
                OnPropertyChanged();
            }
        }

        public string NomComplet => $"{Prenom} {Nom}";

        public string Genre
        {
            get => _utilisateurMetier.Genre;
            set 
            { 
                _utilisateurMetier.Genre = value; 
                OnPropertyChanged(); 
            }
        }

        public string Courriel
        {
            get => _utilisateurMetier.Courriel;
            set 
            { 
                _utilisateurMetier.Courriel = value; 
                OnPropertyChanged(); 
            }
        }

        public string CourrielEntreprise
        {
            get => _utilisateurMetier.CourrielEntreprise;
            set { _utilisateurMetier.CourrielEntreprise = value; 
                OnPropertyChanged(); }
        }

        public string TelephonePersonnel
        {
            get => _utilisateurMetier.NumeroTelephonePersonnel;
            set 
            { 
                _utilisateurMetier.NumeroTelephonePersonnel = value; 
                OnPropertyChanged(); 
            }
        }

        public string TelephoneProfessionnel
        {
            get => _utilisateurMetier.NumeroTelephoneProfessionnel;
            set
            { 
                _utilisateurMetier.NumeroTelephoneProfessionnel = value; 
                OnPropertyChanged();
            }
        }

        public string Adresse
        {
            get => _utilisateurMetier.Adresse;
            set
            { 
                _utilisateurMetier.Adresse = value; 
                OnPropertyChanged();
            }
        }

        public RoleUtilisateur Role {
            get => _utilisateurMetier.Role;
            set
            {
                _utilisateurMetier.Role = value;
                OnPropertyChanged();
            }
        }

        public string DateNaissance
        {
            get => _utilisateurMetier.DateNaissance;
            set
            {
                _utilisateurMetier.DateNaissance = value;
                OnPropertyChanged();
            }
        }
        public string Ville
        {
            get => _utilisateurMetier.Ville;
            set 
            { 
                _utilisateurMetier.Ville = value; 
                OnPropertyChanged(); 
            }
        }

        public string RegionProvince
        {
            get => _utilisateurMetier.RegionProvince;
            set 
            { 
                _utilisateurMetier.RegionProvince = value; 
                OnPropertyChanged(); 
            }
        }

        public string CodePostal
        {
            get => _utilisateurMetier.CodePostal;
            set 
            { _utilisateurMetier.CodePostal = value; 
                OnPropertyChanged(); 
            }
        }

        public string Pays
        {
            get => _utilisateurMetier.Pays;
            set 
            { 
                _utilisateurMetier.Pays = value; 
                OnPropertyChanged(); 
            }
        }

        public string NomContactUrgence
        {
            get => _utilisateurMetier.NomContactUrgence;
            set 
            { 
                _utilisateurMetier.NomContactUrgence = value; 
                OnPropertyChanged(); 
            }
        }

        public string TelephoneContactUrgence
        {
            get => _utilisateurMetier.TelephoneContactUrgence;
            set 
            { 
                _utilisateurMetier.TelephoneContactUrgence = value; 
                OnPropertyChanged(); 
            }
        }

        public string LienParente
        {
            get => _utilisateurMetier.LienParente;
            set 
            { 
                _utilisateurMetier.LienParente = value; 
                OnPropertyChanged(); 
            }
        }

        private void AfficherDonneesUtilisateur(int id)
        {
            _utilisateurMetier = _repository.ObtenirUtilisateurParId(id);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "null")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
