namespace API.Model
{
    /// <summary>
    /// Représente un immeuble
    /// </summary>
    /// <author>Julien Guyenet</author>
    public class Immeuble : ILocation
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
        /// Renvoie ou modifie l'identifiant de l'immeuble
        /// </summary>
        /// <author>Julien Guyenet</author>
        public int Id
        {
            get => this.id;
            set => this.id = value;
        }

        /// <summary>
        /// Renvoie ou modifie le nom de l'immeuble
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Nom
        {
            get => this.nom;
            set => this.nom = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'adresse du bail
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Adresse
        {
            get => this.adresse;
            set => this.adresse = value;
        }

        /// <summary>
        /// Renvoie ou modifie le complément d'adresse de l'immeuble
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string ComplementAdresse
        {
            get => this.complementAdresse;
            set => this.complementAdresse = value;
        }

        /// <summary>
        /// Renvoie ou modifie le code postal de l'immeuble
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string CodePostal
        {
            get => this.codePostal;
            set => this.codePostal = value;
        }

        /// <summary>
        /// Renvoie ou modifie la ville de l'immeuble
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Ville
        {
            get => this.ville;
            set => this.ville = value;
        }

        /// <summary>
        /// Renvoie ou modifie le pays de l'immeuble
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Pays
        {
            get => this.pays;
            set => this.pays = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du propriétaire de l'immeuble
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int IdProprietaire
        {
            get => this.idProprietaire;
            set => this.idProprietaire = value;
        }

        /// <summary>
        /// Renvoie la liste des appartements de l'immeuble
        /// </summary>
        public List<Location> ListeDesAppartements => listeDesAppartements;
        #endregion

        #region -------------- Constructeurs --------------
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

        public override bool Equals(object? obj)
        {
            bool egal = false;
            bool estImmeuble = false;
            if(obj is Immeuble immeuble)
            {
                estImmeuble = true;
                egal = estImmeuble &&
                   id == immeuble.id &&
                   nom == immeuble.nom &&
                   adresse == immeuble.adresse &&
                   complementAdresse == immeuble.complementAdresse &&
                   codePostal == immeuble.codePostal &&
                   ville == immeuble.ville &&
                   pays == immeuble.pays &&
                   idProprietaire == immeuble.idProprietaire;

                bool liste;
                int i = 0;
                if (listeDesAppartements.Count <= 0) 
                {
                    liste = true;
                }
                else
                {
                    liste = false;
                }
                foreach (Location loc in listeDesAppartements)
                {
                    liste = loc.Equals(immeuble.ListeDesAppartements[i]);
                    i++;
                }
                egal = egal && liste;
            }
            
            return egal;
        }


        #endregion

        
    }
}
