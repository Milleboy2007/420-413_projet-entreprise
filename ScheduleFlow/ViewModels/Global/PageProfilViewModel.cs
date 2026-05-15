using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domaine.Entity;
using Domaine.Interface;
using System.Collections.ObjectModel;
using System.Windows;
using Domaine.Enum;
using ScheduleFlow.Pages.Global;

namespace ScheduleFlow.ViewModels.Global
{
    public partial class PageProfilViewModel : ObservableObject
    {
        private readonly IUtilisateurRepository _repo;
        private int _id;
        private Utilisateur _user;
        
        public PageProfilViewModel(IUtilisateurRepository repo, GestionnaireSession session)
        {
            _repo = repo ?? throw new Exception("Repository not registered");
            _id = session.IdUtilisateur;

            var userBD = _repo.ObtenirUtilisateurParId(_id);
            var utilisateur = _repo.ObtenirUtilisateurParId(session.IdUtilisateur);

            if (utilisateur != null)
            {
                Nom = utilisateur.Nom;
                Prenom = utilisateur.Prenom;
                Genre = utilisateur.Genre;
                DateNaissance = utilisateur.DateNaissance;
                Courriel = utilisateur.Courriel;
                CourrielEntreprise = utilisateur.CourrielEntreprise;
                Adresse = utilisateur.Adresse;
                Ville = utilisateur.Ville;
                TelephonePersonnel = utilisateur.NumeroTelephonePersonnel;
                TelephoneProfessionnel = utilisateur.NumeroTelephoneProfessionnel;
                Role = utilisateur.Role.ToString();
            }
            _user = _repo.ObtenirUtilisateurParId(_id);
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
                ProfilChamp.Ville,
                ProfilChamp.CodePostal,
                ProfilChamp.RegionProvince,
                ProfilChamp.Pays,
                ProfilChamp.CourrielPersonnel,
                ProfilChamp.TelephoneProfessionnel,
                ProfilChamp.CourrielEntreprise,
                ProfilChamp.NomContactUrgence,
                ProfilChamp.TelephoneContactUrgence,
                ProfilChamp.LienParente,
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
                        _user.Prenom = NouvelleValeur;
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
                _repo.ModifierUtilisateur(_user);
                var updated = new Utilisateur
                {
                    IdUtilisateur = _id,
                    Nom = Nom,
                    Prenom = Prenom,
                    Genre = Genre,
                    Courriel = Courriel,
                    CourrielEntreprise = CourrielEntreprise
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
        Ville,
        CodePostal,
        RegionProvince,
        Pays,
        CourrielPersonnel,
        TelephoneProfessionnel,
        CourrielEntreprise,
        NomContactUrgence,
        TelephoneContactUrgence,
        LienParente,
        Employeur,
        Poste
    }
}