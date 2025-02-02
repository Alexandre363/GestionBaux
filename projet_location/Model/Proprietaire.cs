using System.ComponentModel;
using System.Text.Json.Serialization;

namespace projet_location.Model
{
    public class Proprietaire : INotifyPropertyChanged, IProprietaire
    {
        #region Attributs

        private int id;
        private string motDePasse;
        private string nom;
        private string mail;
        private bool typePersonne;
        private string adresse;

        #endregion

        #region ---------- Propriétés ----------

        /// <summary>
        /// Renvoie ou modifie l'identifiant
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Renvoie ou modifie le mot de passe
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public string MotDePasse
        {
            get { return motDePasse; }
            set { motDePasse = value; }
        }

        /// <summary>
        /// Renvoie ou modifie le nom
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        /// <summary>
        /// Renvoie ou modifie le mail
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        /// <summary>
        /// Renvoie ou modiife le type de personne (physique ou morale)
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public bool TypePersonne
        {
            get => typePersonne;
            set => typePersonne = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'adresse
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public string Adresse
        {
            get => adresse;
            set => adresse = value;
        }

        #endregion

        #region ---------- Constructor ----------
        [JsonConstructor]
        /// <summary>
        /// Constructeur du proprietaire
        /// </summary>
        /// <param name="id">identifiant de l'utilisatur</param>
        /// <param name="motDePasse">le mot de passe du proprietaire</param>
        /// <param name="nom">le nom du proprietaire</param>
        /// <param name="mail">l'adresse mail du proprietaire</param>
        /// <param name="typePersonne">genre de la personne</param>
        /// <param name="adresse">Adresse du proprietaire</param>
        /// <author>Julien Guyenet</author>
        public Proprietaire(int id, string motDePasse, string nom, string mail, bool typePersonne, string adresse)
        {
            this.id = id;
            this.motDePasse = motDePasse;
            this.nom = nom;
            this.mail = mail;
            this.typePersonne = typePersonne;
            this.adresse = adresse;
        }

        /// <summary>
        /// Constructeur par copie du proprietaire
        /// </summary>
        /// <param name="proprietaire">proprietaire a copier</param>
        public Proprietaire(Proprietaire proprietaire)
        {
            this.id = proprietaire.id;
            this.nom = proprietaire.nom;
            this.motDePasse = proprietaire.motDePasse;
            this.mail = proprietaire.mail;
            this.typePersonne = proprietaire.TypePersonne;
            this.adresse = proprietaire.Adresse;
        }

        #endregion

        #region ---------- Methodes ----------
        /// <summary>
        /// Permet de cloner ce propriétaire dans un nouveau
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Proprietaire(this);
        }

        public override bool Equals(object? obj)
        {
            return obj is Proprietaire proprietaire &&
                   id == proprietaire.id &&
                   motDePasse == proprietaire.motDePasse &&
                   nom == proprietaire.nom &&
                   mail == proprietaire.mail &&
                   typePersonne == proprietaire.typePersonne &&
                   adresse == proprietaire.Adresse;
        }


        #endregion

        #region ---------- Observation -------------
        /// <summary>
        /// Stocke le nom de la propriété qui a effectuée le changement à l'aide de la fonction notifier
        /// </summary>
        /// <author>Julien Guyenet</author>
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion
    }
}

