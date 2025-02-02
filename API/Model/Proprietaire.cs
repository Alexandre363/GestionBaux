namespace API.Model
{

    /// <summary>
    /// Représente un propriétaire
    /// </summary>
    /// <author>Julien Guyenet</author>
    public class Proprietaire
    {
        #region -------------- Attributs --------------
        private int id;
        private string motDePasse;
        private string nom;
        private string mail;

        private bool typePersonne;
        private string adresse;
        #endregion

        #region -------------- Propriétés --------------
        /// <summary>
        /// Renvoie ou modifie l'identifiant du propriéaire
        /// </summary>
        /// <author>Julien Guyenet</author>
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }

        /// <summary>
        /// Renvoie ou modifie l nom du propriétaire
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Nom
        {
            get => this.nom;
            set => this.nom = value;
        }

        /// <summary>
        /// Renvoie ou modifie le mot de passe du propriétaire
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string MotDePasse
        {
            get => this.motDePasse;
            set => this.motDePasse = value;
        }

        /// <summary>
        /// Renvoie ou modifie le mail du propriétaire
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Mail
        {
            get => this.mail;
            set => this.mail = value;
        }

        /// <summary>
        /// Renvoie ou modifie le type de personne du propriétaire (physique ou morale)
        /// </summary>
        public bool TypePersonne
        {
            get => typePersonne;
            set => typePersonne = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'adresse du propriétaire
        /// </summary>
        public string Adresse
        {
            get => adresse;
            set => adresse = value;
        }

        #endregion

        #region -------------- Constructeurs --------------

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

        public override bool Equals(object? obj)
        {
            return obj is Proprietaire proprietaire &&
                   id == proprietaire.id &&
                   motDePasse == proprietaire.motDePasse &&
                   nom == proprietaire.nom &&
                   mail == proprietaire.mail &&
                   typePersonne == proprietaire.typePersonne &&
                   adresse == proprietaire.adresse;
        }



        #endregion
    }
}
