using API.Model;

namespace API.Data
{
    /// <summary>
    /// Représente un faux DAO pour Location
    /// </summary>
    public class LocationDAOFake : ILocationDAO
    {
        #region ----------- Constructeur ------------

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public LocationDAOFake()
        {
            this.memoire = new Dictionary<int, Location>();

        }

        #endregion

        #region --------- Attributs ----------
        private Dictionary<int, Location> memoire;
        #endregion

        #region --------- Propriétés ----------
        /// <summary>
        ///List of the users 
        /// </summary>
        public Dictionary<int, Location> Memoire
        {
            get { return memoire; }
            set { memoire = value; }
        }
        #endregion

        #region --------- Méthodes ----------

        public bool AjouterLocation(Location location)
        {
            {
                bool res = false;
                if ((location != null) && (this.memoire.ContainsValue(location) == false))
                {
                    //Cherche le premier id libre
                    int id = 0;
                    while (this.memoire.ContainsKey(id)) id++;

                    // Ajoute l'élément
                    location.Id = id;
                    this.memoire[id] = location;

                    res = true;
                }
                return res;
            }
        }

        public IEnumerable<Location> ListerLocations(int idProprietaire)
        {
            IEnumerable<Location> res = new List<Location>();
            foreach (Location location in this.Memoire.Values) { if (location.IdImmeuble == 0) res = res.Append(location); }
            return res;
        }

        public IEnumerable<Location> ListerAppartements(int idProprietaire, int idImmeuble)
        {
            List<Location> list = new List<Location>();
            foreach (Location location in memoire.Values) if (location.IdImmeuble == idImmeuble) list.Add(location);
            return list;
        }

        public bool RetirerLocation(int id)
        {
            bool res = false;
            if (this.memoire.ContainsKey(id)) res = this.memoire.Remove(id);
            return res;
        }

        /// <summary>
        /// Permet de modifier une location
        /// </summary>
        /// <param name="location">La location que l'on veut modifier</param>
        /// <returns>True si on a réussi, false sinon</returns>
        /// <author>Hadrien Bourmault</author>
        public bool ModifierLocation(Location location)
        {
            bool res = false;
            if (this.memoire.ContainsKey(location.Id))
            {
                this.memoire[location.Id] = location;
                res = true;
            }
            return res;
        }
        #endregion
    }
}