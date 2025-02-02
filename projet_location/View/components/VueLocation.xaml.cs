using projet_location.ViewModel;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace projet_location.View.components
{
    /// <summary>
    /// Logique d'interaction pour VueLocation.xaml
    /// </summary>
    /// <author>Julien Guyenet</author>
    public partial class VueLocation : UserControl
    {
        private LocationVM vueModel;
        private LocationsVM VueModelLocations;
        private LocatairesVM VueModelLocataires;
        private ProprietaireVM VueModelProprietaire;

        /// <summary>
        /// Constructeur d'une vue d'une location
        /// </summary>
        /// <param name="num">Numéro dans la liste des locations</param>
        /// <param name="vueModel">Location en lien avec la vue</param>
        /// <param name="locationsVM"></param>
        /// <author>Julien Guyenet</author>
        public VueLocation(int num, LocationVM vueModel, LocationsVM locationsVM, ProprietaireVM VueModelProprietaire, LocatairesVM VueModelLocataires)
        {
            this.vueModel = vueModel;
            this.VueModelLocations = locationsVM;
            this.DataContext = this.vueModel;
            this.Height = 80;
            InitializeComponent();
            if (num % 2 == 0) this.Background = new SolidColorBrush(Colors.AliceBlue);

            // Locations
            this.VueModelLocataires = VueModelLocataires;

            // Propriétaire
            this.VueModelProprietaire = VueModelProprietaire;
        }

        private void SupprimerItem_Click(object sender, RoutedEventArgs e)
        {
            this.VueModelLocations.RetirerLocation(this.vueModel);
        }

        private void ModifierItem_Click(object sender, RoutedEventArgs e)
        {
            LocationVM LocationCopie = (LocationVM)vueModel.Clone();
            FenetreLocations fen = new FenetreLocations(LocationCopie);
            if (fen.ShowDialog() == true)
            {
                VueModelLocations.ActualiserLocation(LocationCopie);
                this.VueModelLocations.DefinirListeLocations(vueModel.IdProprietaire);

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
