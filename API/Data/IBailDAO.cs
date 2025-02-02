using API.Model;

namespace API.Data
{
    /// <summary>
    /// Représente un DAO pour un Bail
    /// </summary>
    /// <author>Moreau Alexandre</author>
    public interface IBailDAO
    {
        /// <summary>
        /// Renvoie tous les bails 
        /// </summary>
        /// <returns>Une énumération de tous les bails</returns>
        /// <author>Moreau Alexandre</author>
        public IEnumerable<Bail> ListerBail(int idProprietaire);

        /// <summary>
        /// Permet d'ajouter un bail saisit en paramètre
        /// </summary>
        /// <param name="bail">Objet Bail à ajouter</param>
        /// <returns>True si il est présent, False sinon</returns>
        /// <author>Moreau Alexandre</author>
        public bool AjouterBail(Bail bail);

        /// <summary>
        /// Permet d'annuler d'un bail
        /// </summary>
        /// <param name="id">identifiant du bail à supprimer</param>
        /// <returns>True si il a bien été supprimé, False sinon</returns>
        /// <author>Moreau Alexandre</author>
        public bool AnnulerBail(int id);


        /// <summary>
        /// Permet de modifier un bail
        /// </summary>
        /// <param name="bail">bail à modifier</param>
        /// <returns>True s'il a bien été modifié, False sinon</returns>
        /// <author>Alexandre Moreau</author>
        public bool ModifierBail(Bail bail);

    }
}
