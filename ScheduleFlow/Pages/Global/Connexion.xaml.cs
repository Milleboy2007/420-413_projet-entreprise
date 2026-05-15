using ScheduleFlow.NavBar;
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
using static System.Collections.Specialized.BitVector32;
using Domaine.Interface;
using Domaine.Entity;
using Domaine.Repo;
using Domaine.Enum;
using Microsoft.Extensions.DependencyInjection;
using ScheduleFlow.Pages.Employee;


namespace ScheduleFlow.Pages.Global
{

    public partial class Connexion : UserControl
    {
        private readonly IUtilisateurRepository _utilisateurRepository;
        private readonly GestionnaireSession _session;
        public Connexion(IUtilisateurRepository utilisateurRepository, GestionnaireSession session)
        {
            InitializeComponent();
            _utilisateurRepository = utilisateurRepository;
            _session = session;
        }


        private void BtnConnexion_Click(object sender, RoutedEventArgs e)
        {
            string courrielEntreprise = TxtEmail.Text.Trim();
            string motDePasse = TxtPassword.Password;

            if (string.IsNullOrWhiteSpace(courrielEntreprise) || string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var utilisateur = _utilisateurRepository.VerifierConnexion(courrielEntreprise, motDePasse);

                if (utilisateur == null)
                {
                    MessageBox.Show("Identifiants invalides.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    TxtPassword.Clear();
                    return;
                }

                bool roleValide = false;

                if (RbGerant.IsChecked == true && utilisateur.Role == RoleUtilisateur.Gerant)
                    roleValide = true;
                else if (RbEmploye.IsChecked == true && utilisateur.Role == RoleUtilisateur.Employe)
                    roleValide = true;
                else if (RbEmployeur.IsChecked == true && utilisateur.Role == RoleUtilisateur.Employeur)
                    roleValide = true;

                if (!roleValide)
                {
                    MessageBox.Show("Votre rôle ne correspond pas au portail sélectionné.", "Accès refusé", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _session.IdUtilisateur = utilisateur.IdUtilisateur;
                _session.Nom = utilisateur.Nom;
                _session.Prenom = utilisateur.Prenom;
                _session.CourrielEntreprise = utilisateur.CourrielEntreprise;
                _session.Role = utilisateur.Role;
                _session.IdFeuille = utilisateur.IdFeuille;
                _session.DateConnexion = DateTime.Now;

                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

                if (utilisateur.Role == RoleUtilisateur.Gerant)
                    mainWindow.MainArea.Content = App.ServiceProvider.GetRequiredService<NavGerant>();
                else if (utilisateur.Role == RoleUtilisateur.Employe)
                    mainWindow.MainArea.Content = App.ServiceProvider.GetRequiredService<NavEmploye>();
                else if (utilisateur.Role == RoleUtilisateur.Employeur)
                    mainWindow.MainArea.Content = App.ServiceProvider.GetRequiredService<NavEmployeur>();
                MessageBox.Show($"Bienvenue, {_session.Prenom} {_session.Nom} !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                TxtEmail.Clear();
                TxtPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void BtnEmploye_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainArea.Content = App.ServiceProvider.GetRequiredService<NavEmploye>();
        }

        private void BtnGerant_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainArea.Content = new NavGerant(_session);
        }

        private void BtnEmployeur_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainArea.Content = new NavEmployeur(_session);
        }
    }
}




