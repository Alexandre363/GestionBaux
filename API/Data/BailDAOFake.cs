using API.Model;

namespace API.Data
{
    public class BailDAOFake : IBailDAO
    {
       
        #region ----------- Constructeur ------------

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <author>Moreau Alexandre/author>
        public BailDAOFake()
        {
            this.memoire = new Dictionary<int, Bail>();
        }

        #endregion

        #region --------- Attributs ----------
        private Dictionary<int, Bail> memoire;
        #endregion

        #region --------- Propriétés ----------
        /// <summary>
        ///Liste des bails
        /// </summary>
        /// <author>Moreau Alexandre</author>
        public Dictionary<int, Bail> Memoire
        {
            get { return memoire; }
            set { memoire = value; }
        }
        #endregion


        #region --------- Méthodes ----------

        /// <summary>
        /// Ajoute un bail au fakeDAO
        /// </summary>
        /// <param name="bail">le bail à ajouter</param>
        /// <returns>true si le bail a été ajouter, false sinon</returns>
        /// <author>Moreau Alexandre</author>
        public bool AjouterBail(Bail bail)
        {
            bool res = false;
            if (bail != null)
            {
                //Cherche le premier id libre
                int id = 0;
                while (this.memoire.ContainsKey(id)) id++;

                // Ajoute l'élément
                bail.Identifiant = id;
                this.memoire[id] = bail;

                res = true;
            }
            return res;
        }

        /// <summary>
        /// annule un bail du fakeDAO
        /// </summary>
        /// <param name="id">id du bail à annuler</param>
        /// <returns>true si le bail a été annuler, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool AnnulerBail(int id)
        {
            bool res = false;
            if (this.memoire.ContainsKey(id)) res = this.memoire.Remove(id);
            return res;
        }

        /// <summary>
        /// Liste les bails du fakeDAO
        /// </summary>
        /// <param name="idProprietaire">id du proprietaire</param>
        /// <returns>la liste des bails du proprietaire</returns>
        /// <author>Moreau Alexandre</author>
        public IEnumerable<Bail> ListerBail(int idProprietaire)
        {
            return this.memoire.Values;
        }

        /// <summary>
        /// Modifie le bail du fakeDAO
        /// </summary>
        /// <param name="bail">bail a modifier</param>
        /// <returns>true si le bail a été modifier, false sinon</returns>
        public bool ModifierBail(Bail bail)
        {
            bool res = false;
            if (this.memoire.ContainsKey(bail.Identifiant))
            {
                this.memoire[bail.Identifiant] = bail;
                res = true;
            }
            return res;
        }
        #endregion
    }
}
