using API.Model;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Repr�senter un controleur pour g�rer les locataires
    /// </summary>
    /// <author>Julien Guyenet</author>
    [ApiController]
    [Route("[controller]")]
    public class ControllerLocataire : ControllerBase
    {
        /// <summary>
        /// M�thode asynchrone permettant de renvoyer tous les locataires
        /// </summary>
        /// <returns>Enum�ration de Locataires</returns>
        /// <author>Julien Guyenet</author>
        [HttpGet("ListerLocataire")]
        public ActionResult<IEnumerable<Locataire>?> ListerLocataire(int idProprietaire)
        {
            ActionResult<IEnumerable<Locataire>?> result = BadRequest();
            IEnumerable<Locataire?> listeDesLocataires = LocataireManager.Instance.ListerLocataire(idProprietaire);
            if (listeDesLocataires != null) result = Ok(listeDesLocataires);
            return result;
        }

        /// <summary>
        /// M�thode permettant d'ajouter un locataire
        /// </summary>
        /// <param name="locataire">locataire � ajouter</param>
        /// <returns>Renvoie la r�sultat de la requete web (200 si succes)</returns>
        /// <author>Julien Guyenet</author>
        [HttpPost("AjouterLocataire")]
        public ActionResult AjouterLocataire([FromBody] Locataire? locataire)
        {
            ActionResult result = BadRequest();

            if (LocataireManager.Instance.AjouterLocataire(locataire)) result = Ok();

            return result;
        }

        /// <summary>
        /// M�thode supprimant un locataire
        /// </summary>
        /// <param name="id">id du locataire � supprimer</param>
        /// <returns>True s'il a �t� supprim�, False sinon</returns>
        /// <author>Julien Guyenet</author>
        [HttpGet("RetirerLocataire")]
        public ActionResult<bool> RetirerLocataire(int? id)
        {
            ActionResult<bool> result = BadRequest("No id specified");

            if (id.HasValue)
            {
                result = NotFound();
                if (LocataireManager.Instance.RetirerLocataire(id.Value)) result = Ok();
            }

            return result;
        }

        /// <summary>
        /// Fait appel � la m�thode du Manager pour modifier un locataire
        /// </summary>
        /// <param name="locataire">locataire que l'on veut modifier</param>
        /// <returns>Renvoie Ok si ca a fonctionn� ou un code 500 sinon</returns>
        /// <author>Julien Guyenet</author>
        [HttpPost("ModifierLocataire")]
        public ActionResult ModifierLocataire([FromBody] Locataire locataire)
        {
            ActionResult result = BadRequest("Impossible de modifier le locataire");

            if (LocataireManager.Instance.ModifierLocataire(locataire))
                result = Ok();
            return result;
        }
    }
}