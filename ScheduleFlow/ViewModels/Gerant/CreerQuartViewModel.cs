using Domaine.Entity;
using Domaine.Interface;
using Domaine.Repo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleFlow.ViewModels.Gerant
{
    public class CreerQuartViewModel : INotifyPropertyChanged
    {
        private readonly IUtilisateurRepository _userRepo;
        public ObservableCollection<string> HeuresDispo { get; set; }
        public ObservableCollection<Utilisateur> AllEmployes { get; set; }

        private string _heureDebut;
        public string HeureDebut
        {
            get => _heureDebut;
            set
            {
                _heureDebut = value;
                OnPropertyChanged();
            }
        }

        private string _heureFin;
        public string HeureFin
        {
            get => _heureFin;
            set
            {
                _heureFin = value;
                OnPropertyChanged();
            }
        }

        private Utilisateur _employeSelec;
        public Utilisateur EmployeSelec
        {
            get => _employeSelec;
            set
            {
                _employeSelec = value;
                OnPropertyChanged();
            }
        }

        public CreerQuartViewModel(IUtilisateurRepository repo)
        {
            _userRepo = repo;
            GenererHeuresDispo();
            GetEmployeDeLaDB();

            HeureDebut = "08:00";
            HeureFin = "20:00";
        }

        private void GetEmployeDeLaDB()
        {
            AllEmployes = new ObservableCollection<Utilisateur>(_userRepo.ObtenirEmploye());

            var optionPub = new Utilisateur
            {
                IdUtilisateur = -1,
                Prenom = "(Ce quart seras disponible pour tout le monde)",
                Nom = "Aucun"
            };

            AllEmployes.Insert(0, optionPub);
        }

        private void GenererHeuresDispo()
        {
            var heures = new ObservableCollection<string>();

            for (int h = 0; h < 24; h++)
            {
                heures.Add($"{h:D2}:00");
                heures.Add($"{h:D2}:30");
            }
            heures.Add("24:00");

            HeuresDispo = heures;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
