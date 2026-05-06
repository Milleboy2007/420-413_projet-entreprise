using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domaine.Entity;
using Domaine.Interface;
using System.Collections.ObjectModel;
using System.Windows;
using Domaine.Enum;

namespace ScheduleFlow.ViewModels.Global
{
    public partial class PageProfilViewModel : ObservableObject
    {
        private readonly IUtilisateurRepository _repo;

        public PageProfilViewModel(IUtilisateurRepository repo, Utilisateur user)
        {
            _repo = repo ?? throw new Exception("Repository not registered");

            Nom = user.Nom;
            Prenom = user.Prenom;
            Genre = user.Genre;
            DateNaissance = user.DateNaissance;

            Courriel = user.Courriel;
            CourrielEntreprise = user.CourrielEntreprise;

            Adresse = user.Adresse;
            Ville = user.Ville;
            RegionProvince = user.RegionProvince;
            CodePostal = user.CodePostal;
            Pays = user.Pays;

            TelephonePersonnel = user.NumeroTelephonePersonnel;
            TelephoneProfessionnel = user.NumeroTelephoneProfessionnel;

            Role = user.Role.ToString();
        }


        [ObservableProperty] private string nom;
        [ObservableProperty] private string prenom;
        [ObservableProperty] private string genre;
        [ObservableProperty] private string dateNaissance;

        [ObservableProperty] private string courriel;
        [ObservableProperty] private string courrielEntreprise;

        [ObservableProperty] private string adresse;
        [ObservableProperty] private string ville;
        [ObservableProperty] private string regionProvince;
        [ObservableProperty] private string codePostal;
        [ObservableProperty] private string pays;

        [ObservableProperty] private string telephonePersonnel;
        [ObservableProperty] private string telephoneProfessionnel;

        [ObservableProperty] private string role;

        public string NomComplet => $"{Prenom} {Nom}";


        [ObservableProperty] private ProfilChamp elementSelectionne;
        [ObservableProperty] private string nouvelleValeur;

        public ObservableCollection<ProfilChamp> ChampsProfil { get; } =
            new()
            {
                ProfilChamp.Prenom,
                ProfilChamp.Nom,
                ProfilChamp.Genre,
                ProfilChamp.DateNaissance,
                ProfilChamp.TelephonePersonnel,
                ProfilChamp.Adresse,
                ProfilChamp.CourrielPersonnel,
                ProfilChamp.TelephoneProfessionnel,
                ProfilChamp.CourrielEntreprise,
                ProfilChamp.Employeur,
                ProfilChamp.Poste
            };

        [RelayCommand]
        private void SupprimerCompte()
        {
            try
            {
                var result = MessageBox.Show(
                    "Supprimer ce compte ? Cette action est irréversible.",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result != MessageBoxResult.Yes)
                    return;

                if (string.IsNullOrWhiteSpace(Courriel))
                {
                    MessageBox.Show("Impossible de supprimer : utilisateur invalide.");
                    return;
                }

                var userToDelete = new Utilisateur
                {
                    Nom = Nom,
                    Prenom = Prenom,
                    Courriel = Courriel
                };

                _repo.SupprimerUtilisateur(userToDelete);

                MessageBox.Show("Utilisateur supprimé.");

                Nom = "";
                Prenom = "";
                Courriel = "";
                Genre = "";
                DateNaissance = "";
                Adresse = "";
                Ville = "";
                RegionProvince = "";
                CodePostal = "";
                Pays = "";
                TelephonePersonnel = "";
                TelephoneProfessionnel = "";
                CourrielEntreprise = "";
                Role = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur suppression: {ex.Message}");
            }
        }

        [RelayCommand]
        private void ModifierCompte()
        {
            try
            {
                if (_repo == null)
                {
                    MessageBox.Show("Repo is NULL");
                    return;
                }

                if (string.IsNullOrWhiteSpace(NouvelleValeur))
                {
                    MessageBox.Show("Valeur vide");
                    return;
                }

                switch (ElementSelectionne)
                {
                    case ProfilChamp.Prenom:
                        Prenom = NouvelleValeur;
                        break;

                    case ProfilChamp.Nom:
                        Nom = NouvelleValeur;
                        break;

                    case ProfilChamp.Genre:
                        Genre = NouvelleValeur;
                        break;

                    case ProfilChamp.DateNaissance:
                        DateNaissance = NouvelleValeur;
                        break;

                    case ProfilChamp.TelephonePersonnel:
                        TelephonePersonnel = NouvelleValeur;
                        break;

                    case ProfilChamp.Adresse:
                        Adresse = NouvelleValeur;
                        break;

                    case ProfilChamp.CourrielPersonnel:
                        Courriel = NouvelleValeur;
                        break;

                    case ProfilChamp.TelephoneProfessionnel:
                        TelephoneProfessionnel = NouvelleValeur;
                        break;

                    case ProfilChamp.CourrielEntreprise:
                        CourrielEntreprise = NouvelleValeur;
                        break;

                    case ProfilChamp.Employeur:
                        Role = NouvelleValeur;
                        break;

                    case ProfilChamp.Poste:
                        Ville = NouvelleValeur;
                        break;
                }

                var updated = new Utilisateur
                {
                    Nom = Nom,
                    Prenom = Prenom,
                    Genre = Genre,
                    DateNaissance = DateNaissance,
                    Courriel = Courriel,
                    CourrielEntreprise = CourrielEntreprise,
                    Adresse = Adresse,
                    Ville = Ville,
                    RegionProvince = RegionProvince,
                    CodePostal = CodePostal,
                    Pays = Pays,
                    NumeroTelephonePersonnel = TelephonePersonnel,
                    NumeroTelephoneProfessionnel = TelephoneProfessionnel,
                    Role = RoleUtilisateur.Employe
                };

                if (updated == null)
                {
                    MessageBox.Show("Updated is null (impossible but ok)");
                    return;
                }

                _repo.ModifierUtilisateur(updated);

                MessageBox.Show("Profil mis à jour.");
                NouvelleValeur = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
        }
    }

    public enum ProfilChamp
    {
        Prenom,
        Nom,
        Genre,
        DateNaissance,
        TelephonePersonnel,
        Adresse,
        CourrielPersonnel,
        TelephoneProfessionnel,
        CourrielEntreprise,
        Employeur,
        Poste
    }
}