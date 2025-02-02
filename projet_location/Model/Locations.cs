using System.Collections.Generic;
using System.ComponentModel;

namespace projet_location.Model
{
    /// <summary>
    /// Liste des locations
    /// </summary>
    /// <author>Julien Guyenet</author>
    public class Locations : INotifyPropertyChanged
    {
        #region -------------- Attributes --------------
        private List<ILocation> listeDesLocations;
        #endregion

        #region -------------- Properties --------------
        /// <summary>
        /// Renvoie la liste des locations
        /// </summary>
        /// <author>Julien Guyenet</author>
        public List<ILocation> ListeDesLocations => listeDesLocations;
        #endregion

        #region ------------- Constructors -------------
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <author>Julien Guyenet</author>
        public Locations()
        {
            listeDesLocations = new List<ILocation>();

        }
        #endregion

        #region --------------- Methodes ---------------
        /// <summary>
        /// Permet de modifier la liste des locations
        /// </summary>
        /// <param name="liste">Liste des locations actualisée</param>
        /// <author>Julien Guyenet</author>
        public void DefinirListeLocations(IEnumerable<ILocation>? liste)
        {
            this.listeDesLocations.Clear();
            if (liste != null)
            {
                foreach (ILocation location in liste)
                {
                    if (location is Location loca) this.listeDesLocations.Add(loca);
                    if (location is Immeuble immeuble) this.listeDesLocations.Add(immeuble);
                }
                this.Notifier("ListeDesLocations");
            }
        }
        #endregion

        #region ---------- Observation -------------
        /// <summary>
        /// Stocke le nom de la propriété qui a effectuée le changement à l'aide de la fonction notifier
        /// </summary>
        /// <author>Julien Guyenet</author>
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void Notifier(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}