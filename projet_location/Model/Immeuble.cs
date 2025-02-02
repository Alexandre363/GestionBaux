using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace projet_location.Model
{
    /// <summary>
    /// Constructeur de la classe Immeuble
    /// </summary>
    /// <author>Julien Guyenet</author>
    public class Immeuble : INotifyPropertyChanged, ILocation
    {

        #region -------------- Attributs --------------
        private int id;
        private string nom;
        private string adresse;
        private string complementAdresse;
        private string codePostal;
        private string ville;
        private string pays;
        private int idProprietaire;
        private List<Location> listeDesAppartements;
        #endregion

        #region -------------- Propriétés --------------
        /// <summary>
        /// Renvoie ou modifie l'identifiant
        /// </summary>
        /// <author>Julien Guyenet</author>
        public int Id
        {
            get => this.id;
            set { this.id = value; this.Notifier("Id"); }
        }

        /// <summary>
        /// Renvoie ou modifie le nom
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Nom
        {
            get => this.nom;
            set { this.nom = value; this.Notifier("Nom"); }
        }

        /// <summary>
        /// Renvoie ou modifie
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Adresse
        {
            get => this.adresse;
            set { this.adresse = value; this.Notifier("Adresse"); }
        }

        /// <summary>
        /// Renvoie ou modifie le compélement d'adresse
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string ComplementAdresse
        {
            get => this.complementAdresse;
            set { this.complementAdresse = value; this.Notifier("ComplementAdresse"); }
        }

        /// <summary>
        /// Renvoie ou modifie le code postal
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string CodePostal
        {
            get => this.codePostal;
            set { this.codePostal = value; this.Notifier("CodePostal"); }
        }

        /// <summary>
        /// Renvoie ou modifie la ville
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Ville
        {
            get => this.ville;
            set { this.ville = value; this.Notifier("Ville"); }
        }

        /// <summary>
        /// Renvoie ou modifie le pays
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Pays
        {
            get => this.pays;
            set { this.pays = value; this.Notifier("Pays"); }
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du propriétaire
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int IdProprietaire
        {
            get => this.idProprietaire;
            set { this.idProprietaire = value; this.Notifier("IdProprietaire"); }
        }

        /// <summary>
        /// Renvoie la liste des appartements
        /// </summary>
        public List<Location> ListeDesAppartements => listeDesAppartements;
        #endregion

        #region -------------- Constructeurs --------------
        [JsonConstructor]
        /// <summary>
        /// Constructeur de la classe Immeuble
        /// </summary>
        /// <param name="nom">nom de la Immeuble</param>
        /// <param name="adresse">adresse de la Immeuble</param>
        /// <param name="complementAdresse"></param>
        /// <param name="codePostal">code postal de la Immeuble</param>
        /// <param name="ville">ville de la Immeuble</param>
        /// <param name="pays">pays de la Immeuble</param>
        /// <param name="idProprietaire">Id du proprietaire de la Immeuble</param>
        /// <author>Julien Guyenet</author>
        public Immeuble(int id, string nom, string adresse, string complementAdresse, string codePostal, string ville, string pays, int idProprietaire)
        {
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
            this.complementAdresse = complementAdresse;
            this.codePostal = codePostal;
            this.ville = ville;
            this.pays = pays;
            this.idProprietaire = idProprietaire;
            this.listeDesAppartements = new List<Location>();
        }

        /// <summary>
        /// Constructeur par copie de la classe locaiton
        /// </summary>
        /// <param name="Immeuble">Immeuble a copier</param>
        /// <author>Julien Guyenet</author>
        public Immeuble(Immeuble Immeuble)
        {
            this.id = Immeuble.Id;
            this.nom = Immeuble.Nom;
            this.adresse = Immeuble.Adresse;
            this.complementAdresse = Immeuble.ComplementAdresse;
            this.codePostal = Immeuble.CodePostal;
            this.ville = Immeuble.Ville;
            this.pays = Immeuble.Pays;
            this.IdProprietaire = Immeuble.IdProprietaire;
            this.listeDesAppartements = Immeuble.listeDesAppartements;
        }

        #endregion

        #region -------------- Méthodes --------------

        /// <summary>
        /// Permet d'actualiser la liste des appartements
        /// </summary>
        /// <param name="liste">liste des location a actualiser</param>
        public void DefinirListeAppartements(IEnumerable<Location> liste)
        {
            this.listeDesAppartements.Clear();
            foreach (Location location in liste)
            {
                this.listeDesAppartements.Add(location);
            }
            this.Notifier("ListeDesAppartements");
        }

        /// <summary>
        /// Permet de cloner un Immeuble, il sera semblable à l'immeuble clonée
        /// </summary>
        /// <returns>Un objet Immeuble similaire à cet Immeuble</returns>
        /// <author>Julien Guyenet</author>
        public object Clone()
        {
            return new Immeuble(this);
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

    }
}
