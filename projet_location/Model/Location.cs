using System.ComponentModel;
using System.Text.Json.Serialization;

namespace projet_location.Model
{
    /// <summary>
    /// Constructeur de la classe Location
    /// </summary>
    /// <author>Julien Guyenet</author>
    public class Location : INotifyPropertyChanged, ILocation
    {

        #region -------------- Attributs --------------
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

        #region -------------- Propriétés --------------
        /// <summary>
        /// Renvoie ou modifie l'identifiant de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public int Id
        {
            get => this.id;
            set { this.id = value; this.Notifier("Id"); }
        }

        /// <summary>
        /// Renvoie ou modifie le nom de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Nom
        {
            get => this.nom;
            set { this.nom = value; this.Notifier("Nom"); }
        }

        /// <summary>
        /// Renvoie ou modifie l'adresse de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Adresse
        {
            get => this.adresse;
            set { this.adresse = value; this.Notifier("Adresse"); }
        }

        /// <summary>
        /// Renvoie ou modifie le complément d'adresse de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string ComplementAdresse
        {
            get => this.complementAdresse;
            set { this.complementAdresse = value; this.Notifier("ComplementAdresse"); }
        }

        /// <summary>
        /// Renvoie ou modifie le code postal de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string CodePostal
        {
            get => this.codePostal;
            set { this.codePostal = value; this.Notifier("CodePostal"); }
        }

        /// <summary>
        /// Renvoie ou modifie la ville où se situe la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Ville
        {
            get => this.ville;
            set { this.ville = value; this.Notifier("Ville"); }
        }

        /// <summary>
        /// Renvoie ou modifie le pays où se situe la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Pays
        {
            get => this.pays;
            set { this.pays = value; this.Notifier("Pays"); }
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant de l'immeuble
        /// </summary>
        /// <author>Julien Guyenet</author>
        public int IdImmeuble
        {
            get => this.idImmeuble;
            set { this.idImmeuble = value; this.Notifier("IdImmeuble"); }
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du propriétaire de la location
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int IdProprietaire
        {
            get => this.idProprietaire;
            set { this.idProprietaire = value; this.Notifier("IdProprietaire"); }
        }

        /// <summary>
        /// Renvoie ou modifie le type d'habitat de la location
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public bool TypeHabitat
        {
            get => this.typeHabitat;
            set { 
                this.typeHabitat = value;
                this.Notifier("TypeHabitat");
            }
        }

        /// <summary>
        /// Renvoie ou modifie le type de propriété de la location
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public bool TypePropriete
        {
            get => this.typePropriete;
            set { 
                this.typePropriete = value;
                this.Notifier("TypePropriete");
            }
        }

        /// <summary>
        /// Renvoie ou modifie la période de construction de la location
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public string PeriodeConstruction
        {
            get => this.periodeConstruction;
            set
            {
                this.periodeConstruction = value;
                this.Notifier("PeriodeConstruction");
            }
        }

        /// <summary>
        /// Renvoie ou modifie la surface habitable de la location
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public float SurfaceHabitable
        {
            get => this.surfaceHabitable;
            set { 
                this.surfaceHabitable = value;
                this.Notifier("SurfaceHabitable");
            }
        }

        /// <summary>
        /// Renvoie ou modifie le nombre de pièces principales de la location
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public int NbPiecesPrincipales
        {
            get => this.nbPiecesPrincipales;
            set
            {
                this.nbPiecesPrincipales = value;
                this.Notifier("NbPiecesPrincipales");
            }
        }

        /// <summary>
        /// Renvoie ou modifie le type de chauffage de la location
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public bool TypeChauffage
        {
            get => this.typeChauffage;
            set { 
                this.typeChauffage = value;
                this.Notifier("TypeChauffage");
            }
        }

        /// <summary>
        /// Renvoie ou modifie le type d'eau chaude de la location
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public bool TypeEauChaude
        {
            get => this.typeEauChaude;
            set 
            { 
                this.typeEauChaude = value;
                this.Notifier("TypeEauChaude");
            }
        }

        /// <summary>
        /// Renvoie ou modifie le nombre de couchages de la location
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int NbCouchages
        {
            get => this.nbCouchages;
            set
            {
                this.nbCouchages = value;
                this.Notifier("NbCouchages");
            }
        }
        #endregion

        #region -------------- Constructeurs --------------
        [JsonConstructor]
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
        /// <param name="nbCouchages">Le nombre couchages dans la location</param>
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

        /// <summary>
        /// Constructeur par copie de la classe locaiton
        /// </summary>
        /// <param name="location">location a copier</param>
        /// <author>Julien Guyenet</author>
        public Location(Location location)
        {
            this.id = location.Id;
            this.nom = location.Nom;
            this.adresse = location.Adresse;
            this.complementAdresse = location.ComplementAdresse;
            this.codePostal = location.CodePostal;
            this.ville = location.Ville;
            this.pays = location.Pays;
            this.idImmeuble = location.IdImmeuble;
            this.IdProprietaire = location.IdProprietaire;
            this.typeHabitat = location.TypeHabitat;
            this.typePropriete = location.TypePropriete;
            this.periodeConstruction = location.PeriodeConstruction;
            this.surfaceHabitable = location.SurfaceHabitable;
            this.nbPiecesPrincipales = location.NbPiecesPrincipales;
            this.typeChauffage = location.TypeChauffage;
            this.typeEauChaude = location.TypeEauChaude;
            this.nbCouchages = location.NbCouchages;
        }

        #endregion

        #region ---------- Observation -------------
        /// <summary>
        /// Stocke le nom de la propriété qui a effectuée le changement à l'aide de la fonction notifier
        /// </summary>
        /// <author>Julien Guyenet</author>
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void Notifier(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        /// <summary>
        /// Clone une location, elle sera semblable à la location clonée
        /// </summary>
        /// <returns>Un objet location similaire à la cette location</returns>
        /// <author>Julien Guyenet</author>
        public object Clone()
        {
            return new Location(this);
        }
    }
}
