using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domaine.Interface;
using Domaine.Entity;
using System.Windows;

namespace ScheduleFlow.Pages.Gerant
{
    public partial class CreationCompteParGerantViewModel : ObservableObject
    {
        private readonly IUtilisateurRepository _utilisateurRepository;

        [ObservableProperty]
        private string idUtilisateur = string.Empty;

        [ObservableProperty]
        private string nom = string.Empty;

        [ObservableProperty]
        private string prenom = string.Empty;

        [ObservableProperty]
        private string courriel = string.Empty;

        [ObservableProperty]
        private string courrielEntreprise = string.Empty;

        [ObservableProperty]
        private string genre = string.Empty;

        [ObservableProperty]
        private string dateNaissance = string.Empty;

        [ObservableProperty]
        private string adresse = string.Empty;

        [ObservableProperty]
        private string ville = string.Empty;

        [ObservableProperty]
        private string regionProvince = string.Empty;

        [ObservableProperty]
        private string codePostal = string.Empty;

        [ObservableProperty]
        private string pays = string.Empty;

        [ObservableProperty]
        private string numeroTelephonePersonnel = string.Empty;

        [ObservableProperty]
        private string numeroTelephoneProfessionnel = string.Empty;

        [ObservableProperty]
        private string motDePasse = string.Empty;

        [ObservableProperty]
        private string nomContactUrgence = string.Empty;

        [ObservableProperty]
        private string telephoneContactUrgence = string.Empty;

        [ObservableProperty]
        private string lienParente = string.Empty;

        public CreationCompteParGerantViewModel(IUtilisateurRepository usrRepo)
        {
            _utilisateurRepository = usrRepo;
        }

        [RelayCommand]
        public void AjouterUtilisateur()
        {
            if (string.IsNullOrWhiteSpace(Nom) ||
                string.IsNullOrWhiteSpace(Prenom) ||
                string.IsNullOrWhiteSpace(Courriel) ||
                string.IsNullOrWhiteSpace(MotDePasse))
            {
                MessageBox.Show("Les champs obligatoires (Nom, Prénom, Email, Mot de passe) sont requis.",
                    "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var nouvelUtilisateur = new Utilisateur
            {
                Nom = Nom.Trim(),
                Prenom = Prenom.Trim(),
                Courriel = Courriel.Trim(),
                CourrielEntreprise = CourrielEntreprise.Trim(),
                Genre = Genre.Trim(),
                DateNaissance = DateNaissance.Trim(),
                Adresse = Adresse.Trim(),
                Ville = Ville.Trim(),
                RegionProvince = RegionProvince.Trim(),
                CodePostal = CodePostal.Trim(),
                Pays = Pays.Trim(),
                NumeroTelephonePersonnel = NumeroTelephonePersonnel.Trim(),
                NumeroTelephoneProfessionnel = NumeroTelephoneProfessionnel.Trim(),
                MotDePasse = MotDePasse.Trim(),
                NomContactUrgence = NomContactUrgence.Trim(),
                TelephoneContactUrgence = TelephoneContactUrgence.Trim(),
                LienParente = LienParente.Trim(),
                Role = RoleUtilisateur.Employe
            };

            _utilisateurRepository.AjouterUtilisateur(nouvelUtilisateur);

            MessageBox.Show($"Employé {Prenom} {Nom} créé avec succès.", 
                "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

            ReinitialiserFormulaire();
        }

        private void ReinitialiserFormulaire()
        {
            IdUtilisateur = string.Empty;
            Nom = string.Empty;
            Prenom = string.Empty;
            Courriel = string.Empty;
            CourrielEntreprise = string.Empty;
            Genre = string.Empty;
            DateNaissance = string.Empty;
            Adresse = string.Empty;
            Ville = string.Empty;
            RegionProvince = string.Empty;
            CodePostal = string.Empty;
            Pays = string.Empty;
            NumeroTelephonePersonnel = string.Empty;
            NumeroTelephoneProfessionnel = string.Empty;
            MotDePasse = string.Empty;
            NomContactUrgence = string.Empty;
            TelephoneContactUrgence = string.Empty;
            LienParente = string.Empty;
        }
    }
}