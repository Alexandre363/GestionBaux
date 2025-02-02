using API.Data;

namespace API.Model
{
    /// <summary>
    /// Fait le lien entre le DAO et la BDD
    /// </summary>
    /// <author>Julien Guyenet</author>
    public class ProprietaireManager
    {
        #region ---------- Singleton --------------
        private static ProprietaireManager? instance;

        /// <summary>
        /// Retourne une instance unique de proprietaire Manager
        /// </summary>
        /// <author>Julien Guyenet</author>
        public static ProprietaireManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProprietaireManager();
                }
                return instance;
            }
        }
        #endregion

        #region -------- Constructeur ---------
        private ProprietaireManager()
        {

        }

        private static IProprietaireDAO ProprietaireDAO => new API.Data.ProprietaireDAOFake();

        #endregion

        #region --------- Methods ------------

        /// <summary>
        /// Informe le DAO de retirer l'proprietaire de la BDD
        /// </summary>
        /// <param name="id">l'id du proprietaire à retirer</param>
        /// <returns>true si l'proprietaire a été surpprimer false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool RetirerProprietaire(int id)
        {
            return ProprietaireDAO.RetirerProprietaire(id);
        }

        /// <summary>
        /// Informe le DAO de listers les proprietaires de la BDD
        /// </summary>
        /// <returns>la liste des proprietaires de la bdd</returns>
        public IEnumerable<Proprietaire> ListerProprietaires()
        {
            return ProprietaireDAO.ListerProprietaires();
        }

        /// <summary>
        ///  Informe le DAO d'ajouter un proprietaire à la BDD
        /// </summary>
        /// <param name="proprietaire">proprietaire a ajouter</param>
        /// <returns>true si l'proprietaire a été ajouté false sinon</returns>
        public bool AjouterProprietaire(Proprietaire proprietaire)
        {
            return ProprietaireDAO.AjouterProprietaire(proprietaire);
        }

        /// <summary>
        /// Fait appel à la méthode du DAO pour modifier un proprietaire
        /// </summary>
        /// <param name="Proprietaire">proprietaire que l'on veut modifier</param>
        /// <returns>True si ca a marché, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool ModifierProprietaire(Proprietaire proprietaire)
        {
            return ProprietaireDAO.ModifierProprietaire(proprietaire);
        }

        /// <summary>
        /// Permet de se connecter a un compte
        /// </summary>
        /// <param name="mail">Mail du proprietaire</param>
        /// <param name="mdp">Mot de passe du proprietaire</param>
        /// <returns>L'identifiant du proprietaire</returns>
        /// <author>Alexandre Moreau</author>
        public int ConnexionProprietaire(string mail, string mdp)
        {
            return ProprietaireDAO.ConnexionProprietaire(mail, mdp);
        }

        /// <summary>
        /// Permet de récupérer un propriétaire grâce à la combinaison de son mail et de sont mot de passe
        /// </summary>
        /// <param name="mail">Mail du propriétaire</param>
        /// <param name="mdp">Mot de passe du propriétaire</param>
        /// <returns>Le propriétaire</returns>
        public Proprietaire ObtenirProprietaireParMailMdp(string mail, string mdp)
        {
            return ProprietaireDAO.ObtenirProprietaireParMailMdp(mail, mdp);
        }
        #endregion

    }
}
