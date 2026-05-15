using Domaine.Entity;
using Domaine.Interface;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace ScheduleFlow.ViewModels.Gerant
{
    public class CreerQuartViewModel : INotifyPropertyChanged
    {
        private readonly IUtilisateurRepository _userRepo;
        private readonly IQuartRepository _quartRepo;
        public ObservableCollection<TimeOnly> HeuresDispo { get; set; }
        public ObservableCollection<Utilisateur> AllEmployes { get; set; }

        private TimeOnly _heureDebut;
        public TimeOnly HeureDebut
        {
            get => _heureDebut;
            set
            {
                _heureDebut = value;
                OnPropertyChanged();
            }
        }

        private TimeOnly _heureFin;
        public TimeOnly HeureFin
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

        public CreerQuartViewModel(IUtilisateurRepository userRepo, IQuartRepository quartRepo)
        {
            _userRepo = userRepo;
            _quartRepo = quartRepo;
            GenererHeuresDispo();
            GetEmployeDeLaDB();

            HeureDebut = new TimeOnly(8, 0);
            HeureFin = new TimeOnly(20, 0);
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
            _employeSelec = optionPub;
        }

        private void GenererHeuresDispo()
        {
            var heures = new ObservableCollection<TimeOnly>();

            for (int h = 0; h < 24; h++)
            {
                heures.Add(new TimeOnly(h,0));
                heures.Add(new TimeOnly(h, 30));
            }
            heures.Add(new TimeOnly(0, 0));

            HeuresDispo = heures;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void CreerQuart(DateOnly date, TimeOnly heurDebut, TimeOnly heureFin, string poste, Utilisateur? assignation, string description)
        {
            Quart nouveauQuart = new Quart
            {
                Date = date,
                Heures = [heurDebut, heureFin],
                Poste = poste,
                UserId = assignation?.IdUtilisateur == -1? null: assignation?.IdUtilisateur,
                Description = description,
                IsPub = assignation?.IdUtilisateur == -1
            };

            await _quartRepo.CreateQuartAsync(nouveauQuart);
        }
    }
}
