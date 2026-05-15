using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domaine.Entity;
using Domaine.Interface;
using System.Windows;
using Domaine.Enum;

namespace ScheduleFlow.ViewModels.Employeur
{
    public partial class CreationCompteParEmployeurViewModel : ObservableValidator
    {
        private readonly IUtilisateurRepository _repo;

        public CreationCompteParEmployeurViewModel(IUtilisateurRepository repo)
        {
            _repo = repo;
        }

        [ObservableProperty] private string nom;
        [ObservableProperty] private string prenom;
        [ObservableProperty] private string genre;
        [ObservableProperty] private string dateNaissance;
        [ObservableProperty] private string courriel;
        [ObservableProperty] private string motDePasse;
        [ObservableProperty] private string courrielEntreprise;
        [ObservableProperty] private string adresse;
        [ObservableProperty] private string pays;
        [ObservableProperty] private string ville;
        [ObservableProperty] private string regionProvince;
        [ObservableProperty] private string codePostal;
        [ObservableProperty] private string numeroTelephonePersonnel;
        [ObservableProperty] private string numeroTelephoneProfessionnel;
        [ObservableProperty] private string nomContactUrgence;
        [ObservableProperty] private string telephoneContactUrgence;
        [ObservableProperty] private string lienParente;

        [RelayCommand]
        private void AjouterGerant()
        {
            MessageBox.Show($"Clicked! Nom = {Nom}, Prenom = {Prenom}");
            if (string.IsNullOrWhiteSpace(Nom) ||
                string.IsNullOrWhiteSpace(Prenom) ||
                string.IsNullOrWhiteSpace(Courriel) ||
                string.IsNullOrWhiteSpace(MotDePasse))
            {
                return;
            }

            var user = new Utilisateur
            {
                Nom = Nom,
                Prenom = Prenom,
                Genre = Genre,
                DateNaissance = DateNaissance,
                Courriel = Courriel,
                MotDePasse = MotDePasse,
                CourrielEntreprise = CourrielEntreprise,
                Adresse = Adresse,
                Pays = Pays,
                Ville = Ville,
                RegionProvince = RegionProvince,
                CodePostal = CodePostal,
                NumeroTelephonePersonnel = NumeroTelephonePersonnel,
                NumeroTelephoneProfessionnel = NumeroTelephoneProfessionnel,
                NomContactUrgence = NomContactUrgence,
                TelephoneContactUrgence = TelephoneContactUrgence,
                LienParente = LienParente,
                Role = RoleUtilisateur.Gerant
            };

            _repo.AjouterUtilisateur(user);
        }
    }
}