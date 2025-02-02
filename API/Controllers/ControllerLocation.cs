using API.Model;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Représenter un controleur pour gérer les locations
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    [ApiController]
    [Route("[controller]")]
    public class ControllerLocation : ControllerBase
    {
        /// <summary>
        /// Méthode asynchrone permettant de renvoyer toutes les locations
        /// </summary>
        /// <returns>Enumération de Location</returns>
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
        /// Méthode permettant d'ajouter une location
        /// </summary>
        /// <param name="location">location à ajouter</param>
        /// <returns>Renvoie la résultat de la requete web (200 si succes)</returns>
        /// <author>Julien Guyenet</author>
        [HttpPost("AjouterLocation")]
        public ActionResult AjouterLocation([FromBody] Location? location)
        {
            ActionResult result = BadRequest();

            if (LocationManager.Instance.AjouterLocation(location)) result = Ok();

            return result;
        }

        /// <summary>
        /// Méthode supprimant une location
        /// </summary>
        /// <param name="location">location à supprimer</param>
        /// <returns>True s'il a été supprimé, False sinon</returns>
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
        /// Fait appel à la méthode du Manager pour modifier une location
        /// </summary>
        /// <param name="location">Location que l'on veut modifier</param>
        /// <returns>Renvoie Ok si ca a fonctionné ou un code 500 sinon</returns>
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