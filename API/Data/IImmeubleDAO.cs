using API.Model;

namespace API.Data
{
    /// <summary>
    /// Représente un DAO pour une location
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    public interface IImmeubleDAO
    {
        /// <summary>
        /// Permet de lister les immeubles d'un proprietaire
        /// </summary>
        /// <param name="idProprietaire">id du propriétaire</param>
        /// <returns>Une énumération d'immeuble</returns>
        /// <author>Julien Guyenet</author>
        public IEnumerable<Immeuble> ListerImmeuble(int idProprietaire);

        /// <summary>
        /// Permet d'ajouter un immeuble
        /// </summary>
        /// <param name="immeuble">l'immeuble à ajouter</param>
        /// <returns>True si l'ajout à fonctionnée, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool AjouterImmeuble(Immeuble immeuble);

        /// <summary>
        /// Permet de modifier un immeuble
        /// </summary>
        /// <param name="immeuble">Immeuble à modifier</param>
        /// <returns>True si la modification a fonctionnée, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool ModifierImmeuble(Immeuble immeuble);

        /// <summary>
        /// Permet de retirer un immeuble
        /// </summary>
        /// <param name="id">Id de l'immeuble à supprimer</param>
        /// <returns>True si la suppression a fonctionnée et false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool RetirerImmeuble(int id);
    }
}
