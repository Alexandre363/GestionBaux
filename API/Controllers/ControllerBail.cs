using API.Model;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Représenter un controleur pour gérer les bails
    /// </summary>
    /// <author>Mroea</author>
    [ApiController]
    [Route("[controller]")]
    public class ControllerBail : ControllerBase
    {
        /// <summary>
        /// Méthode asynchrone permettant de renvoyer tous les bails
        /// </summary>
        /// <returns>Enumération de bails</returns>
        /// <author>Moreau Alexandre</author>
        [HttpGet("ListerBail")]
        public ActionResult<IEnumerable<Bail>?> ListerBail(int idProprietaire)
        {
            ActionResult<IEnumerable<Bail>?> result = BadRequest();
            IEnumerable<Bail?> listeDesBail = BailManager.Instance.ListerBail(idProprietaire);
            if (listeDesBail != null) result = Ok(listeDesBail);
            return result;
        }

        /// <summary>
        /// Méthode permettant d'ajouter un bail
        /// </summary>
        /// <param name="bail">bail à ajouter</param>
        /// <returns>Renvoie la résultat de la requete web (200 si succes)</returns>
        /// <author>Moreau Alexandre</author>
        [HttpPost("AjouterBail")]
        public ActionResult AjouterBail([FromBody] Bail? bail)
        {
            ActionResult result = BadRequest();

            if (BailManager.Instance.AjouterBail(bail)) result = Ok();

            return result;
        }

        /// <summary>
        /// Méthode annulant un bail
        /// </summary>
        /// <param name="id">id du bail à supprimer</param>
        /// <returns>True s'il a été supprimé, False sinon</returns>
        /// <author>Moreau Alexandre</author>
        [HttpGet("AnnulerBail")]
        public ActionResult<bool> AnnulerBail(int? id)
        {
            ActionResult<bool> result = BadRequest("No id specified");

            if (id.HasValue)
            {
                result = NotFound();
                if (BailManager.Instance.AnnulerBail(id.Value)) result = Ok();
            }

            return result;
        }

        /// <summary>
        /// Fait appel à la méthode du Manager pour modifier un bail
        /// </summary>
        /// <param name="bail">bail que l'on veut modifier</param>
        /// <returns>Renvoie Ok si ca a fonctionné ou un code 500 sinon</returns>
        /// <author>Alexandre Moreau</author>
        [HttpPost("ModifierBail")]
        public ActionResult ModifierLocataire([FromBody] Bail bail)
        {
            ActionResult result = BadRequest("Impossible de modifier le bail");

            if (BailManager.Instance.ModifierBail(bail))
                result = Ok();
            return result;
        }

    }
}