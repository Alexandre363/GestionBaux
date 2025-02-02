using API.Model;

namespace API.Data
{
    /// <summary>
    /// Représente un DAO pour un proprietaire de l'application
    /// </summary>
    /// <author>Julien Guyenet</author>
    public interface IProprietaireDAO
    {
        /// <summary>
        /// Permet de renvoyer tous les proprietaires 
        /// </summary>
        /// <returns>Une énumération de tous les proprietaires de l'application</returns>
        /// <author>Julien Guyenet</author>
        public IEnumerable<Proprietaire> ListerProprietaires();

        /// <summary>
        /// Permet d'ajouter un proprietaire saisit en paramètre
        /// </summary>
        /// <param name="proprietaire">Proprietaire à ajouter</param>
        /// <returns>True si l'ajout a fonctionné, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool AjouterProprietaire(Proprietaire proprietaire);

        /// <summary>
        /// Permet de supprimer un proprietaire
        /// </summary>
        /// <param name="id">Id du proprietaire à supprimer</param>
        /// <returns>True s'il a bien été supprimé, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool RetirerProprietaire(int id);

        /// <summary>
        /// Permet de modifier un proprietaire
        /// </summary>
        /// <param name="proprietaire">proprietaire à modifier</param>
        /// <returns>True s'il a bien été modifié, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool ModifierProprietaire(Proprietaire proprietaire);

        /// <summary>
        /// Permet de se connecter a son compte
        /// </summary>
        /// <param name="mail">mail du proprietaire</param>
        /// <param name="mdp">mot de passe du proprietaire</param>
        /// <returns>id du proprietaire</returns>
        /// <author>Alexandre Moreau</author>
        public int ConnexionProprietaire(string mail, string mdp);

        /// <summary>
        /// Obtient un proprietaire
        /// </summary>
        /// <param name="mail">mail du proprietaire</param>
        /// <param name="mdp">mot de passe du proprietaire</param>
        /// <returns>Le propriétaire s'il a été trouvé</returns>
        public Proprietaire ObtenirProprietaireParMailMdp(string mail, string mdp);
    }
}
