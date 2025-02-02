using API.Model;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Représenter un controleur pour gérer les proprietaires
    /// </summary>
    /// <author>Julien Guyenet</author>
    [ApiController]
    [Route("[controller]")]
    public class ControllerProprietaire : ControllerBase
    {
        /// <summary>
        /// Méthode asynchrone permettant de renvoyer tous les proprietaires
        /// <returns>Enumération de proprietaires</returns>
        /// <author>Julien Guyenet</author>
        [HttpGet("ListerProprietaire")]
        public ActionResult<IEnumerable<Proprietaire>?> ListerProprietaires()
        {
            ActionResult<IEnumerable<Proprietaire>?> result = BadRequest();
            IEnumerable<Proprietaire?> listeDesProprietaires = ProprietaireManager.Instance.ListerProprietaires();
            if (listeDesProprietaires != null) result = Ok(listeDesProprietaires);
            return result;
        }

        /// <summary>
        /// Méthode permettant d'ajouter un proprietaire
        /// </summary>
        /// <param name="proprietaire">proprietaire à ajouter</param>
        /// <returns>Renvoie la résultat de la requete web (200 si succes)</returns>
        /// <author>Julien Guyenet</author>
        [HttpPost("AjouterProprietaire")]
        public ActionResult AjouterLocataire([FromBody] Proprietaire? proprietaire)
        {
            ActionResult result = BadRequest("impossible d'ajouter ce proprietaire");

            if (ProprietaireManager.Instance.AjouterProprietaire(proprietaire)) result = Ok();

            return result;
        }


        /// <summary>
        /// Méthode supprimant un proprietaire
        /// </summary>
        /// <param name="id">id de l'proprietaire à supprimer</param>
        /// <returns>True s'il a été supprimé, False sinon</returns>
        /// <author>Julien Guyenet</author>
        [HttpGet("RetirerProprietaire")]
        public ActionResult<bool> RetirerProprietaire(int? id)
        {
            ActionResult<bool> result = BadRequest("id non spécifier");

            if (id.HasValue)
            {
                result = NotFound();
                if (ProprietaireManager.Instance.RetirerProprietaire(id.Value)) result = Ok();
            }

            return result;
        }

        /// <summary>
        /// Fait appel à la méthode du Manager pour modifier un proprietaire
        /// </summary>
        /// <param name="proprietaire">proprietaire que l'on veut modifier</param>
        /// <returns>Renvoie Ok si ca a fonctionné ou un code 500 sinon</returns>
        /// <author>Julien Guyenet</author>
        [HttpPost("ModifierProprietaire")]
        public ActionResult ModifierProprietaire([FromBody] Proprietaire proprietaire)
        {
            ActionResult result = BadRequest("Impossible de modifier le proprietaire");

            if (ProprietaireManager.Instance.ModifierProprietaire(proprietaire))
                result = Ok();
            return result;
        }


        /// <summary>
        /// Methode permettant de se connecter a son compte
        /// </summary>
        /// <param name="mail">mail du proprietaire</param>
        /// <param name="mdp">mdp du proprietaire</param>
        /// <returns>id du proprietaire</returns>
        [HttpGet("ConnexionProprietaire")]
        public ActionResult<int?> ConnexionProprietaire(string mail, string mdp)
        {
            ActionResult<int?> result = BadRequest("mail ou mot de passe incorrect");

            if (mail != null && mdp != null) result = Ok(ProprietaireManager.Instance.ConnexionProprietaire(mail, mdp));
            return result;
        }

        /// <summary>
        /// Methode permettant d'obtenir un propriétaire avec la combinaison de son mail et de son mot de passe
        /// </summary>
        /// <param name="mail">Mail du propériétaire</param>
        /// <param name="mdp">Mot de passe du propriétaire</param>
        /// <returns>Le propriétaire, s'il a été trouvé</returns>
        [HttpGet("ObtenirProprietaireParMailMdp")]
        public ActionResult<Proprietaire?> ObtenirProprietaireParMailMdp(string mail, string mdp)
        {
            ActionResult<Proprietaire?> result = BadRequest();

            if (mail != null && mdp != null) result = Ok(ProprietaireManager.Instance.ObtenirProprietaireParMailMdp(mail, mdp));
            return result;
        }
    }
}