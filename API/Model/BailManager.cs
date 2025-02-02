using API.Data;

namespace API.Model
{
    public class BailManager
    {
        #region ---------- Singleton --------------
        private static BailManager? instance;

        /// <summary>
        /// Retourne une instance unique de Location Manager
        /// </summary>
        /// <author>Gallois Nathanael</author>
        public static BailManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BailManager();
                }
                return instance;
            }
        }
        #endregion

        #region -------- Constructeur ---------
        private BailManager()
        {

        }

        private static IBailDAO BailDAO => new API.Data.BailDAOFake();

        #endregion

        #region --------- Methods ------------
        /// <summary>
        /// Permet d'annuler un bail
        /// </summary>
        /// <param name="id">Identifiant du bail à annuler</param>
        /// <returns></returns>
        public bool AnnulerBail(int id)
        {
            return BailDAO.AnnulerBail(id);
        }

        /// <summary>
        /// Permet de lister tous les baux d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaires des baux</param>
        /// <returns></returns>
        public IEnumerable<Bail> ListerBail(int idProprietaire)
        {
            return BailDAO.ListerBail(idProprietaire);
        }

        /// <summary>
        /// Permet d'ajouter un bail
        /// </summary>
        /// <param name="bail">Bail à ajouter</param>
        /// <returns>True si l'ajout à fonctionné, false sinon</returns>
        public bool AjouterBail(Bail bail)
        {
            return BailDAO.AjouterBail(bail);
        }


        /// <summary>
        /// Permet de modifier un bail
        /// </summary>
        /// <param name="bail">bail a modifier</param>
        /// <returns></returns>
        public bool ModifierBail(Bail bail)
        {
            return BailDAO.ModifierBail(bail);
        }
        #endregion
    }
}
