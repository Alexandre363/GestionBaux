using API.Model;

namespace API.Data
{
    /// <summary>
    /// Représente un DAO pour une location
    /// </summary>
    /// <author>Nathanael Gallois</author>
    public interface ILocataireDAO
    {
        /// <summary>
        /// Permet de renvoier tous les locataires d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire des locataires</param>
        /// <returns>Une énumération de toute les locations</returns>
        /// <author>Nathanael Gallois</author>
        public IEnumerable<Locataire> ListerLocataires(int idProprietaire);

        /// <summary>
        /// Permet d'ajouter un locataire saisit en paramètre
        /// </summary>
        /// <param name="locataire">Locataire à ajouter</param>
        /// <returns>True s'il a réussi à l'ajouter, false sinon</returns>
        /// <author>Nathanael Gallois</author>
        public bool AjouterLocataire(Locataire locataire);

        /// <summary>
        /// Permet de supprimer un locataire
        /// </summary>
        /// <param name="id">Id du locataire à supprimer</param>
        /// <returns>True si il a bien été supprimé, false sinon</returns>
        /// <author>Nathanael Gallois</author>
        public bool RetirerLocataire(int id);

        /// <summary>
        /// Permet de modifier un locataire
        /// </summary>
        /// <param name="locataire">Locataire à modifier</param>
        /// <returns>True s'il a bien été modifié, false sinon</returns>
        /// <author>Nathanael Gallois</author>
        public bool ModifierLocataire(Locataire locataire);
    }
}
