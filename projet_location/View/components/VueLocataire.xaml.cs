using projet_location.Model;
using projet_location.ViewModel;

using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace projet_location.View.components
{
    /// <summary>
    /// Logique d'interaction pour VueLocataire.xaml
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    public partial class VueLocataire : UserControl
    {

        private ProprietaireVM vueModelProprietaire;
        private LocationsVM vueModelLocation;
        private LocatairesVM vueModelLocataires;
        private LocataireVM vueModel;

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="vueModel"></param>
        /// <param name="vueModelLocataires"></param>
        /// <author>Lakhdar Gibril</author>
        public VueLocataire(int num, LocataireVM vueModel, LocatairesVM vueModelLocataires, ProprietaireVM vueModelProprietaire, LocationsVM vueModelLocation)
        {
            this.vueModel = vueModel;
            this.vueModelLocataires = vueModelLocataires;
            this.DataContext = this.vueModel;
            this.Height = 80;
            InitializeComponent();
            if (num % 2 == 0) this.Background = new SolidColorBrush(Colors.AliceBlue);

            // Locations
            this.vueModelLocation = vueModelLocation;

            // Propriétaire
            this.vueModelProprietaire = vueModelProprietaire;

        }

        private void SupprimerItem_Click(object sender, RoutedEventArgs e)
        {
            this.vueModelLocataires.RetirerLocataire(this.vueModel);
        }

        private void ModifierItem_Click(object sender, RoutedEventArgs e)
        {
            LocataireVM LocataireCopie = (LocataireVM)vueModel.Clone();
            FenetreLocataire fen = new FenetreLocataire(LocataireCopie);
            if (fen.ShowDialog() == true)
            {
                vueModelLocataires.ActualiserLocataire(LocataireCopie);
                this.vueModelLocataires.DefinirListeLocataires(vueModel.IdProprietaire);
            }
        }

        private void AjouterLocation_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            foreach (LocationVM loca in vueModelLocation.ListeDesLocations.Cast<LocationVM>()) if (loca.Id == id) id++;
            LocationVM location = new LocationVM(new Location(id, "", "", "", "", "", "", 0, vueModelProprietaire.Id, false, false, "", 0, 0, false, false, 0));
            FenetreLocations fen = new FenetreLocations(location);
            if (fen.ShowDialog() == true)
            {
                this.vueModelLocation.AjouterLocation(location);
            }
        }
    }
}
