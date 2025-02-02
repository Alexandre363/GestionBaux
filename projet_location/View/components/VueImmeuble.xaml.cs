using projet_location.Data;
using projet_location.Model;
using projet_location.ViewModel;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace projet_location.View.components
{
    /// <summary>
    /// Logique d'interaction pour VueLocation.xaml
    /// </summary>
    /// <author>Julien Guyenet</author>
    public partial class VueImmeuble : UserControl
    {
        private ImmeubleVM vueModel;
        private LocationsVM vueModelLocations;
        private LocatairesVM VueModelLocataires;
        private ProprietaireVM VueModelProprietaire;

        /// <summary>
        /// Constructeur d'une vue d'un Immeuble
        /// </summary>
        /// <param name="num">Numéro dans la liste de l-Immeuble</param>
        /// <param name="vueModel">Immeuble en lien avec la vue</param>
        /// <author>Julien Guyenet</author>
        public VueImmeuble(int num, ImmeubleVM vueModel, LocationsVM vueModelLocations, ProprietaireVM VueModelProprietaire, LocatairesVM VueModelLocataires)
        {
            this.vueModel = vueModel;
            this.vueModelLocations = vueModelLocations;
            this.DataContext = this.vueModel;
            this.Height = 80;
            InitializeComponent();
            this.vueModel.PropertyChanged += ImmeubleVM_PropertyChanged;
            this.ListeAppartements.Visibility = Visibility.Collapsed;
            if (num % 2 == 0) this.Background = new SolidColorBrush(Colors.AliceBlue);


            // Locataires
            this.VueModelLocataires = VueModelLocataires;

            // Propriétaire
            this.VueModelProprietaire = VueModelProprietaire;
        }

        private void MAJListeAppartements()
        {
            this.ListeAppartements.Children.Clear();
            this.Height = 80;
            foreach (LocationVM appartement in this.vueModel.ListeDesAppartements)
            {
                this.ListeAppartements.Children.Add(new VueAppartement(appartement, this.vueModel, this.VueModelProprietaire, this.VueModelLocataires));
                this.ListeAppartements.Visibility = Visibility.Collapsed;
            }
            if (this.ListeAppartements.Children.Count == 0) this.AfficherAppartement.Visibility = Visibility.Collapsed;
            else this.AfficherAppartement.Visibility = Visibility.Visible;
        }

        private void ImmeubleVM_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ListeDesAppartements")
            {
                this.MAJListeAppartements();
            }

        }

        private void AjoutAppartement_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            foreach (ILocationVM loca in this.vueModelLocations.ListeDesLocations) if (loca is Location) if (loca.Id == id) id++;
            LocationVM location = new LocationVM(new Location(id, vueModel.Nom, vueModel.Adresse, vueModel.ComplementAdresse, vueModel.CodePostal, vueModel.Ville, vueModel.Pays, this.vueModel.Id, VueModelProprietaire.Id, false, false, "", 0, 0, false, false, 0));
            FenetreLocations fen = new FenetreLocations(location);
            if (fen.ShowDialog() == true)
            {
                this.vueModel.AjouterAppartement(location);
            }
        }

        private void ModifierImmeuble_Click(object sender, RoutedEventArgs e)
        {
            ImmeubleVM immeubleCopie = (ImmeubleVM)vueModel.Clone();
            FenetreImmeuble fen = new FenetreImmeuble(immeubleCopie);
            if (fen.ShowDialog() == true)
            {
                vueModelLocations.ActualiserImmeuble(immeubleCopie);
            }
        }

        private async void SupprimerImmeuble_Click(object sender, RoutedEventArgs e)
        {
            foreach (LocationVM locationVM in this.vueModel.ListeDesAppartements)
            {
                await new LocationDAO().RetirerLocation((Location)locationVM.Model);
            }
            this.vueModelLocations.RetirerImmeuble(vueModel);
        }

        private void AfficherLocation_Click(object sender, RoutedEventArgs e)
        {
            if (this.ListeAppartements.Visibility == Visibility.Visible)
            {
                this.ListeAppartements.Visibility = Visibility.Collapsed;
                this.Height = 80;
            }
            else
            {
                this.ListeAppartements.Visibility = this.ListeAppartements.Visibility = Visibility.Visible;
                this.Height += this.ListeAppartements.Children.Count * 80;
            }
        }
    }
}
