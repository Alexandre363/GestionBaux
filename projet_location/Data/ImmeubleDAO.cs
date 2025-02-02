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
    public class ImmeubleDAO
    {
        #region -------------- Attributes --------------
        private HttpClient client;
        #endregion

        #region ------------- Constructors -------------
        /// <summary>
        /// Constructeur de la classe ImmeubleDAO
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public ImmeubleDAO()
        {
            this.client = new HttpClient();
        }
        #endregion

        #region --------------- Methodes ---------------

        /// <summary>
        /// Permet de récupèrer l'ensemble des immeubles d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire des immeubles</param>
        /// <returns>Une liste d'énumérable contenant les immeubles</returns>
        public async Task<IEnumerable<Immeuble>?> ListerImmeuble(int idProprietaire)
        {
            String adressDemande = String.Format("https://localhost:7272/ControllerImmeuble/ListerImmeuble?idProprietaire={0}", idProprietaire);
            HttpResponseMessage reponseHttp = await client.GetAsync(adressDemande);
            string reponse = await reponseHttp.Content.ReadAsStringAsync();
            List<Immeuble>? ListeDesImmeubles = System.Text.Json.JsonSerializer.Deserialize<List<Immeuble>>(reponse, new JsonSerializerOptions(JsonSerializerDefaults.Web));
            return ListeDesImmeubles;
        }

        /// <summary>
        /// Permet d'ajouter un immeuble
        /// </summary>
        /// <param name="immeuble">Immeuble à ajouter</param>
        public async Task AjouterImmeuble(Immeuble immeuble)
        {
            String adressEnvoie = String.Format("https://localhost:7272/ControllerImmeuble/AjouterImmeuble");
            HttpResponseMessage reponse = await client.PostAsJsonAsync(adressEnvoie, immeuble);
        }

        /// <summary>
        /// Permet de modifier un immeuble
        /// </summary>
        /// <param name="immeuble">Immeuble à modifier</param>
        public async Task ModifierImmeuble(Immeuble immeuble)
        {
            String adressEnvoie = String.Format("https://localhost:7272/ControllerImmeuble/ModifierImmeuble");
            HttpResponseMessage reponse = await client.PostAsJsonAsync(adressEnvoie, immeuble);
        }

        /// <summary>
        /// Permet de supprimer un immeuble
        /// </summary>
        /// <param name="immeuble">Immeuble à supprimer</param>
        public async Task RetirerImmeuble(Immeuble immeuble)
        {
            String adressDemande = String.Format("https://localhost:7272/ControllerImmeuble/RetirerImmeuble?id={0}", immeuble.Id);
            HttpResponseMessage reponseHttp = await client.GetAsync(adressDemande);
        }
        #endregion
    }
}