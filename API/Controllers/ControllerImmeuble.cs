using API.Model;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Représenter un controleur pour gérer les immeubles
    /// </summary>
    /// <author>Julien Guyenet</author>
    [ApiController]
    [Route("[controller]")]
    public class ControllerImmeuble : ControllerBase
    {
        /// <summary>
        /// Méthode asynchrone permettant de renvoyer tous les immeubles
        /// </summary>
        /// <returns>Enumération d'immeubles</returns>
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
        /// Méthode permettant d'ajouter un immeuble
        /// </summary>
        /// <param name="immeuble">immeuble à ajouter</param>
        /// <returns>Renvoie la résultat de la requete web (200 si succes)</returns>
        /// <author>Julien Guyenet</author>
        [HttpPost("AjouterImmeuble")]
        public ActionResult AjouterImmeuble([FromBody] Immeuble? immeuble)
        {
            ActionResult result = BadRequest();

            if (ImmeubleManager.Instance.AjouterImmeuble(immeuble)) result = Ok();

            return result;
        }

        /// <summary>
        /// Méthode supprimant un immeuble
        /// </summary>
        /// <param name="id">id de l'immeuble à supprimer</param>
        /// <returns>True s'il a été supprimé, False sinon</returns>
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
        /// Fait appel à la méthode du Manager pour modifier un immeuble
        /// </summary>
        /// <param name="immeuble">immeuble que l'on veut modifier</param>
        /// <returns>Renvoie Ok si ca a fonctionné ou un code 500 sinon</returns>
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