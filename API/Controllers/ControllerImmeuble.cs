using API.Model;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Repr�senter un controleur pour g�rer les immeubles
    /// </summary>
    /// <author>Julien Guyenet</author>
    [ApiController]
    [Route("[controller]")]
    public class ControllerImmeuble : ControllerBase
    {
        /// <summary>
        /// M�thode asynchrone permettant de renvoyer tous les immeubles
        /// </summary>
        /// <returns>Enum�ration d'immeubles</returns>
        /// <author>Julien Guyenet</author>
        [HttpGet("ListerImmeuble")]
        public ActionResult<IEnumerable<Immeuble>?> ListerImmeuble(int idProprietaire)
        {
            ActionResult<IEnumerable<Immeuble>?> result = BadRequest();
            IEnumerable<Immeuble?> listeDesImmeubles = ImmeubleManager.Instance.ListerImmeuble(idProprietaire);
            if (listeDesImmeubles != null) result = Ok(listeDesImmeubles);
            return result;
        }

        /// <summary>
        /// M�thode permettant d'ajouter un immeuble
        /// </summary>
        /// <param name="immeuble">immeuble � ajouter</param>
        /// <returns>Renvoie la r�sultat de la requete web (200 si succes)</returns>
        /// <author>Julien Guyenet</author>
        [HttpPost("AjouterImmeuble")]
        public ActionResult AjouterImmeuble([FromBody] Immeuble? immeuble)
        {
            ActionResult result = BadRequest();

            if (ImmeubleManager.Instance.AjouterImmeuble(immeuble)) result = Ok();

            return result;
        }

        /// <summary>
        /// M�thode supprimant un immeuble
        /// </summary>
        /// <param name="id">id de l'immeuble � supprimer</param>
        /// <returns>True s'il a �t� supprim�, False sinon</returns>
        /// <author>Julien Guyenet</author>
        [HttpGet("RetirerImmeuble")]
        public ActionResult<bool> RetirerImmeuble(int? id)
        {
            ActionResult<bool> result = BadRequest("No id specified");

            if (id.HasValue)
            {
                result = NotFound();
                if (ImmeubleManager.Instance.RetirerImmeuble(id.Value)) result = Ok();
            }

            return result;
        }

        /// <summary>
        /// Fait appel � la m�thode du Manager pour modifier un immeuble
        /// </summary>
        /// <param name="immeuble">immeuble que l'on veut modifier</param>
        /// <returns>Renvoie Ok si ca a fonctionn� ou un code 500 sinon</returns>
        /// <author>Julien Guyenet</author>
        [HttpPost("ModifierImmeuble")]
        public ActionResult ModifierImmeuble([FromBody] Immeuble immeuble)
        {
            ActionResult result = BadRequest("Impossible de modifier le immeuble");

            if (ImmeubleManager.Instance.ModifierImmeuble(immeuble))
                result = Ok();
            return result;
        }
    }
}