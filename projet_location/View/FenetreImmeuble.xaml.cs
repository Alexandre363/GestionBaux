using projet_location.ViewModel;

using System.Windows;

namespace projet_location.View
{
    /// <summary>
    /// Logique d'interaction pour FenetreLocations.xaml
    /// </summary>
    /// <author>Hadrien Bourmault</author>
    public partial class FenetreImmeuble : Window
    {
        private ImmeubleVM ImmeubleVueModel;

        /// <summary>
        /// Constructeur de la fenetre de creation et de modification d'un immeuble
        /// </summary>
        /// <param name="ImmeubleVueModel">un immeuble</param>
        /// <author>Julien Guyenet</author>
        public FenetreImmeuble(ImmeubleVM ImmeubleVueModel)
        {
            this.ImmeubleVueModel = ImmeubleVueModel;
            this.DataContext = this.ImmeubleVueModel;
            InitializeComponent();
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

        private void ValiderAjout(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
