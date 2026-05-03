using Domaine.Context;
using Domaine.Entity;
using Domaine.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Repo
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private ScheduleFlowDBContexte _dbContext;
        public UtilisateurRepository(ScheduleFlowDBContexte contexte)
        {
            _dbContext = contexte;
        }

        public void AjouterUtilisateur(Utilisateur nouvelUtilisateur)
        {
            _dbContext.Utilisateurs.Add(nouvelUtilisateur);
            _dbContext.SaveChanges();
        }

        public void ModifierUtilisateur(Utilisateur utilisateur)
        {
            var existingUser = _dbContext.Utilisateurs
                .FirstOrDefault(u => u.IdUtilisateur == utilisateur.IdUtilisateur);

            if (existingUser == null)
                throw new Exception("Utilisateur introuvable");

            existingUser.Nom = utilisateur.Nom;
            existingUser.Prenom = utilisateur.Prenom;
            existingUser.Genre = utilisateur.Genre;
            existingUser.DateNaissance = utilisateur.DateNaissance;

            existingUser.Courriel = utilisateur.Courriel;
            existingUser.CourrielEntreprise = utilisateur.CourrielEntreprise;

            existingUser.Adresse = utilisateur.Adresse;
            existingUser.Ville = utilisateur.Ville;
            existingUser.RegionProvince = utilisateur.RegionProvince;
            existingUser.CodePostal = utilisateur.CodePostal;
            existingUser.Pays = utilisateur.Pays;

            existingUser.NumeroTelephonePersonnel = utilisateur.NumeroTelephonePersonnel;
            existingUser.NumeroTelephoneProfessionnel = utilisateur.NumeroTelephoneProfessionnel;

            existingUser.NomContactUrgence = utilisateur.NomContactUrgence;
            existingUser.TelephoneContactUrgence = utilisateur.TelephoneContactUrgence;
            existingUser.LienParente = utilisateur.LienParente;

            existingUser.Role = utilisateur.Role;

            _dbContext.SaveChanges();
        }

        public void SupprimerUtilisateur(Utilisateur utilisateur)
        {
            var existing = _dbContext.Utilisateurs
                .FirstOrDefault(u => u.Courriel == utilisateur.Courriel);

            if (existing == null)
                return;

            _dbContext.Utilisateurs.Remove(existing);
            _dbContext.SaveChanges();
        }   
    }
}
