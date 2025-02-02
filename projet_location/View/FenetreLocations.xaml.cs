using Microsoft.VisualBasic;
using projet_location.Model.Res;
using Microsoft.VisualBasic.Logging;

using projet_location.Data;
using projet_location.Model;
using projet_location.ViewModel;

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace projet_location.View
{
    /// <summary>
    /// Logique d'interaction pour FenetreLocations.xaml
    /// </summary>
    /// <author>Hadrien Bourmault</author>
    public partial class FenetreLocations : Window
    {
        private LocationVM locationVM;

        /// <summary>
        /// Constructeur de la fenetre de creation et de modification des locations
        /// </summary>
        /// <param name="VueModelLocation">une location</param>
        /// <author>Julien Guyenet</author>
        public FenetreLocations(LocationVM VueModelLocation)
        {
            this.locationVM = VueModelLocation;
            this.DataContext = this.locationVM;
            InitializeComponent();
            if (locationVM.IdImmeuble == 0) this.EstPasDansImmeuble.IsChecked = true;
            else this.EstDansImmeuble.IsChecked = true;

            //Empeche le redimensionnement de la page
            this.MinHeight = this.Height;
            this.MaxHeight = this.Height;

            this.MinWidth = this.Width;
            this.MaxWidth = this.Width;

            AffichageImmeuble(locationVM.IdProprietaire);
        }

        private async void AffichageImmeuble(int idProprietaire)
        {
            IEnumerable<Immeuble> immeubles = await new ImmeubleDAO().ListerImmeuble(locationVM.IdProprietaire);
            foreach (Immeuble immeuble in immeubles.ToList())
            {
                ImmeubleVM immeubleVM= new ImmeubleVM(immeuble);
                this.Immeubles.Items.Add(immeubleVM);
                if (immeubleVM.Id == locationVM.IdImmeuble)
                {
                    Immeubles.SelectedItem = immeubleVM;
                }
            }
        }

        /// <summary>
        /// Ferme la popup en cas d'annulation de l'ajout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Hadrien Bourmault</author>
        private void AnnulerAjout(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ValiderAjoutLocation(object sender, RoutedEventArgs e)
        {
            if (Immeubles.SelectedItem != null)
            {
                ImmeubleVM immeubleVM = Immeubles.SelectedItem as ImmeubleVM;
                locationVM.IdImmeuble = immeubleVM.Id;
            }
            if (NomLocation.Text == "")
            {
                MessageBox.Show(projet_location.Model.Res.Strings.ErreurNom);
            }
            else if (AdresseLocation.Text == "")
            {
                MessageBox.Show(projet_location.Model.Res.Strings.ErreurAdresse);
            }
            else if (ComplementAdresseLocation.Text == "")
            {
                MessageBox.Show(projet_location.Model.Res.Strings.ErreurComplementAdresse);
            }
            else if (CodePostalLocation.Text == "")
            {
                MessageBox.Show(projet_location.Model.Res.Strings.ErreurCodePostal);
            }
            else if (VilleLocation.Text == "")
            {
                MessageBox.Show(projet_location.Model.Res.Strings.ErreurVille);
            }
            else if (PaysLocation.Text == "")
            {
                MessageBox.Show(projet_location.Model.Res.Strings.ErreurPays);
            }
            else
            {
                DialogResult = true;
            }
        }

        private void EstDansImmeuble_Checked(object sender, RoutedEventArgs e)
        {
            Immeubles.IsEnabled = true;
        }

        private async void EstPasDansImmeuble_Checked(object sender, RoutedEventArgs e)
        {
            Immeubles.IsEnabled = false;
            locationVM.IdImmeuble = 0;
            await new LocationDAO().ModifierLocation((Location)locationVM.Model);

        }
    }
}
