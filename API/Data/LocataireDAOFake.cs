using API.Model;

namespace API.Data
{
    /// <summary>
    /// Représente un faux DAO pour Location
    /// </summary>
    public class LocataireDAOFake : ILocataireDAO
    {

        #region ----------- Constructeur ------------

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public LocataireDAOFake()
        {
            this.memoire = new Dictionary<int, Locataire>
            {
                [0] = new Locataire(0, "Barbarus", "Anivius", DateTime.Now, "21000", "Dijon", "France", "celib", 3, "oui", "touriste", 10, 100, 150, 10, 1)
            };
        }

        #endregion

        #region --------- Attributs ----------
        private Dictionary<int, Locataire> memoire;
        #endregion

        #region --------- Propriétés ----------
        /// <summary>
        ///Liste des locataire 
        /// </summary>
        public Dictionary<int, Locataire> Memoire
        {
            get { return memoire; }
            set { memoire = value; }
        }
        #endregion

        #region --------- Méthodes ----------
        /// <summary>
        /// Ajoute un locataire au fakeDAO
        /// </summary>
        /// <param name="locataire">le locataire à ajouter</param>
        /// <returns>true si le locataire a été ajouter, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool AjouterLocataire(Locataire? locataire)
        {
            {
                bool res = false;
                if (locataire != null)
                {
                    //Cherche le premier id libre
                    int id = 0;
                    while (this.memoire.ContainsKey(id)) id++;

                    // Ajoute l'élément
                    locataire.Id = id;
                    this.memoire[id] = locataire;

                    res = true;
                }
                return res;
            }
        }

        public IEnumerable<Locataire> ListerLocataires(int idProprietaire)
        {
            return this.memoire.Values;
        }
        public bool RetirerLocataire(int id)
        {
            bool res = false;
            if (this.memoire.ContainsKey(id)) res = this.memoire.Remove(id);
            return res;
        }

        /// <summary>
        /// Permet de modifier un locataire
        /// </summary>
        /// <param name="locataire">Le locataire que l'on veut modifier</param>
        /// <returns>True si on a réussi, false sinon</returns>
        /// <author>Hadrien Bourmault</author>
        public bool ModifierLocataire(Locataire locataire)
        {
            bool res = false;
            if (this.memoire.ContainsKey(locataire.Id))
            {
                this.memoire[locataire.Id] = locataire;
                res = true;
            }
            return res;
        }
        #endregion
    }
}
