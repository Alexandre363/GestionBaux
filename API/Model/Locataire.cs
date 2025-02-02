namespace API.Model
{
    /// <summary>
    /// Représente un Locataire
    /// </summary>
    /// <author>Gibril Lakhdar</author>
    public class Locataire
    {
        #region Attributs
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

        #region Proprietes
        /// <summary>
        /// Renvoie ou modifie l'identifiant du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public int Id
        {
            get => id;
            set => id = value;
        }

        /// <summary>
        /// Renvoie et modifie le nom du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public string Nom
        {
            get => nom;
            set => nom = value;
        }

        /// <summary>
        /// Renvoie et modifie le prenom du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public string Prenom
        {
            get => prenom;
            set => prenom = value;
        }

        /// <summary>
        /// Renvoie ou modifie la date de naissance du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public DateTime DateDeNaissance
        {
            get { return dateDeNaissance; }
            set => dateDeNaissance = value;
        }

        /// <summary>
        /// Renvoie ou modifie la nationalité du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public string Nationalite
        {
            get { return nationalite; }
            set => nationalite = value;
        }
        /// <summary>
        /// Renvoie ou modifie le numéro de téléphone du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public string Telephone
        {
            get => telephone;
            set => telephone = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'adresse mail du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public string AdresseMail
        {
            get => adresseMail;
            set => adresseMail = value;
        }

        /// <summary>
        /// Renvoie ou modifie la situation familliale du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public string SituationFamilliale
        {
            get => situationFamilliale;
            set => situationFamilliale = value;
        }

        /// <summary>
        /// Renvoie ou modifie le nombre de personne à charge du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public int NbPersonneACharge
        {
            get => nbPersonneACharge;
            set => nbPersonneACharge = value;
        }

        /// <summary>
        /// Renvoie ou modifie le type de contrat du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public string TypeContrat
        {
            get => typeContrat;
            set => typeContrat = value;
        }

        /// <summary>
        /// Renvoie ou modifie la profession du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public string Profession
        {
            get => profession;
            set => profession = value;
        }

        /// <summary>
        /// Renvoie ou modifie le salaire du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public decimal SalaireMensuelNet
        {
            get => salaireMensuelNet;
            set => salaireMensuelNet = value;
        }

        /// <summary>
        /// Renvoie ou modifie les allocations familliale du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public decimal AllocFamilliale
        {
            get => allocFamilliale;
            set => allocFamilliale = value;
        }

        /// <summary>
        /// Renvoie ou modifie les allocations logements du locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public decimal AllocLogement
        {
            get => allocLogement;
            set => allocLogement = value;
        }

        /// <summary>
        /// Renvoie ou modifie les autres revenus que peut percevoir le locataire
        /// </summary>
        /// <author>Gibril Lakhdar</author>
        public decimal RevenusExterieur
        {
            get => revenusExterieur;
            set => revenusExterieur = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'id du propriétaire du locataire
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int IdProprietaire
        {
            get => this.idProprietaire;
            set => this.idProprietaire = value;
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="id">id du locataire</param>
        /// <param name="nom">nom du locataire</param>
        /// <param name="prenom">prenom du locataire</param>
        /// <param name="datedeNaissance">date de naissance du locataire</param>
        /// <param name="nationalite">nationalité du locataire</param>
        /// <param name="telephone">numéro de téléphone du locataire</param>
        /// <param name="adresseMail">adresse mail du locataire</param>
        /// <param name="situationFamilliale">situation familliale du locataire</param>
        /// <param name="typeContrat">type de contrat du locataire</param>
        /// <param name="nbPersonneACharge">nombre de personne à charge du locataire</param>
        /// <param name="profession">profession du locataire</param>
        /// <param name="salaireMensuelNet">salaire mensuel net du locataire</param>
        /// <param name="allocFamilliale">montant d'allocation familliale du locataire</param>
        /// <param name="allocLogement">montant d'allocation logement que perçoit le locataire</param>
        /// <param name="revenusExterieur">autres revenus que perçoit le locataire</param>
        /// <param name="idProprietaire"></param>
        /// <author>Gibril Lakhdar</author>
        public Locataire(int id, string nom, string prenom, DateTime datedeNaissance, string nationalite, string telephone, string adresseMail, string situationFamilliale, int nbPersonneACharge, string typeContrat, string profession, decimal salaireMensuelNet, decimal allocFamilliale, decimal allocLogement, decimal revenusExterieur, int idProprietaire)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.dateDeNaissance = datedeNaissance;
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
            this.idProprietaire = idProprietaire;
        }
        #endregion

        public override bool Equals(object? obj)
        {
            return obj is Locataire locataire &&
                   id == locataire.id &&
                   nom == locataire.nom &&
                   prenom == locataire.prenom &&
                   dateDeNaissance == locataire.dateDeNaissance &&
                   nationalite == locataire.nationalite &&
                   telephone == locataire.telephone &&
                   adresseMail == locataire.adresseMail &&
                   situationFamilliale == locataire.situationFamilliale &&
                   nbPersonneACharge == locataire.nbPersonneACharge &&
                   typeContrat == locataire.typeContrat &&
                   profession == locataire.profession &&
                   salaireMensuelNet == locataire.salaireMensuelNet &&
                   allocFamilliale == locataire.allocFamilliale &&
                   allocLogement == locataire.allocLogement &&
                   revenusExterieur == locataire.revenusExterieur &&
                   idProprietaire == locataire.idProprietaire;
        }
    }
}
