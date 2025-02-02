using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace projet_location.Model
{
    /// <summary>
    /// Représente un bail entre un locataire et une location
    /// </summary>
    /// <author>Gibril Lakhdar</author>
    public class Bail : INotifyPropertyChanged, IBail
    {
        #region -------------- Attributs ----------------
        private string nom;
        private int idLocataire;
        private int idLocation;
        private int idProprietaire;
        private int identifiant;
        private DateTime dateSignature;
        private DateTime dateDebut;
        private string duree;
        private float loyerHC;
        private float charge;
        private string dateRevalorisation;
        private string datePayement;
        private bool apaye;
        #endregion

        #region ------------- Constructeur -----------------

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="idLocataire">Identifiant du locataire du bail</param>
        /// <param name="idLocation">Identifiant de la location du bail</param>
        /// <param name="idProprietaire">Identifiant du propriétaire du bail</param>
        /// <param name="identifiant">Identifiant du bail</param>
        /// <param name="dateSignature">Date de signature du bail</param>
        /// <param name="dateDebut">Date de début du bail</param>
        /// <param name="duree">Duree du bail</param>
        /// <param name="loyerHC">Loyer hors charge du bail</param>
        /// <param name="charge">Charges du bail</param>
        /// <param name="dateRevalorisation">Date à laquelle le loyer peut etre revaloriser</param>
        /// <param name="datePayement">Date à laquelle le loyer est payé chaque mois</param>
        /// <param name="apaye">Permet de savoir si le locataire à payé le loyer</param>
        /// <author>Hadrien Bourmault</author>
        [JsonConstructor]
        public Bail(int idLocataire,string nom,int idLocation, int idProprietaire, int identifiant, DateTime dateSignature, DateTime dateDebut, string duree, float loyerHC, float charge, string dateRevalorisation,string datePayement, bool apaye)
        {
            this.idProprietaire = idProprietaire;
            this.idLocataire = idLocataire;
            this.idLocation = idLocation;
            this.identifiant = identifiant;
            this.nom = nom;
            this.dateSignature = dateSignature;
            this.dateDebut = dateDebut;
            this.duree = duree;
            this.loyerHC = loyerHC;
            this.charge = charge;
            this.dateRevalorisation = dateRevalorisation;
            this.datePayement = datePayement;
            this.apaye = apaye;
        }

        /// <summary>
        /// Constructeur par copie
        /// </summary>
        /// <param name="bail">Bail à copier</param>
        /// <author>Hadrien Bourmault</author>
        public Bail(Bail bail)
        {
            this.identifiant = bail.identifiant;
            this.idLocataire = bail.idLocataire;
            this.idLocation = bail.idLocation;
            this.nom = bail.nom;
            this.dateSignature = bail.dateSignature;
            this.DateDebut = bail.DateDebut;
            this.duree = bail.duree;
            this.loyerHC = bail.loyerHC;
            this.charge = bail.charge;
            this.IdProprietaire = bail.idProprietaire;
            this.dateRevalorisation = bail.DateRevalorisation;
            this.datePayement = bail.datePayement;
            this.apaye = bail.apaye;
        }
        #endregion

        #region -------------- Propriété ----------------

        /// <summary>
        /// Renvoie ou modifie l'identifiant du locataire lié au bail
        /// </summary>
        public int IdLocataire
        {
            get => idLocataire;
            set => idLocataire = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant de la location lié au bail
        /// </summary>
        public int IdLocation
        {
            get => idLocation;
            set => idLocation = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du proprétaire du bail
        /// </summary>
        public int IdProprietaire
        {
            get => idProprietaire;
            set => idProprietaire = value;
        }

        /// <summary>
        /// Renvoie le nom du bail, nom aussi modifiable
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public string Nom
        {
            get => nom;
            set => nom = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du bail
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public int Identifiant
        {
            get => identifiant;
            set => identifiant = value;
        }

        /// <summary>
        /// Renvoie ou modifie la date de signature
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public DateTime DateSignature
        {
            get => dateSignature;
            set => dateSignature = value;
        }

        /// <summary>
        /// Renvoie ou modifie le la date de prise d'effet du bail
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public DateTime DateDebut
        {
            get => dateDebut;
            set => dateDebut = value;
        }

        /// <summary>
        /// Renvoie ou modifie la durée du bail
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public string Duree
        {
            get => duree;
            set => duree = value;
        }

        /// <summary>
        /// Renvoie ou modifie le loyer hors charges
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public float LoyerHC
        {
            get => loyerHC;
            set => loyerHC = value;
        }

        /// <summary>
        /// Renvoie ou modifie les charges
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public float Charge
        {
            get => charge;
            set => charge = value;
        }

        /// <summary>
        /// Renvoie ou modifie la date à laquelle le loyer peut être revalorisé
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public string DateRevalorisation
        {
            get => dateRevalorisation;
            set => dateRevalorisation = value;
        }

        /// <summary>
        /// Renvoie ou modifie la date de payement du loyer chaque mois
        /// </summary>
        public string DatePayement
        {
            get => datePayement;
            set => datePayement = value;
        }

        /// <summary>
        /// Renvoie ou modifie si le locataire à payer le loyer
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public bool Apaye
        {
            get => apaye;
            set => apaye = value;
        }
        #endregion

        #region ------------- Observation -------------
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Clone le bail
        /// </summary>
        /// <returns>Le nouveau bail crée</returns>
        /// <author>Hadrien Bourmault</author>
        public object Clone()
        {
            return new Bail(this);
        }

        #endregion
    }
}
