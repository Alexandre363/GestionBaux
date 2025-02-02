using System.Collections.Generic;
using System.ComponentModel;

namespace projet_location.Model
{
    /// <summary>
    /// Classe repésentant une liste de bail
    /// </summary>
    public class Baux : INotifyPropertyChanged
    {
        #region ------------ Attributs ------------
        private List<Bail> listeDesBaux;
        #endregion

        #region ------------- Propriété --------------

        /// <summary>
        /// Permet de renvoyer la liste des bails
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public List<Bail> ListeDesBails
        {
            get
            {
                return this.listeDesBaux;
            }
        }

        #endregion

        #region ------------- Constructeur --------------

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public Baux()
        {
            this.listeDesBaux = new List<Bail>();
        }

        #endregion

        #region ------------- Méthodes --------------

        /// <summary>
        /// Permet de modifier la liste des baux
        /// </summary>
        /// <param name="liste">Liste des baux actualisés</param>
        /// <author>Hadrien Bourmault</author>
        public void DefinirListeBails(IEnumerable<Bail> liste)
        {
            this.listeDesBaux.Clear();
            foreach (Bail b in liste)
            {
                this.listeDesBaux.Add(b);
            }
            this.Notifier("ListeDesBaux");
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
