using projet_location.ViewModel;

using System;
using System.Windows;
using System.Windows.Controls;

namespace projet_location.View.components
{
    /// <summary>
    /// Logique d'interaction pour Vue.xaml
    /// </summary>
    /// <author>Julien Guyenet</author>
    public partial class VueAppartement : UserControl
    {
        private LocationVM vueModel;
        private ImmeubleVM VueModelImmeuble;
        private LocatairesVM VueModelLocataires;
        private ProprietaireVM VueModelProprietaire;

        /// <summary>
        /// Constructeur d'une vue d'un appartement
        /// </summary>
        /// <param name="num">Numéro dans la liste des appartements</param>
        /// <param name="vueModel">Appartement en lien avec la vue</param>
        /// <param name="immeubleVM"></param>
        /// <author>Julien Guyenet</author>
        public VueAppartement(LocationVM vueModel, ImmeubleVM immeubleVM, ProprietaireVM VueModelProprietaire, LocatairesVM VueModelLocataires)
        {
            this.vueModel = vueModel;
            this.VueModelImmeuble = immeubleVM;
            this.DataContext = this.vueModel;
            this.Height = 80;
            this.Width = 400;
            InitializeComponent();

            // Locations
            this.VueModelLocataires = VueModelLocataires;

            // Propriétaire
            this.VueModelProprietaire = VueModelProprietaire;
        }

        private void SupprimerItem_Click(object sender, RoutedEventArgs e)
        {
            this.VueModelImmeuble.RetirerAppartement(this.vueModel);
        }

        private void ModifierItem_Click(object sender, RoutedEventArgs e)
        {
            LocationVM LocationCopie = (LocationVM)vueModel.Clone();
            FenetreLocations fen = new FenetreLocations(LocationCopie);
            if (fen.ShowDialog() == true)
            {
                VueModelImmeuble.ActualiserAppartement(LocationCopie);
                this.VueModelImmeuble.DefinirListeAppartements(vueModel.IdProprietaire);
            }
        }

        private void AjoutLocataire_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            foreach (LocataireVM locataires in this.VueModelLocataires.ListeDesLocataires) if (locataires.Id == id) id++;
            LocataireVM locataire = new LocataireVM(new Model.Locataire(id, "", "", DateTime.Now, "", "", "", "", 0, "", "", 0, 0, 0, 0, VueModelProprietaire.Id));
            FenetreLocataire fen = new FenetreLocataire(locataire);
            if (fen.ShowDialog() == true)
            {
                this.VueModelLocataires.AjouterLocataire(locataire);
            }
        }
    }
}
