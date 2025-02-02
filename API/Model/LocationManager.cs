using API.Data;

namespace API.Model
{
    /// <summary>
    /// Gère le lien entre le controllerLocation et le DAO
    /// </summary>
    /// <author>Hadrien Bourmault</author>
    public class LocationManager
    {
        #region ---------- Singleton --------------
        private static LocationManager? instance;

        /// <summary>
        /// Retourne une instance unique de Location Manager
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public static LocationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocationManager();
                }
                return instance;
            }
        }
        #endregion

        #region -------- Constructeur ---------
        private LocationManager()
        {

        }

        private static ILocationDAO LocationDAO => new API.Data.LocationDAOFake();

        #endregion

        #region --------- Methods ------------
        /// <summary>
        /// Permet de retirer une location
        /// </summary>
        /// <param name="id">Identifiant de la location à retirer</param>
        /// <returns>True si la suppression a fonctionnée, false sinon</returns>
        public bool RetirerLocation(int id)
        {
            return LocationDAO.RetirerLocation(id);
        }

        /// <summary>
        /// Permet de lister toutes les locations d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire</param>
        /// <returns></returns>
        public IEnumerable<Location> ListerLocation(int idProprietaire)
        {
            return LocationDAO.ListerLocations(idProprietaire);
        }

        /// <summary>
        /// Permet de lister tous les appartements d'un immeuble d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire/param>
        /// <param name="idImmeuble">Identifiant de l'immeuble</param>
        /// <returns>Une liste d'énumérables contentant les appartements</returns>
        public IEnumerable<Location> ListerAppartement(int idProprietaire, int idImmeuble)
        {
            return LocationDAO.ListerAppartements(idProprietaire, idImmeuble);
        }

        /// <summary>
        /// Ajoute une location dans le DAO (la bdd)
        /// </summary>
        /// <param name="location">la location a ajouter</param>
        /// <returns>true si l'ajout à était fait false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool AjouterLocation(Location location)
        {
            return LocationDAO.AjouterLocation(location);
        }

        /// <summary>
        /// Permet de modifier une location
        /// </summary>
        /// <param name="location">Location que l'on veut modifier</param>
        /// <returns>True si la modification a fonctionnée, false sinon</returns>
        /// <author>Hadrien Bourmault</author>
        public bool ModifierLocation(Location location)
        {
            return LocationDAO.ModifierLocation(location);
        }
        #endregion
    }
}
