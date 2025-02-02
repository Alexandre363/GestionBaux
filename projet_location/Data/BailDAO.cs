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
    /// DAO des baux
    /// Classe qui fait le lien avec l'API
    /// </summary>
    /// <author>Hadrien Bourmault</author>
    public class BailDAO
    {
        #region --------- Attributs ---------

        private HttpClient client;

        #endregion

        #region --------- Constructeur ---------

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public BailDAO()
        {
            this.client = new HttpClient();
        }

        #endregion

        #region --------- Méthodes ---------

        /// <summary>
        /// Permet de récupèrer l'ensemble des baux d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire des baux</param>
        /// <returns>Une liste d'énumérable contenant les baux</returns>
        /// <author>Hadrien Bourmault</author>
        public async Task<IEnumerable<Bail>?> ListerBaux(int idProprietaire)
        {
            String adresseDemande = String.Format("https://localhost:7272/ControllerBail/ListerBail?idProprietaire={0}", idProprietaire);
            HttpResponseMessage reponseHttp = await client.GetAsync(adresseDemande);
            string reponse = await reponseHttp.Content.ReadAsStringAsync();
            List<Bail>? listeDesBaux = System.Text.Json.JsonSerializer.Deserialize<List<Bail>>(reponse, new JsonSerializerOptions(JsonSerializerDefaults.Web));
            return listeDesBaux;


        }

        /// <summary>
        /// Permet d'ajouter un bail
        /// </summary>
        /// <param name="bail">Bail à ajouter</param>
        /// <author>Hadrien Bourmault</author>
        public async Task AjouterBail(Bail bail)
        {
            String adresseEnvoie = String.Format("https://localhost:7272/ControllerBail/AjouterBail");
            HttpResponseMessage reponse = await client.PostAsJsonAsync(adresseEnvoie, bail);
        }

        /// <summary>
        /// Permet de supprimer un bail
        /// </summary>
        /// <param name="bail">Bail à supprimer</param>
        /// <author>Hadrien Bourmault</author>
        public async Task AnnulerBail(Bail bail)
        {
            String adresseDemande = String.Format("https://localhost:7272/ControllerBail/AnnulerBail?id={0}", bail.Identifiant);
            HttpResponseMessage reponse = await client.GetAsync(adresseDemande);
        }

        /// <summary>
        /// Permet de modifier un bail
        /// </summary>
        /// <param name="bail">Bail à modifier</param>
        /// <author>Hadrien Bourmault</author>
        public async Task ModifierBail(Bail bail)
        {
            String adresseEnvoie = String.Format("https://localhost:7272/ControllerBail/ModifierBail");
            HttpResponseMessage reponse = await client.PostAsJsonAsync(adresseEnvoie, bail);
        }

        #endregion
    }
}
