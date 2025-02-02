using projet_location.Data;
using projet_location.Model;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace projet_location.ViewModel
{
    /// <summary>
    /// Vue Model des locations
    /// </summary>
    public class LocationsVM : INotifyPropertyChanged
    {
        #region -------------- Attributes --------------
        //Modèle
        private Locations model;
        //Liste des locations en VM
        private List<ILocationVM> listeDesLocations;
        #endregion

        #region -------------- Properties --------------
        /// <summary>
        /// Liste des VM des locations
        /// </summary>
        public IEnumerable<ILocationVM> ListeDesLocations => listeDesLocations;
        #endregion

        #region ------------- Constructors -------------
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="model">Liste des locations</param>
        /// <author>Julien Guyenet</author>
        public LocationsVM(Locations model)
        {
            this.model = model;
            this.listeDesLocations = new List<ILocationVM>();
            this.model.PropertyChanged += Model_PropertyChanged;
        }
        #endregion

        #region --------------- Methodes ---------------
        /// <summary>
        /// Met à jour la liste visuelle des locations
        /// </summary>
        /// <author>Julien Guyenet</author>
        private void MAJListeDesLocations()
        {
            this.listeDesLocations.Clear();
            foreach (ILocation location in this.model.ListeDesLocations)
            {
                if (location is Location loca) this.listeDesLocations.Add(new LocationVM(loca));
                if (location is Immeuble immeuble) this.listeDesLocations.Add(new ImmeubleVM(immeuble));
            }
            this.Notifier("ListeDesLocations");
        }

        /// <summary>
        /// Modifie la liste des locations à l'aide du DAO
        /// </summary>
        /// <author>Julien Guyenet</author>
        public async void DefinirListeLocations(int idProprietaire)
        {
            IEnumerable<ILocation>? listeLocations = await new LocationDAO().ListerLocation(idProprietaire);
            IEnumerable<ILocation>? listeImmeubles = await new ImmeubleDAO().ListerImmeuble(idProprietaire);
            this.model.DefinirListeLocations(listeLocations.Concat(listeImmeubles));
        }

        /// <summary>
        /// Fait ajouter une location
        /// </summary>
        /// <param name="locationVM">VM de la location à ajouter</param>
        public async void AjouterLocation(ILocationVM locationVM)
        {
            if (locationVM is LocationVM) await new LocationDAO().AjouterLocation((Location)locationVM.Model);
            if (locationVM is ImmeubleVM) await new ImmeubleDAO().AjouterImmeuble((Immeuble)locationVM.Model);
            this.DefinirListeLocations(locationVM.IdProprietaire);
        }

        public async void ActualiserLocation(LocationVM locationVM)
        {
            await new LocationDAO().ModifierLocation((Location)locationVM.Model);
            this.DefinirListeLocations(locationVM.IdProprietaire);
        }

        /// <summary>
        /// Fait supprimer une location
        /// </summary>
        /// <param name="locationVM">VM de la location à ajouter</param>
        public async void RetirerLocation(LocationVM locationVM)
        {
            await new LocationDAO().RetirerLocation((Location)locationVM.Model);
            this.DefinirListeLocations(locationVM.IdProprietaire);
        }


        public async void RetirerImmeuble(ImmeubleVM immeubleVM)
        {
            await new ImmeubleDAO().RetirerImmeuble((Immeuble)immeubleVM.Model);
            this.DefinirListeLocations(immeubleVM.IdProprietaire);
        }

        public async void ActualiserImmeuble(ImmeubleVM immeubleVM)
        {
            await new ImmeubleDAO().ModifierImmeuble((Immeuble)immeubleVM.Model);
            this.DefinirListeLocations(immeubleVM.IdProprietaire);
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

        private void Model_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ListeDesLocations")
            {
                this.MAJListeDesLocations();
            }
        }
        #endregion
    }
}