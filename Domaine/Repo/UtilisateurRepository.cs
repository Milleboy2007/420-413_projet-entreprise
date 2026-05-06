using Domaine.Context;
using Domaine.Entity;
using Domaine.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Enum;

namespace Domaine.Repo
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private ScheduleFlowDBContexte _dbContext;
        public UtilisateurRepository(ScheduleFlowDBContexte contexte)
        {
            _dbContext = contexte;
        }


        public Utilisateur ObtenirUtilisateurParId(int id)
        {
            return _dbContext.Utilisateurs.FirstOrDefault(x => x.IdUtilisateur == id);
        }

        public void AjouterUtilisateur(Utilisateur nouvelUtilisateur)
        {
            _dbContext.Utilisateurs.Add(nouvelUtilisateur);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Utilisateur> ObtenirUtilisateurs()
        {
            return _dbContext.Utilisateurs.ToList();
        }

        public Utilisateur VerifierConnexion(string courrielEntreprise, string motDePasse)
        {
            {
                return _dbContext.Utilisateurs.FirstOrDefault(u => u.CourrielEntreprise == courrielEntreprise && u.MotDePasse == motDePasse);
            }
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
        public IEnumerable<Utilisateur> ObtenirEmploye(){
            return _dbContext.Utilisateurs.Where(u => u.Role == RoleUtilisateur.Employe);
        }

        public async Task<Utilisateur?> ObtenirParId(int id) {
            return await _dbContext.Utilisateurs.FirstOrDefaultAsync(u => u.IdUtilisateur == id);
        }
    }
}
