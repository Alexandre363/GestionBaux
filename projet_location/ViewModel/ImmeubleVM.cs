using projet_location.Data;
using projet_location.Model;

using System.Collections.Generic;
using System.ComponentModel;

namespace projet_location.ViewModel
{
    /// <summary>
    /// Vue Model d'un Immeuble
    /// </summary>
    public class ImmeubleVM : ILocationVM
    {
        #region -------------- Attributes --------------
        //Modèle
        private Immeuble model;

        //Liste des appartement en VM
        private List<LocationVM> listeDesAppartements;
        #endregion

        #region -------------- Properties --------------
        /// <summary>
        /// Liste des VM des appartements de cet immeuble
        /// </summary>
        public List<LocationVM> ListeDesAppartements => listeDesAppartements;

        /// <summary>
        /// Renvoie le modèle (immeuble) de cette vueModel
        /// </summary>
        public ILocation Model => model;

        /// <summary>
        /// Propriété get retournant l'id de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public int Id
        {
            get => this.Model.Id;
            set { this.Model.Id = value; this.Notifier("Id"); }
        }

        /// <summary>
        /// Propriété get retournant le nom de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Nom
        {
            get => this.Model.Nom;
            set { this.Model.Nom = value; this.Notifier("Nom"); }
        }

        /// <summary>
        /// Propriété get retournant l'adresse de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Adresse
        {
            get => this.Model.Adresse;
            set { this.Model.Adresse = value; this.Notifier("Adresse"); }
        }

        /// <summary>
        /// Propriété get retournant des informations complémentaire sur l'adresse de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string ComplementAdresse
        {
            get => this.Model.ComplementAdresse;
            set { this.Model.ComplementAdresse = value; this.Notifier("ComplementAdresse"); }
        }

        /// <summary>
        /// Propriété get retournant le code postal de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string CodePostal
        {
            get => this.Model.CodePostal;
            set { this.Model.CodePostal = value; this.Notifier("CodePostal"); }
        }

        /// <summary>
        /// Propriété get retournant la ville où se situe la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Ville
        {
            get => this.Model.Ville;
            set { this.Model.Ville = value; this.Notifier("Ville"); }
        }

        /// <summary>
        /// Propriété get retournant le pays où se situe la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Pays
        {
            get => this.Model.Pays;
            set { this.Model.Pays = value; this.Notifier("Pays"); }
        }

        public int IdProprietaire
        {
            get => this.Model.IdProprietaire;
            set { this.Model.IdProprietaire = value; this.Notifier("IdProprietaire"); }
        }

        #endregion

        #region ------------- Constructors -------------
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="model">Liste des immeubles</param>
        /// <author>Julien Guyenet</author>
        public ImmeubleVM(Immeuble model)
        {
            this.model = model;
            this.listeDesAppartements = new List<LocationVM>();
            this.model.PropertyChanged += Model_PropertyChanged;
            this.DefinirListeAppartements(this.IdProprietaire);
        }
        #endregion

        #region --------------- Methodes ---------------

        /// <summary>
        /// Met à jour la liste visuelle des appartements
        /// </summary>
        /// <author>Julien Guyenet</author>
        private void MAJListeDesAppartements()
        {
            this.listeDesAppartements.Clear();
            foreach (Location location in this.model.ListeDesAppartements)
            {
                this.listeDesAppartements.Add(new LocationVM(location));
            }
            this.Notifier("ListeDesAppartements");
        }

        public async void ActualiserAppartement(LocationVM locationVM)
        {
            await new LocationDAO().ModifierLocation((Location)locationVM.Model);
            this.DefinirListeAppartements(locationVM.IdProprietaire);
        }

        /// <summary>
        /// Modifie la liste des appartement à l'aide du DAO
        /// </summary>
        /// <author>Julien Guyenet</author>
        public async void DefinirListeAppartements(int idProprietaire)
        {
            this.model.DefinirListeAppartements(await new LocationDAO().ListerAppartement(idProprietaire, this.Id));
        }

        /// <summary>
        /// Fait ajouter un appartement
        /// </summary>
        /// <param name="locationVM">VM de l'appartement à ajouter</param>
        public async void AjouterAppartement(LocationVM locationVM)
        {
            await new LocationDAO().AjouterLocation((Location)locationVM.Model);
            this.DefinirListeAppartements(locationVM.IdProprietaire);
        }

        /// <summary>
        /// Fait supprimer un appartement
        /// </summary>
        /// <param name="locationVM">VM de la location à ajouter</param>
        public async void RetirerAppartement(LocationVM locationVM)
        {
            await new LocationDAO().RetirerLocation((Location)locationVM.Model);
            this.DefinirListeAppartements(locationVM.IdProprietaire);
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
            if (e.PropertyName == "ListeDesAppartements")
            {
                this.MAJListeDesAppartements();
            }
        }

        public object Clone()
        {
            return new ImmeubleVM((Immeuble)model.Clone());
        }
        #endregion
    }
}