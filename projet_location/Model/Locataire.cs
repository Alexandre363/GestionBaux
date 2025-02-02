using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace projet_location.Model
{
    public class Locataire : INotifyPropertyChanged, ILocataire
    {
        #region -------------- Attributs --------------
        private int id;
        private string nom;
        private string prenom;
        private DateTime dateDeNaissance;
        private string nationalite;
        private string telephone;
        private string adresseMail;
        private string situationFamilliale;
        private int nbPersonneACharge;
        private string typeContrat;
        private string profession;
        private decimal salaireMensuelNet;
        private decimal allocFamilliale;
        private decimal allocLogement;
        private decimal revenusExterieur;
        private int idProprietaire;
        #endregion

        #region -------------- Propriétés --------------
        /// <summary>
        /// Renvoie ou modifie l'identifiant
        /// </summary>
        /// <author>GUYENET Julien</author>        
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Renvoie ou modifie le nom
        /// </summary>
        /// <author>GUYENET Julien</author>        
        public string Nom { get => nom; set => nom = value; }

        /// <summary>
        /// Renvoie ou modifie le prénom
        /// </summary>
        /// <author>GUYENET Julien</author>        
        public string Prenom { get => prenom; set => prenom = value; }

        /// <summary>
        /// Renvoi ou modifie la date de naissance
        /// </summary>
        /// <author>GUYENET Julien</author>        
        public DateTime DateDeNaissance { get => dateDeNaissance; set => dateDeNaissance = value; }

        /// <summary>
        /// Renvoie ou modifie la nationalité
        /// </summary>
        /// <author>GUYENET Julien</author>
        public string Nationalite { get => nationalite; set => nationalite = value; }

        /// <summary>
        /// Renvoie ou modifie le téléphone
        /// </summary>
        /// <author>GUYENET Julien</author>
        public string Telephone { get => telephone; set => telephone = value; }

        /// <summary>
        /// Renvoie ou modife l'adresse mail
        /// </summary>
        /// <author>GUYENET Julien</author>
        public string AdresseMail { get => adresseMail; set => adresseMail = value; }

        /// <summary>
        /// Renvoie ou modifie la situation familiale
        /// </summary>
        /// <author>GUYENET Julien</author>
        public string SituationFamilliale { get => situationFamilliale; set => situationFamilliale = value; }

        /// <summary>
        /// Renvoie ou modifie le nombre de personne à charges
        /// </summary>
        /// <author>GUYENET Julien</author>
        public int NbPersonneACharge { get => nbPersonneACharge; set => nbPersonneACharge = value; }

        /// <summary>
        /// Renvoie ou modifie le type de contrat
        /// </summary>
        /// <author>GUYENET Julien</author>
        public string TypeContrat { get => typeContrat; set => typeContrat = value; }

        /// <summary>
        /// Renvoie ou modifie la profession
        /// </summary>
        /// <author>GUYENET Julien</author>
        public string Profession { get => profession; set => profession = value; }

        /// <summary>
        /// Renvoie ou modifie le salare mensuel net
        /// </summary>
        /// <author>GUYENET Julien</author>
        public decimal SalaireMensuelNet { get => salaireMensuelNet; set => salaireMensuelNet = value; }

        /// <summary>
        /// Renvoie ou modifie les allocations familiales
        /// </summary>
        /// <author>GUYENET Julien</author>
        public decimal AllocFamilliale { get => allocFamilliale; set => allocFamilliale = value; }

        /// <summary>
        /// Renvoie ou modifie les allocations logements
        /// </summary>
        /// <author>GUYENET Julien</author>
        public decimal AllocLogement { get => allocLogement; set => allocLogement = value; }

        /// <summary>
        /// Renvoie ou modifie les revenus extérieurs
        /// </summary>
        /// <author>GUYENET Julien</author>
        public decimal RevenusExterieur { get => revenusExterieur; set => revenusExterieur = value; }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du propriétaire
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int IdProprietaire
        {
            get => idProprietaire;
            set => idProprietaire = value;
        }

        #endregion

        #region -------------- Constructeurs --------------
        /// <summary>
        /// Constructeur de la classe Locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        [JsonConstructor]
        public Locataire(int id, string nom, string prenom, DateTime dateDeNaissance, string nationalite, string telephone, string adresseMail, string situationFamilliale, int nbPersonneACharge, string typeContrat, string profession, decimal salaireMensuelNet, decimal allocFamilliale, decimal allocLogement, decimal revenusExterieur, int idProprietaire)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.dateDeNaissance = dateDeNaissance;
            this.nationalite = nationalite;
            this.telephone = telephone;
            this.adresseMail = adresseMail;
            this.situationFamilliale = situationFamilliale;
            this.nbPersonneACharge = nbPersonneACharge;
            this.typeContrat = typeContrat;
            this.profession = profession;
            this.salaireMensuelNet = salaireMensuelNet;
            this.allocFamilliale = allocFamilliale;
            this.allocLogement = allocLogement;
            this.revenusExterieur = revenusExterieur;
            this.IdProprietaire = idProprietaire;
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        /// <param name="locataire">objet locataire à copier</param>
        /// <author>Lakhdar Gibril</author>
        public Locataire(Locataire locataire)
        {
            this.id = locataire.id;
            this.nom = locataire.nom;
            this.prenom = locataire.prenom;
            this.dateDeNaissance = locataire.dateDeNaissance;
            this.nationalite = locataire.nationalite;
            this.telephone = locataire.telephone;
            this.adresseMail = locataire.adresseMail;
            this.situationFamilliale = locataire.situationFamilliale;
            this.nbPersonneACharge = locataire.nbPersonneACharge;
            this.typeContrat = locataire.typeContrat;
            this.profession = locataire.profession;
            this.salaireMensuelNet = locataire.salaireMensuelNet;
            this.allocFamilliale = locataire.allocFamilliale;
            this.allocLogement = locataire.allocLogement;
            this.revenusExterieur = locataire.revenusExterieur;
            this.IdProprietaire = locataire.idProprietaire;
        }
        #endregion

        #region ---------- Observation -------------
        public event PropertyChangedEventHandler? PropertyChanged;

        public object Clone()
        {
            return new Locataire(this);
        }
        #endregion
    }
}
