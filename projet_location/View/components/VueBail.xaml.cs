using projet_location.View.converter;
using projet_location.ViewModel;

using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace projet_location.View.components
{
    /// <summary>
    /// Logique d'interaction pour VueBail.xaml
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    public partial class VueBail : UserControl
    {
        private ProprietaireVM vueModelProprietaire;
        private BauxVM vueModelBaux;
        private BailVM model;
        private LocatairesVM locatairesVM;
        private LocataireVM? locataireVM;
        private LocationsVM locationsVM;
        private LocationVM? locationVM;

        /// <summary>
        /// Constructeur de la classe VueBail
        /// </summary>
        /// <param name="num"></param>
        /// <param name="vueModelProprietaire"></param>
        /// <param name="vueModelBaux"></param>
        /// <param name="model"></param>
        public VueBail(int num, ProprietaireVM vueModelProprietaire, BauxVM vueModelBaux, BailVM model, LocatairesVM locatairesVM, LocationsVM locationsVM)
        {
            this.vueModelProprietaire = vueModelProprietaire;
            this.vueModelBaux = vueModelBaux;
            this.model = model;
            this.DataContext = this.model;
            this.Height = 80;
            this.locatairesVM = locatairesVM;
            this.locationsVM = locationsVM;
            foreach (LocataireVM loca in locatairesVM.ListeDesLocataires)
            {
                if (loca.Id == model.IdLocataire) locataireVM = loca;
            }
            foreach (ILocationVM loca in locationsVM.ListeDesLocations)
            {
                if (loca is LocationVM)
                {
                    if (loca.Id == model.IdLocation) locationVM = (LocationVM)loca;
                }
                
            }
            InitializeComponent();
            if (num % 2 == 0) this.Background = new SolidColorBrush(Colors.AliceBlue);
            if (model.Apaye) this.PayerItem.Visibility = Visibility.Collapsed;
            else this.PayerItem.Visibility = Visibility.Visible; 
        }

        private void VueBail_Loaded(object sender, RoutedEventArgs e)
        {
            nomBail.Text = this.model.Nom;
            loyer.Text = this.model.LoyerHC.ToString("C", CultureInfo.CurrentUICulture);
        }


        private void SupprimerItem_Click(object sender, RoutedEventArgs e)
        {
            this.vueModelBaux.AnnulerBail(this.model);
        }

        private void ModifierItem_Click(object sender, RoutedEventArgs e)
        {
            BailVM bailCopie = (BailVM)this.model.Clone();
            FenetreBail fenetre = new FenetreBail(bailCopie, locatairesVM, locationsVM, vueModelBaux);
            if (fenetre.ShowDialog() == true)
            {
                this.vueModelBaux.DefinirListeDesBaux(this.vueModelProprietaire.Id);
                this.vueModelBaux.ModifierBail(bailCopie);
            }
        }

        private void GenererPdfBail_Click(object sender, RoutedEventArgs e)
        {
            if (locataireVM == null || locationVM == null) { MessageBox.Show("Locataire ou location non définie"); }
            else
            {
                FenetreGenererPdfBail window = new FenetreGenererPdfBail(model, vueModelProprietaire, locataireVM, locationVM);
                window.Show();
            }
        }

        private void PayerItem_Click(object sender, RoutedEventArgs e)
        {
            BailVM bailCopie = (BailVM)this.model.Clone();
            bailCopie.Apaye = true;
            
            this.vueModelBaux.DefinirListeDesBaux(this.vueModelProprietaire.Id);
            this.vueModelBaux.ModifierBail(bailCopie);
            
        }
    }
}
