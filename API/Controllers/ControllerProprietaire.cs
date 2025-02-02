using API.Model;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Repr�senter un controleur pour g�rer les proprietaires
    /// </summary>
    /// <author>Julien Guyenet</author>
    [ApiController]
    [Route("[controller]")]
    public class ControllerProprietaire : ControllerBase
    {
        /// <summary>
        /// M�thode asynchrone permettant de renvoyer tous les proprietaires
        /// <returns>Enum�ration de proprietaires</returns>
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
        /// M�thode permettant d'ajouter un proprietaire
        /// </summary>
        /// <param name="proprietaire">proprietaire � ajouter</param>
        /// <returns>Renvoie la r�sultat de la requete web (200 si succes)</returns>
        /// <author>Julien Guyenet</author>
        [HttpPost("AjouterProprietaire")]
        public ActionResult AjouterLocataire([FromBody] Proprietaire? proprietaire)
        {
            ActionResult result = BadRequest("impossible d'ajouter ce proprietaire");

            if (ProprietaireManager.Instance.AjouterProprietaire(proprietaire)) result = Ok();

            return result;
        }


        /// <summary>
        /// M�thode supprimant un proprietaire
        /// </summary>
        /// <param name="id">id de l'proprietaire � supprimer</param>
        /// <returns>True s'il a �t� supprim�, False sinon</returns>
        /// <author>Julien Guyenet</author>
        [HttpGet("RetirerProprietaire")]
        public ActionResult<bool> RetirerProprietaire(int? id)
        {
            ActionResult<bool> result = BadRequest("id non sp�cifier");

            if (id.HasValue)
            {
                result = NotFound();
                if (ProprietaireManager.Instance.RetirerProprietaire(id.Value)) result = Ok();
            }

            return result;
        }

        /// <summary>
        /// Fait appel � la m�thode du Manager pour modifier un proprietaire
        /// </summary>
        /// <param name="proprietaire">proprietaire que l'on veut modifier</param>
        /// <returns>Renvoie Ok si ca a fonctionn� ou un code 500 sinon</returns>
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
        /// Methode permettant d'obtenir un propri�taire avec la combinaison de son mail et de son mot de passe
        /// </summary>
        /// <param name="mail">Mail du prop�ri�taire</param>
        /// <param name="mdp">Mot de passe du propri�taire</param>
        /// <returns>Le propri�taire, s'il a �t� trouv�</returns>
        [HttpGet("ObtenirProprietaireParMailMdp")]
        public ActionResult<Proprietaire?> ObtenirProprietaireParMailMdp(string mail, string mdp)
        {
            ActionResult<Proprietaire?> result = BadRequest();

            if (mail != null && mdp != null) result = Ok(ProprietaireManager.Instance.ObtenirProprietaireParMailMdp(mail, mdp));
            return result;
        }
    }
}