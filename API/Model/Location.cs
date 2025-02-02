namespace API.Model
{

    /// <summary>
    /// Constructeur de la classe Location
    /// </summary>
    public class Location : ILocation
    {
        #region Attributs
        private int id;
        private string nom;

        private string adresse;
        private string complementAdresse;
        private string codePostal;
        private string ville;
        private string pays;

        private int idImmeuble;
        private int idProprietaire;

        private bool typeHabitat;
        private bool typePropriete;
        private string periodeConstruction;

        private float surfaceHabitable;
        private int nbPiecesPrincipales;

        private bool typeChauffage;
        private bool typeEauChaude;
        private int nbCouchages;
        #endregion

        #region Proprietes
        /// <summary>
        /// Renvoie ou modifie l'identifiant de la location
        /// </summary>
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }

        /// <summary>
        /// Renvoie ou modifie le nom de la location
        /// </summary>
        public string Nom
        {
            get => this.nom;
            set => this.nom = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'adresse de la location
        /// </summary>
        public string Adresse
        {
            get => this.adresse;
            set => this.adresse = value;
        }

        /// <summary>
        /// Renvoie ou modifie le complément d'adresse de la location
        /// </summary>
        public string ComplementAdresse
        {
            get => this.complementAdresse;
            set => this.complementAdresse = value;
        }

        /// <summary>
        /// Renvoie ou modifie le code postal de la location
        /// </summary>
        public string CodePostal
        {
            get => this.codePostal;
            set => this.codePostal = value;
        }

        /// <summary>
        /// Renvoie ou modifie la ville de la location
        /// </summary>
        public string Ville
        {
            get => this.ville;
            set => this.ville = value;
        }

        /// <summary>
        /// Renvoie ou modifie le pays de la location
        /// </summary>
        public string Pays
        {
            get => this.pays;
            set => this.pays = value;
        }

        /// <summary>
        /// Renvoie ou modife l'identifant de l'immeuble de la location
        /// </summary>
        public int IdImmeuble
        {
            get => this.idImmeuble;
            set => this.idImmeuble = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du propriétaire de la location
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int IdProprietaire
        {
            get => this.idProprietaire;
            set => this.idProprietaire = value;
        }

        /// <summary>
        /// Renvoie ou modifie le type d'habitat de la location (individuel ou collectif)
        /// </summary>
        public bool TypeHabitat
        {
            get => this.typeHabitat;
            set => this.typeHabitat = value;
        }

        /// <summary>
        /// Renvoie ou modifie le type de propriété de la location (monopropriété ou copropriété)
        /// </summary>
        public bool TypePropriete
        {
            get => this.typePropriete;
            set => this.typePropriete = value;
        }

        /// <summary>
        /// Renvoie ou modifie la période de construction de la location
        /// </summary>
        public string PeriodeConstruction
        {
            get => this.periodeConstruction;
            set => this.periodeConstruction = value;
        }

        /// <summary>
        /// Renvoie ou modifie la surfice habitable de la location
        /// </summary>
        public float SurfaceHabitable
        {
            get => this.surfaceHabitable;
            set => this.surfaceHabitable = value;
        }

        /// <summary>
        /// Renvoie ou modifie le nombre de pièces habitables dans la location
        /// </summary>
        public int NbPiecesPrincipales
        {
            get => this.nbPiecesPrincipales;
            set => this.nbPiecesPrincipales = value;
        }

        /// <summary>
        /// Renvoie ou modifie le type de chauffage de la location (individuel ou collectif)
        /// </summary>
        public bool TypeChauffage
        {
            get => this.typeChauffage;
            set => this.typeChauffage = value;
        }

        /// <summary>
        /// Renvoie ou modifie le type d'eau chaude de la location (individuelle ou collective)
        /// </summary>
        public bool TypeEauChaude
        {
            get => this.typeEauChaude;
            set => this.typeEauChaude = value;
        }

        /// <summary>
        /// Renvoie ou modifie le nombre de couchages dans la location
        /// </summary>
        public int NbCouchages
        {
            get => this.nbCouchages;
            set => this.nbCouchages = value;
        }
        #endregion

        #region Constructeur 
        /// <summary>
        /// Constructeur de la classe Location
        /// </summary>
        /// <param name="nom">nom de la location</param>
        /// <param name="adresse">adresse de la location</param>
        /// <param name="complementAdresse"></param>
        /// <param name="codePostal">code postal de la location</param>
        /// <param name="ville">ville de la location</param>
        /// <param name="pays">pays de la location</param>
        /// <param name="idImmeuble">si il est dans un immeuble ou non</param>
        /// <param name="idProprietaire">l'id du proprietaire de la location</param>
        /// <param name="typeHabitat">le type d'habitat</param>
        /// <param name="typePropriete">le type de propriete</param>
        /// <param name="periodeConstruction">la periode de construction</param>
        /// <param name="surfaceHabitable">la surface habitable</param>
        /// <param name="nbPiecePrincipales">le nombre de piece principale</param>
        /// <param name="typeChauffage">le type de chauffage</param>
        /// <param name="typeEauChaude">le type d'eau chaude</param>
        /// <param name="nbCouchages">le nombre de couchage</param>
        public Location(int id, string nom, string adresse, string complementAdresse, string codePostal, string ville, string pays, int idImmeuble, int idProprietaire, bool typeHabitat, bool typePropriete, string periodeConstruction, float surfaceHabitable, int nbPiecesPrincipales, bool typeChauffage, bool typeEauChaude, int nbCouchages)
        {
            this.id = id;
            this.nom = nom;

            this.adresse = adresse;
            this.complementAdresse = complementAdresse;
            this.codePostal = codePostal;
            this.ville = ville;
            this.pays = pays;

            this.idImmeuble = idImmeuble;
            this.idProprietaire = idProprietaire;

            this.typeHabitat = typeHabitat;
            this.typePropriete = typePropriete;
            this.periodeConstruction = periodeConstruction;
            this.surfaceHabitable = surfaceHabitable;
            this.nbPiecesPrincipales = nbPiecesPrincipales;

            this.typeChauffage = typeChauffage;
            this.typeEauChaude = typeEauChaude;
            this.nbCouchages = nbCouchages;
        }
        #endregion

        /// <summary>
        /// Permet de savoir si deux locations sont égales
        /// </summary>
        /// <param name="obj">Location à comparer</param>
        /// <returns>True si elles sont égales, false sinon</returns>
        public override bool Equals(object? obj)
        {
            return obj is Location location &&
                   id == location.id &&
                   nom == location.nom &&
                   adresse == location.adresse &&
                   complementAdresse == location.complementAdresse &&
                   codePostal == location.codePostal &&
                   ville == location.ville &&
                   pays == location.pays &&
                   idImmeuble == location.idImmeuble &&
                   idProprietaire == location.idProprietaire &&
                   typeHabitat == location.typeHabitat &&
                   typePropriete == location.typePropriete &&
                   periodeConstruction == location.periodeConstruction &&
                   surfaceHabitable == location.surfaceHabitable &&
                   nbPiecesPrincipales == location.nbPiecesPrincipales &&
                   typeChauffage == location.typeChauffage &&
                   typeEauChaude == location.typeEauChaude &&
                   nbCouchages == location.nbCouchages;
        }
    }
}
