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
    /// Le DAO des utilisateurs
    /// Classe en charge de faire le lien avec l'API
    /// </summary>
    public class LocataireDAO
    {
        #region -------------- Attributes --------------
        private HttpClient client;
        #endregion

        #region ------------- Constructors -------------
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public LocataireDAO()
        {
            this.client = new HttpClient();
        }
        #endregion

        #region --------------- Methodes ---------------
        /// <summary>
        /// Permet de récupèrer l'ensemble des locataires d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire des locataires</param>
        /// <returns>Une liste d'énumérable contenant les locataires</returns>
        public async Task<IEnumerable<Locataire>?> ListerLocataire(int idProprietaire)
        {
            String adressDemande = String.Format("https://localhost:7272/ControllerLocataire/ListerLocataire?idProprietaire={0}", idProprietaire);
            HttpResponseMessage reponseHttp = await client.GetAsync(adressDemande);
            string reponse = await reponseHttp.Content.ReadAsStringAsync();
            List<Locataire>? listeDesLocataires = System.Text.Json.JsonSerializer.Deserialize<List<Locataire>>(reponse, new JsonSerializerOptions(JsonSerializerDefaults.Web));
            return listeDesLocataires;
        }

        /// <summary>
        /// Permet d'ajouter un locataire
        /// </summary>
        /// <param name="locataire">Locataire à ajouter</param>
        public async Task AjouterLocataire(Locataire locataire)
        {
            String adressEnvoie = String.Format("https://localhost:7272/ControllerLocataire/AjouterLocataire");
            HttpResponseMessage reponse = await client.PostAsJsonAsync(adressEnvoie, locataire);
        }

        /// <summary>
        /// Permet de supprimer un locataire
        /// </summary>
        /// <param name="locataire">Locataire à supprimer</param>
        public async Task RetirerLocataire(Locataire locataire)
        {
            String adressDemande = String.Format("https://localhost:7272/ControllerLocataire/RetirerLocataire?id={0}", locataire.Id);
            HttpResponseMessage reponseHttp = await client.GetAsync(adressDemande);
        }

        /// <summary>
        /// Permet de modifier un locataire
        /// </summary>
        /// <param name="locataire">Locataire à modifier</param>
        public async Task ModifierLocataire(Locataire locataire)
        {
            String adressEnvoie = String.Format("https://localhost:7272/ControllerLocataire/ModifierLocataire");
            HttpResponseMessage reponse = await client.PostAsJsonAsync(adressEnvoie, locataire);
        }
        #endregion
    }
}