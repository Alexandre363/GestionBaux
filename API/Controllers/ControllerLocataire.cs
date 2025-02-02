using API.Model;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Représenter un controleur pour gérer les locataires
    /// </summary>
    /// <author>Julien Guyenet</author>
    [ApiController]
    [Route("[controller]")]
    public class ControllerLocataire : ControllerBase
    {
        /// <summary>
        /// Méthode asynchrone permettant de renvoyer tous les locataires
        /// </summary>
        /// <returns>Enumération de Locataires</returns>
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
        /// Méthode permettant d'ajouter un locataire
        /// </summary>
        /// <param name="locataire">locataire à ajouter</param>
        /// <returns>Renvoie la résultat de la requete web (200 si succes)</returns>
        /// <author>Julien Guyenet</author>
        [HttpPost("AjouterLocataire")]
        public ActionResult AjouterLocataire([FromBody] Locataire? locataire)
        {
            ActionResult result = BadRequest();

            if (LocataireManager.Instance.AjouterLocataire(locataire)) result = Ok();

            return result;
        }

        /// <summary>
        /// Méthode supprimant un locataire
        /// </summary>
        /// <param name="id">id du locataire à supprimer</param>
        /// <returns>True s'il a été supprimé, False sinon</returns>
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
        /// Fait appel à la méthode du Manager pour modifier un locataire
        /// </summary>
        /// <param name="locataire">locataire que l'on veut modifier</param>
        /// <returns>Renvoie Ok si ca a fonctionné ou un code 500 sinon</returns>
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