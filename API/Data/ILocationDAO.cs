using API.Model;

namespace API.Data
{
    /// <summary>
    /// Représente un DAO pour une location
    /// </summary>
    /// <author>Gibril Lakhdar</author>
    public interface ILocationDAO
    {
        /// <summary>
        /// Permet de renvoyer toutes les locations 
        /// </summary>
        /// <param name="idProprietaire">Id du propriétaires des locations</param>
        /// <returns>Une énumération de toute les locations</returns>
        /// <author>Gibril Lakhdar</author>
        public IEnumerable<Location> ListerLocations(int idProprietaire);

        /// <summary>
        /// Permet de renvoyer toute les locations d'un immeuble
        /// </summary>
        /// <param name="idProprietaire">id du propriétaire de l'immeuble</param>
        /// <param name="idImmeuble">id de l'immeuble</param>
        /// <returns>Une énumérations de tous les appartements</returns>
        /// <author>Julien Guyenet</author>
        public IEnumerable<Location> ListerAppartements(int idProprietaire, int idImmeuble);

        /// <summary>
        /// Permet d'ajouter une location saisit en paramètre
        /// </summary>
        /// <param name="location">Objet Location à ajouter</param>
        /// <returns>True si il est présent, false sinon</returns>
        /// <author>Gibril Lakhdar</author>
        public bool AjouterLocation(Location location);

        /// <summary>
        /// Permet de supprimer une location
        /// </summary>
        /// <param name="id">Id de la location à supprimer</param>
        /// <returns>True si elle a bien été supprimée, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool RetirerLocation(int id);

        /// <summary>
        /// Permet de modifier une location
        /// </summary>
        /// <param name="location">Location à modifier</param>
        /// <returns>True si elle a bien été modifiée, false sinon</returns>
        /// <author>Hadrien Bourmault</author>
        public bool ModifierLocation(Location location);
    }
}
