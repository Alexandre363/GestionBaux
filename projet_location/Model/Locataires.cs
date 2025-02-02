using System.Collections.Generic;
using System.ComponentModel;

namespace projet_location.Model
{
    /// <summary>
    /// Classe réprésentant une liste des locataires
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    public class Locataires : INotifyPropertyChanged
    {
        #region ------------ Attributs -------------
        private List<Locataire> listeDesLocataires;
        #endregion

        #region ------------- Propriété --------------
        /// <summary>
        /// Renvoie la liste des locataires
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public List<Locataire> ListeDesLocataires
        {
            get
            {
                return listeDesLocataires;
            }
        }
        #endregion

        #region ------------- Constructeur ----------------
        /// <summary>
        /// Constructeur de la classe locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public Locataires()
        {
            listeDesLocataires = new List<Locataire>();
        }
        #endregion

        #region ---------------------- Methodes --------------
        /// <summary>
        /// Permet de modifier la liste des locataires
        /// </summary>
        /// <param name="list">Liste des locataires actualisée</param>
        /// <author>Lakhdar Gibril</author>
        public void DefinirListeLocataires(IEnumerable<Locataire> liste)
        {
            this.listeDesLocataires.Clear();
            foreach (Locataire locataire in liste)
            {
                this.listeDesLocataires.Add(locataire);
            }
            this.Notifier("ListeDesLocataires");
        }
        #endregion

        #region ---------- Observation -------------
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Notifier(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
