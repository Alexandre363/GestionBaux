using projet_location.Data;
using projet_location.Model;

using System.Collections.Generic;
using System.ComponentModel;

namespace projet_location.ViewModel
{
    /// <summary>
    /// Modèle de vue pour la liste des locataires
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    public class LocatairesVM
    {
        #region --------- Attributs -----------
        private Locataires modele;
        private List<LocataireVM> listeDesLocataires;
        #endregion

        #region --------- Propriété -----------
        /// <summary>
        /// Retourne ou Modifie le modèle des locataires
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public Locataires Modele
        {
            get { return modele; }
            set { modele = value; }
        }


        public IEnumerable<LocataireVM> ListeDesLocataires => listeDesLocataires;

        #endregion

        #region ------- Constructeur ----------
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="locataires">locataires servant de modèle</param>
        /// <author>Lakhdar Gibril</author>
        public LocatairesVM(Locataires locataires)
        {
            this.modele = locataires;
            this.listeDesLocataires = new List<LocataireVM>();
            this.modele.PropertyChanged += Model_PropertyChanged;
        }
        #endregion

        #region ------- Méthodes ------------
        /// <summary>
        /// Met à jour la liste visuelle des locataires
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        private void MAJListeDesLocataires()
        {
            this.listeDesLocataires.Clear();
            foreach (Locataire locataire in this.modele.ListeDesLocataires)
            {
                this.listeDesLocataires.Add(new LocataireVM(locataire));
            }
            this.Notifier("ListeDesLocataires");
        }

        /// <summary>
        /// Modifie la liste des locataires à l'aide du DAO
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public async void DefinirListeLocataires(int idProprietaire)
        {
            this.modele.DefinirListeLocataires(await new LocataireDAO().ListerLocataire(idProprietaire));
        }

        /// <summary>
        /// Méthode permettant d'ajouter un locataire
        /// </summary>
        /// <param name="locataireVM">modèle de locataire à utiliser</param>
        /// <author>Lakhdar Gibril</author>
        public async void AjouterLocataire(LocataireVM locataireVM)
        {
            await new LocataireDAO().AjouterLocataire(locataireVM.Model);
            this.modele.DefinirListeLocataires(await new LocataireDAO().ListerLocataire(locataireVM.IdProprietaire));
        }

        public async void ActualiserLocataire(LocataireVM locataireVM)
        {
            await new LocataireDAO().ModifierLocataire(locataireVM.Model);
            this.modele.DefinirListeLocataires(await new LocataireDAO().ListerLocataire(locataireVM.IdProprietaire));
        }

        /// <summary>
        /// Retire le locataire 
        /// </summary>
        /// <param name="locataireVM"></param>
        /// <author>Lakhdar Gibril</author>
        public async void RetirerLocataire(LocataireVM locataireVM)
        {
            await new LocataireDAO().RetirerLocataire(locataireVM.Model);
            this.modele.DefinirListeLocataires(await new LocataireDAO().ListerLocataire(locataireVM.IdProprietaire));
        }
        #endregion

        #region ---------- Observation -----------
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Notifier(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Model_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ListeDesLocataires")
            {
                this.MAJListeDesLocataires();
            }
        }
        #endregion
    }
}
