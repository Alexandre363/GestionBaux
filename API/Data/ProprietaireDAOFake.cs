using API.Model;

namespace API.Data
{
    /// <summary>
    /// Représente un faux DAO pour un proprietaire
    /// </summary>
    /// <author>Julien Guyenet</author>
    public class ProprietaireDAOFake : IProprietaireDAO
    {
        #region ----------- Constructeur ------------

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <author>Julien Guyenet</author>
        public ProprietaireDAOFake()
        {
            this.memoire = new Dictionary<int, Proprietaire>();
            memoire[0] = new Proprietaire(1, "a", "a", "a", false, "a");
        }

        #endregion

        #region --------- Attributs ----------
        private Dictionary<int, Proprietaire> memoire;
        #endregion

        #region --------- Propriétés ----------
        /// <summary>
        ///Liste des proprietaires
        /// </summary>
        /// <author>Julien Guyenet</author>
        public Dictionary<int, Proprietaire> Memoire
        {
            get { return memoire; }
            set { memoire = value; }
        }
        #endregion

        #region --------- Méthodes ----------

        /// <summary>
        /// Ajoute un proprietaire
        /// </summary>
        /// <param name="proprietaire">proprietaire à ajouter</param>
        /// <returns>true si l'ajout a été effectuer, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool AjouterProprietaire(Proprietaire proprietaire)
        {
            {
                bool res = false;
                if ((proprietaire != null) && (this.memoire.ContainsValue(proprietaire) == false))
                {
                    //Cherche le premier id libre
                    int id = 0;
                    while (this.memoire.ContainsKey(id)) id++;

                    // Ajoute l'élément
                    proprietaire.Id = id;
                    this.memoire[id] = proprietaire;

                    res = true;
                }
                return res;
            }
        }

        /// <summary>
        /// Liste les proprietaires
        /// </summary>
        /// <returns>une énumérations de proprietaire</returns>
        /// <author>Julien Guyenet</author>
        public IEnumerable<Proprietaire> ListerProprietaires()
        {
            return this.memoire.Values;
        }

        /// <summary>
        /// Retirer un proprietaire de la liste
        /// </summary>
        /// <param name="id">l'id du proprietaire à supprimer</param>
        /// <returns>true si a suppression a fonctionner, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool RetirerProprietaire(int id)
        {
            bool res = false;
            if (this.memoire.ContainsKey(id)) res = this.memoire.Remove(id);
            return res;
        }

        /// <summary>
        /// Permet de modifier un proprietaire
        /// </summary>
        /// <param name="proprietaire">proprietaire que l'on veut modifier</param>
        /// <returns>True si on a réussi, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool ModifierProprietaire(Proprietaire proprietaire)
        {
            bool res = false;
            if (this.memoire.ContainsKey(proprietaire.Id))
            {
                this.memoire[proprietaire.Id] = proprietaire;
                res = true;
            }
            return res;
        }

        /// <summary>
        /// Permet de se connecter a son compte
        /// </summary>
        /// <param name="mail">mail du proprietaire</param>
        /// <param name="mdp">mot de passe du proprietaire</param>
        /// <returns>id du proprietaire</returns>
        /// <author>Alexandre Moreau</author>
        public int ConnexionProprietaire(string mail, string mdp)
        {
            int i = 0;
            while (mail != this.memoire[i].Mail && mdp != this.memoire[i].MotDePasse) { i++; }
            return i;
        }

        public Proprietaire ObtenirProprietaireParMailMdp(string mail, string mdp)
        {
            int i = 0;
            while (mail != this.memoire[i].Mail && mdp != this.memoire[i].MotDePasse) { i++; }
            return memoire[i];
        }
        #endregion
    }
}