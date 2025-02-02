using API.Data;

namespace API.Model
{
    public class ImmeubleManager
    {
        #region ---------- Singleton --------------
        private static ImmeubleManager? instance;

        public static ImmeubleManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImmeubleManager();
                }
                return instance;
            }
        }
        #endregion

        #region -------- Constructeur ---------
        private ImmeubleManager()
        {

        }

        private static IImmeubleDAO ImmeubleDAO => new Data.ImmeubleDAOFake();

        #endregion

        #region --------- Methods ------------
        /// <summary>
        /// Permet de lister tous les immeubles d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire</param>
        /// <returns>Une liste d'énumérable contenant les immeubles</returns>
        /// <author>Julien Guyenet</author>
        public IEnumerable<Immeuble> ListerImmeuble(int idProprietaire)
        {
            return ImmeubleDAO.ListerImmeuble(idProprietaire);
        }

        /// <summary>
        /// Permet d'ajouter un immeuble
        /// </summary>
        /// <param name="immeuble">Immeuble à ajouter</param>
        /// <returns>True si l'ajout à fonctionné, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool AjouterImmeuble(Immeuble immeuble)
        {
            return ImmeubleDAO.AjouterImmeuble(immeuble);
        }

        /// <summary>
        /// Permet de modifier un immeuble
        /// </summary>
        /// <param name="immeuble">Immeuble à modifier</param>
        /// <returns>True si l'ajout à fonctionné, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool ModifierImmeuble(Immeuble immeuble)
        {
            return ImmeubleDAO.ModifierImmeuble(immeuble);
        }

        /// <summary>
        /// Permet de retirer un immeuble
        /// </summary>
        /// <param name="id">Identifiznt de l'immeuble à supprimer</param>
        /// <returns>True si la suppression à fonctionner, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool RetirerImmeuble(int id)
        {
            return ImmeubleDAO.RetirerImmeuble(id);
        }
        #endregion
    }
}
