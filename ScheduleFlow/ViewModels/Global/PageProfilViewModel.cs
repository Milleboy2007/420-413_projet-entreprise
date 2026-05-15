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
        public List<RoleUtilisateur> Roles { get; } = Enum.GetValues(typeof(RoleUtilisateur)).Cast<RoleUtilisateur>().ToList();

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
                Role = utilisateur.Role;
                CodePostal = utilisateur.CodePostal;
                RegionProvince = utilisateur.RegionProvince;
                Pays = utilisateur.Pays;
                NomContactUrgence = utilisateur.NomContactUrgence;
                TelephoneContactUrgence = utilisateur.TelephoneContactUrgence;
                LienParente = utilisateur.LienParente;
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

        [ObservableProperty] private string nomContactUrgence;
        [ObservableProperty] private string telephoneContactUrgence;
        [ObservableProperty] private string lienParente;

        [ObservableProperty] private RoleUtilisateur role;

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
                ProfilChamp.CourrielPersonnel,
                ProfilChamp.Role,
                ProfilChamp.Adresse,
                ProfilChamp.Ville,
                ProfilChamp.CodePostal,
                ProfilChamp.RegionProvince,
                ProfilChamp.Pays,
                ProfilChamp.TelephoneProfessionnel,
                ProfilChamp.CourrielEntreprise,
                ProfilChamp.NomContactUrgence,
                ProfilChamp.TelephoneContactUrgence,
                ProfilChamp.LienParente
            };

        public bool IsRoleSelectionActive => ElementSelectionne == ProfilChamp.Role;
        public bool IsTextEntryActive => !IsRoleSelectionActive;

        partial void OnElementSelectionneChanged(ProfilChamp value)
        {
            OnPropertyChanged(nameof(IsRoleSelectionActive));
            OnPropertyChanged(nameof(IsTextEntryActive));
        }
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
                Role = RoleUtilisateur.Personne;
                OnPropertyChanged(nameof(NomComplet));
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
                        Prenom = NouvelleValeur;
                        break;

                    case ProfilChamp.Nom:
                        _user.Nom = NouvelleValeur;
                        Nom = NouvelleValeur;
                        break;

                    case ProfilChamp.Genre:
                        _user.Genre = NouvelleValeur;
                        Genre = NouvelleValeur; 
                        break;

                    case ProfilChamp.DateNaissance:
                        _user.DateNaissance = NouvelleValeur;
                        DateNaissance = NouvelleValeur;
                        break;

                    case ProfilChamp.TelephonePersonnel:
                        _user.NumeroTelephonePersonnel = NouvelleValeur;
                        TelephonePersonnel = NouvelleValeur;
                        break;
                    
                    case ProfilChamp.Role:
                        _user.Role = role;  
                        break;

                    case ProfilChamp.Adresse:
                        _user.Adresse = NouvelleValeur;
                        Adresse = NouvelleValeur;
                        break;  

                    case ProfilChamp.CourrielPersonnel:
                        _user.Courriel = NouvelleValeur;
                        Courriel = NouvelleValeur;
                        break;

                    case ProfilChamp.TelephoneProfessionnel:
                        _user.NumeroTelephoneProfessionnel = NouvelleValeur;
                        TelephoneProfessionnel = NouvelleValeur;
                        break;

                    case ProfilChamp.CourrielEntreprise:
                        _user.CourrielEntreprise = NouvelleValeur;
                        CourrielEntreprise = NouvelleValeur;
                        break;

                    case ProfilChamp.Ville:
                        _user.Ville = NouvelleValeur;   
                        Ville = NouvelleValeur;
                        break;  
                    case ProfilChamp.CodePostal:
                        _user.CodePostal = NouvelleValeur;
                        CodePostal = NouvelleValeur;
                        break;

                    case ProfilChamp.RegionProvince:
                        _user.RegionProvince = NouvelleValeur;
                        RegionProvince = NouvelleValeur;
                        break;

                    case ProfilChamp.Pays:
                        _user.Pays = NouvelleValeur;
                        Pays = NouvelleValeur;
                        break;

                    case ProfilChamp.NomContactUrgence:
                        _user.NomContactUrgence = NouvelleValeur;
                        NomContactUrgence = NouvelleValeur;
                        break;

                    case ProfilChamp.TelephoneContactUrgence:
                        _user.TelephoneContactUrgence = NouvelleValeur;
                        TelephoneContactUrgence = NouvelleValeur;   
                        break;

                    case ProfilChamp.LienParente:
                        _user.LienParente = NouvelleValeur;
                        LienParente = NouvelleValeur;
                        break;
                }

                _repo.ModifierUtilisateur(_user);
                
                MessageBox.Show("Profil mis à jour avec succès.");
                NouvelleValeur = string.Empty;
                OnPropertyChanged(nameof(NomComplet));
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
        CourrielPersonnel,
        Role,
        Adresse,
        Ville,
        CodePostal,
        RegionProvince,
        Pays,
        TelephoneProfessionnel,
        CourrielEntreprise,
        NomContactUrgence,
        TelephoneContactUrgence,
        LienParente
    }
}