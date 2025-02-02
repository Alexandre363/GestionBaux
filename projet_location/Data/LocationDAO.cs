using projet_location.Model;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace projet_location.Data
{
    /// <summary>
    /// Le DAO des locations
    /// Classe en charge de faire le lien avec l'API
    /// </summary>
    /// <author>Julien Guyenet</author>
    public class LocationDAO
    {
        #region -------------- Attributes --------------
        private HttpClient client;
        #endregion

        #region ------------- Constructors -------------
        /// <summary>
        /// Constructeur de la classe location DAO
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public LocationDAO()
        {
            this.client = new HttpClient();
        }
        #endregion

        #region --------------- Methodes ---------------
        /// <summary>
        /// Permet de récuperer la liste des locations d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire des locations</param>
        /// <returns>Une liste d'énumérable contenant les locations</returns>
        public async Task<IEnumerable<Location>?> ListerLocation(int idProprietaire)
        {
            String adressDemande = String.Format("https://localhost:7272/ControllerLocation/ListerLocation?idProprietaire={0}", idProprietaire);
            HttpResponseMessage reponseHttp = await client.GetAsync(adressDemande);
            string reponse = await reponseHttp.Content.ReadAsStringAsync();
            List<Location>? listOfLocation = System.Text.Json.JsonSerializer.Deserialize<List<Location>>(reponse, new JsonSerializerOptions(JsonSerializerDefaults.Web));
            return listOfLocation;
        }

        /// <summary>
        /// Permet d'ajouter une location
        /// </summary>
        /// <param name="location">Location à ajouter</param>
        /// <author>Alexandre Moreau</author>
        public async Task AjouterLocation(Location location)
        {
            String adressEnvoie = String.Format("https://localhost:7272/ControllerLocation/AjouterLocation");
            HttpResponseMessage reponse = await client.PostAsJsonAsync(adressEnvoie, location);
        }


        /// <summary>
        /// Permet de supprimer une location
        /// </summary>
        /// <param name="location">Location à supprimer</param>
        /// <author>Alexandre Moreau</author>
        public async Task RetirerLocation(Location location)
        {
            String adressDemande = String.Format("https://localhost:7272/ControllerLocation/RetirerLocation?id={0}", location.Id);
            HttpResponseMessage reponseHttp = await client.GetAsync(adressDemande);
        }

        /// <summary>
        /// Permet de modifier une location
        /// </summary>
        /// <param name="location">Location à modifier</param>
        /// <author>Alexandre Moreau</author>
        public async Task ModifierLocation(Location location)
        {
            String adressEnvoie = String.Format("https://localhost:7272/ControllerLocation/ModifierLocation");
            HttpResponseMessage reponse = await client.PostAsJsonAsync(adressEnvoie, location);
        }

        /// <summary>
        /// Permet de récuperer la liste des appartements d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire</param>
        /// <param name="idImmeuble">Identifiant de l'immeuble</param>
        /// <returns>Une liste d'énumérable contenant les appartements</returns>
        public async Task<IEnumerable<Location>?> ListerAppartement(int idProprietaire, int idImmeuble)
        {
            String adressDemande = String.Format("https://localhost:7272/ControllerLocation/ListerAppartement?idProprietaire={0}&idImmeuble={1}", idProprietaire, idImmeuble);
            HttpResponseMessage reponseHttp = await client.GetAsync(adressDemande);
            string reponse = await reponseHttp.Content.ReadAsStringAsync();
            List<Location>? listeDesLocations = System.Text.Json.JsonSerializer.Deserialize<List<Location>>(reponse, new JsonSerializerOptions(JsonSerializerDefaults.Web));
            return listeDesLocations;
        }

        #endregion
    }
}