using API.Model;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Repr�senter un controleur pour g�rer les locations
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    [ApiController]
    [Route("[controller]")]
    public class ControllerLocation : ControllerBase
    {
        /// <summary>
        /// M�thode asynchrone permettant de renvoyer toutes les locations
        /// </summary>
        /// <returns>Enum�ration de Location</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <author>Lakhdar Gibril</author>
        [HttpGet("ListerLocation")]
        public ActionResult<IEnumerable<Location>?> ListerLocation(int idProprietaire)
        {
            ActionResult<IEnumerable<Location>?> result = BadRequest();
            IEnumerable<Location?> listLocation = LocationManager.Instance.ListerLocation(idProprietaire);
            if (listLocation != null) result = Ok(listLocation);
            return result;
        }

        [HttpGet("ListerAppartement")]
        public ActionResult<IEnumerable<Location>?> ListerAppartement(int idProprietaire, int idImmeuble)
        {
            ActionResult<IEnumerable<Location>?> result = BadRequest(idImmeuble);
            IEnumerable<Location>? location = LocationManager.Instance.ListerAppartement(idProprietaire, idImmeuble);
            if (location != null) result = Ok(location);
            return result;
        }


        /// <summary>
        /// M�thode permettant d'ajouter une location
        /// </summary>
        /// <param name="location">location � ajouter</param>
        /// <returns>Renvoie la r�sultat de la requete web (200 si succes)</returns>
        /// <author>Julien Guyenet</author>
        [HttpPost("AjouterLocation")]
        public ActionResult AjouterLocation([FromBody] Location? location)
        {
            ActionResult result = BadRequest();

            if (LocationManager.Instance.AjouterLocation(location)) result = Ok();

            return result;
        }

        /// <summary>
        /// M�thode supprimant une location
        /// </summary>
        /// <param name="location">location � supprimer</param>
        /// <returns>True s'il a �t� supprim�, False sinon</returns>
        /// <author>Alexandre Moreau</author>
        [HttpGet("RetirerLocation")]
        public ActionResult<bool> RetirerLocation(int? id)
        {
            ActionResult<bool> result = BadRequest("No id specified");

            if (id.HasValue)
            {
                result = NotFound();
                if (LocationManager.Instance.RetirerLocation(id.Value)) result = Ok();
            }

            return result;
        }

        /// <summary>
        /// Fait appel � la m�thode du Manager pour modifier une location
        /// </summary>
        /// <param name="location">Location que l'on veut modifier</param>
        /// <returns>Renvoie Ok si ca a fonctionn� ou un code 500 sinon</returns>
        /// <author>Hadrien Bourmault</author>
        [HttpPost("ModifierLocation")]
        public ActionResult ModifierLocation([FromBody] Location location)
        {
            ActionResult result = BadRequest("Impossible de modifier la location");

            if (LocationManager.Instance.ModifierLocation(location))
                result = Ok();
            return result;
        }
    }
}