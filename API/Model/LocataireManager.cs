using API.Data;

namespace API.Model
{
    /// <summary>
    /// Représente un gestionnaire de locataire
    /// </summary>
    public class LocataireManager
    {
        #region ---------- Singleton --------------
        private static LocataireManager? instance;

        /// <summary>
        /// Retourne une instance unique de Location Manager
        /// </summary>
        /// <author>Gallois Nathanael</author>
        public static LocataireManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocataireManager();
                }
                return instance;
            }
        }
        #endregion

        #region -------- Constructeur ---------
        private LocataireManager()
        {

        }

        private static ILocataireDAO LocataireDAO => new API.Data.LocataireDAOFake();

        #endregion

        #region --------- Methods ------------
        /// <summary>
        /// Permet de retirer un locataire
        /// </summary>
        /// <param name="id">Identifiant du locataire à retirer</param>
        /// <returns>True si la suppression à fonctionnée, false sinon</returns>
        public bool RetirerLocataire(int id)
        {
            return LocataireDAO.RetirerLocataire(id);
        }

        /// <summary>
        /// Permet de lister tous les locataires d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire</param>
        /// <returns>Une liste d'énumérables contenant les locataires</returns>
        public IEnumerable<Locataire> ListerLocataire(int idProprietaire)
        {
            return LocataireDAO.ListerLocataires(idProprietaire);
        }

        /// <summary>
        /// Permet d'ajouter un locataire
        /// </summary>
        /// <param name="locataire">Le locataire à ajouter</param>
        /// <returns>True si l'ajout à fonctionné, false sinon</returns>
        public bool AjouterLocataire(Locataire locataire)
        {
            return LocataireDAO.AjouterLocataire(locataire);
        }

        /// <summary>
        /// Permet de modifier un locataire
        /// </summary>
        /// <param name="locataire">Locataire à modifier</param>
        /// <returns>True si la modification à fonctionnée, false sinon</returns>
        /// <author>Nathanael Gallois</author>
        public bool ModifierLocataire(Locataire locataire)
        {
            return LocataireDAO.ModifierLocataire(locataire);
        }
        #endregion
    }
}
