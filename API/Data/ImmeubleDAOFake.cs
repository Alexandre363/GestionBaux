using API.Model;

namespace API.Data
{
    /// <summary>
    /// Représente un faux DAO pour un Immeuble
    /// </summary>
    public class ImmeubleDAOFake : IImmeubleDAO
    {

        #region ----------- Constructeur ------------

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public ImmeubleDAOFake()
        {
            this.memoire = new Dictionary<int, Immeuble>
            {
                [1] = new Immeuble(1, "loca1", "9 rue des tournesoles", "", "21000", "Dijon", "France", 1)
            };
        }

        #endregion

        #region --------- Attributs ----------
        private Dictionary<int, Immeuble> memoire;
        #endregion

        #region --------- Propriétés ----------
        /// <summary>
        ///List of the users 
        /// </summary>
        public Dictionary<int, Immeuble> Memoire
        {
            get { return memoire; }
            set { memoire = value; }
        }

        #endregion

        #region --------- Méthodes ----------

        public IEnumerable<Immeuble> ListerImmeuble(int idProprietaire)
        {
            return this.memoire.Values;
        }

        public bool AjouterImmeuble(Immeuble immeuble)
        {
            {
                bool res = false;
                if ((immeuble != null) && (this.memoire.ContainsValue(immeuble) == false))
                {
                    //Cherche le premier id libre
                    int id = 1;
                    while (this.memoire.ContainsKey(id)) id++;

                    // Ajoute l'élément
                    immeuble.Id = id;
                    this.memoire[id] = immeuble;


                    res = true;
                }
                return res;
            }
        }

        public bool ModifierImmeuble(Immeuble immeuble)
        {
            bool res = false;
            if (this.memoire.ContainsKey(immeuble.Id))
            {
                this.memoire[immeuble.Id] = immeuble;
                res = true;
            }
            return res;
        }

        public bool RetirerImmeuble(int id)
        {
            bool res = false;
            if (this.memoire.ContainsKey(id)) res = this.memoire.Remove(id);
            return res;
        }
        #endregion
    }
}