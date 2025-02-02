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
    /// Le DAO des proprietaires
    /// Classe en charge de faire le lien avec l'API
    /// </summary>
    /// <author>Julien Guyenet</author>
    public class ProprietaireDAO
    {
        #region -------------- Attributes --------------
        private HttpClient client;
        #endregion

        #region ------------- Constructors -------------
        /// <summary>
        /// Constructeur de la classe proprietaire DAO
        /// </summary>
        /// <author>Julien Guyenet</author>
        public ProprietaireDAO()
        {
            this.client = new HttpClient();
        }
        #endregion

        #region --------------- Methodes ---------------
        /// <summary>
        /// Permet d'ajouter un proprietaire
        /// </summary>
        /// <param name="proprietaire">Proprietaire à ajouter</param>
        /// <author>Julien Guyenet</author>
        public async Task AjouterProprietaire(Proprietaire proprietaire)
        {
            String adressEnvoie = String.Format("https://localhost:7272/ControllerProprietaire/AjouterProprietaire");
            HttpResponseMessage reponse = await client.PostAsJsonAsync(adressEnvoie, proprietaire, new JsonSerializerOptions(JsonSerializerDefaults.Web));
        }

        /// <summary>
        /// Permet de supprimer une proprietaire
        /// </summary>
        /// <param name="proprietaire">Propriétaire à supprimer</param>
        /// <author>Alexandre Moreau</author>
        public async Task RetirerProprietaire(Proprietaire proprietaire)
        {
            String adressDemande = String.Format("https://localhost:7272/ControllerProprietaire/RetirerProprietaire?id={0}", proprietaire.Id);
            HttpResponseMessage reponseHttp = await client.GetAsync(adressDemande);
        }

        /// <summary>
        /// Permet de modifier un proprietaire
        /// </summary>
        /// <param name="proprietaire">Propriétaire à modifier</param>
        /// <author>Julien Guyenet</author>
        public async Task ModifierProprietaire(Proprietaire proprietaire)
        {
            String adressEnvoie = String.Format("https://localhost:7272/ControllerProprietaire/ModifierProprietaire");
            HttpResponseMessage reponse = await client.PostAsJsonAsync(adressEnvoie, proprietaire);
        }

        /// <summary>
        /// Permet d'obtenir un proprietaire
        /// </summary>
        /// <param name="mail">Mail du proprietaire</param>
        /// <param name="mdp">Mot de passe du proprietaire</param>
        /// <returns>Propriétaire obtenu</returns>
        public async Task<Proprietaire?> ObtenirProprietaireParMailMdp(string mail, string mdp)
        {
            String adressEnvoie = String.Format("https://localhost:7272/ControllerProprietaire/ObtenirProprietaireParMailMdp?mail={0}&mdp={1}", mail, mdp);
            HttpResponseMessage reponseHttp = await client.GetAsync(adressEnvoie);
            string reponse = await reponseHttp.Content.ReadAsStringAsync();
            Proprietaire? proprietaire = System.Text.Json.JsonSerializer.Deserialize<Proprietaire?>(reponse, new JsonSerializerOptions(JsonSerializerDefaults.Web));
            return proprietaire;
        }
        #endregion
    }
}