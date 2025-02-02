namespace API.Model
{
    /// <summary>
    /// Représente un bail entre un locataire et une location
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    public class Bail
    {
        #region -------------- Attributs ----------------
        private string nom; 
        private int identifiant;
        private int idLocataire;
        private int idLocation;

        private DateTime dateSignature;
        private DateTime dateDebut;
        private string duree;
        private float loyerHC;
        private float charge;
        private int idProprietaire;

        private string dateRevalorisation;
        private string datePayement;
        private bool apaye;
        #endregion

        #region ------------- Constructeur -----------------
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="identifiant">Identifiant du bail</param>
        /// <param name="idLocataire">Identifiant du locataire concerné par le bail</param>
        /// <param name="idLocation">Identifiant de la location concernée par le bail</param>
        /// <param name="dateSignature">Date à laquelle le bai a été signé</param>
        /// <param name="dateDebut">Date de prise d'effet du bail</param>
        /// <param name="duree">Duree d'effet du bail</param>
        /// <param name="loyerHC">Loyer hors-charges</param>
        /// <param name="charge">Charges du bail</param>
        /// <param name="idProprietaire">Identifiant du propriétaire du bail</param>
        /// <param name="dateRevalorisation">Date à laquelle le loyer peut être revalorisé</param>
        /// <param name="datePayement">Date à laquelle le loyer est payé chaque mois</param>
        /// <param name="apaye">Permet de savoir si le locataire à payé le loyer</param>
        public Bail(int identifiant,string nom, int idLocataire, int idLocation, DateTime dateSignature, DateTime dateDebut, string duree, float loyerHC, float charge, int idProprietaire, string dateRevalorisation,string datePayement,bool apaye)
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
        #endregion

        #region -------------- Propriété ---------------- 
        /// <summary>
        /// Renvoie ou modifie l'identifiant du bail
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public int Identifiant
        {
            get => identifiant;
            set => identifiant = value;
        }

        /// <summary>
        /// Renvoie ou modifie la date de signature du bail
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public DateTime DateSignature
        {
            get => dateSignature;
            set => dateSignature = value;
        }

        /// <summary>
        /// Renvoie ou modifie la date de prise d'effet du bail
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public DateTime DateDebut
        {
            get => dateDebut;
            set => dateDebut = value;
        }

        /// <summary>
        /// Renvoie ou modifie la durée du bail
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public string Duree
        {
            get => duree;
            set => duree = value;
        }

        /// <summary>
        /// Renvoie ou modifie le loyer hors-charges du bail
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public float LoyerHC
        {
            get => loyerHC;
            set => loyerHC = value;
        }

        /// <summary>
        /// Renvoie ou modifie les charges du bail
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public float Charge
        {
            get => charge;
            set => charge = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du locataire lié au bail
        /// </summary>
        public int IdLocataire
        {
            get => idLocataire;
            set => idLocataire = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant de la location liée au bail
        /// </summary>
        public int IdLocation
        {
            get => idLocation;
            set => idLocation = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du propriétaire du bail
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
        /// Renvoie ou modifie la date à laquelle le loyer du bail peut être revalorisée
        /// </summary>
        public string DateRevalorisation
        {
            get => dateRevalorisation;
            set => dateRevalorisation = value;
        }

        /// <summary>
        /// Renvoie ou modifie la date à laquelle le loyer est payé tous les mois
        /// </summary>
        public string DatePayement
        {
            get => datePayement;
            set => datePayement = value;
        }

        /// <summary>
        /// Renvoie ou modifie si le locataire à payer le loyer
        /// </summary>
        public bool Apaye
        {
            get => apaye;
            set => apaye = value;
        }

        /// <summary>
        /// Permet de savoir si 2 baux sont égaux
        /// </summary>
        /// <param name="obj">Bail à comparer</param>
        /// <returns>True s'ils sont égaux et false sinon</returns>
        public override bool Equals(object? obj)
        {
            return obj is Bail bail &&
                   identifiant == bail.identifiant &&
                   idLocataire == bail.idLocataire &&
                   idLocation == bail.idLocation &&
                   nom == bail.nom &&
                   dateSignature == bail.dateSignature &&
                   dateDebut == bail.dateDebut &&
                   duree == bail.duree &&
                   loyerHC == bail.loyerHC &&
                   charge == bail.charge &&
                   idProprietaire == bail.idProprietaire &&
                   dateRevalorisation == bail.dateRevalorisation &&
                   datePayement == bail.datePayement &&
                   apaye == bail.apaye;
        }
        #endregion
    }
}
