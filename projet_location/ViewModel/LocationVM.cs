using projet_location.Model;

using System.ComponentModel;
namespace projet_location.ViewModel
{
    /// <summary>
    /// Vue model d'une location
    /// </summary>
    /// <author>Julien GUYENET</author>
    public class LocationVM : ILocationVM
    {
        #region -------------- Attributs --------------
        private Location model;
        #endregion

        #region -------------- Propriétés --------------

        /// <summary>
        /// Renvoie ou modifie l'identifiant du modèle
        /// </summary>
        /// <author>Julien GUYENET</author>
        public int Id
        {
            get => this.model.Id;
            set => this.model.Id = value;
        }

        /// <summary>
        /// Renvoie ou modifie le nom du modèle
        /// </summary>
        /// <author>Julien GUYENET</author>
        public string Nom
        {
            get => this.model.Nom;
            set => this.model.Nom = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'adresse du modèle
        /// </summary>
        /// <author>Julien GUYENET</author>
        public string Adresse
        {
            get => this.model.Adresse;
            set => this.model.Adresse = value;
        }

        /// <summary>
        /// Renvoie ou modifie le complement d'adresse du modèle
        /// </summary>
        /// <author>Julien GUYENET</author>
        public string ComplementAdresse
        {
            get => this.model.ComplementAdresse;
            set => this.model.ComplementAdresse = value;
        }

        /// <summary>
        /// Renvoie ou modife le code postal du modèle
        /// </summary>
        /// <author>Julien GUYENET</author>
        public string CodePostal
        {
            get => this.model.CodePostal;
            set => this.model.CodePostal = value;
        }

        /// <summary>
        /// Renvoie ou modifie la ville du modèle
        /// </summary>
        /// <author>Julien GUYENET</author>
        public string Ville
        {
            get => this.model.Ville;
            set => this.model.Ville = value;
        }

        /// <summary>
        /// Renvoie ou modifie le pays du modèle
        /// </summary>
        /// <author>Julien GUYENET</author>
        public string Pays
        {
            get => this.model.Pays;
            set => this.model.Pays = value;
        }

        /// <summary>
        /// Informe si la location est dans immeuble ou non
        /// </summary>
        /// <author>Julien GUYENET</author>
        public int IdImmeuble
        {
            get => this.model.IdImmeuble;
            set => this.model.IdImmeuble = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du propriétaire du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int IdProprietaire
        {
            get => this.model.IdProprietaire;
            set => this.model.IdProprietaire = value;
        }

        /// <summary>
        /// Renvoie ou modifie le type d'habit du modèle
        /// </summary>
        public bool TypeHabitat
        {
            get => this.model.TypeHabitat;
            set => this.model.TypeHabitat = value;
        }

        /// <summary>
        /// Renvoie ou modifie le type de propriét" du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public bool TypePropriete
        {
            get => this.model.TypePropriete;
            set => this.model.TypePropriete = value;
        }

        /// <summary>
        /// Renvoie ou modifie la période de construction du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public string PeriodeConstruction
        {
            get => this.model.PeriodeConstruction;
            set => this.model.PeriodeConstruction = value;
        }

        /// <summary>
        /// Renvoie ou modifie la période de construction du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public float SurfaceHabitable
        {
            get => this.model.SurfaceHabitable;
            set => this.model.SurfaceHabitable = value;
        }

        /// <summary>
        /// Renvoie ou modifie le nombre de pièces principales du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int NbPiecesPrincipales
        {
            get => this.model.NbPiecesPrincipales;
            set => this.model.NbPiecesPrincipales = value;
        }

        /// <summary>
        /// Renvoie ou modifie le type de chauffage du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public bool TypeChauffage
        {
            get => this.model.TypeChauffage;
            set => this.model.TypeChauffage = value;
        }

        public bool TypeEauChaude
        {
            get => this.model.TypeEauChaude;
            set => this.model.TypeEauChaude = value;
        }

        public int NbCouchages
        {
            get => this.model.NbCouchages;
            set => this.model.NbCouchages = value;
        }

        /// <summary>
        /// Model (location)
        /// </summary>
        public ILocation Model => this.model;
        #endregion

        #region ------------- Constructeurs -------------
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="model">Location</param>
        /// <author>Julien GUYENET</author>
        public LocationVM(Location model)
        {
            this.model = model;
            this.model.PropertyChanged += Model_PropertyChanged;
        }
        #endregion

        #region ------------ Méthodes --------------
        public override string ToString()
        {
            return $"{this.model.Nom} {this.model.Adresse}";
        }
        #endregion

        #region ---------- Observation -------------
        /// <summary>
        /// Stocke le nom de la propriété qui a effectuée le changement à l'aide de la fonction notifier
        /// </summary>
        /// <author>Julien GUYENET</author>
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void Notifier(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Model_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != null) this.Notifier(e.PropertyName);
        }

        /// <summary>
        /// Clone une locationVM, elle sera semblable à la locationVM clonée
        /// </summary>
        /// <returns>Un objet location similaire à la cette locationVM</returns>
        /// <author>Julien Guyenet</author>
        public object Clone()
        {
            return new LocationVM((Location)model.Clone());
        }
        #endregion
    }
}