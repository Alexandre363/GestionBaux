using projet_location.ViewModel;

using System.Windows;

namespace projet_location.View
{
    /// <summary>
    /// Logique d'interaction pour FenetreLocataire.xaml
    /// </summary>
    /// <author>Hadrien Bourmault</author>
    public partial class FenetreLocataire : Window
    {
        #region ------------ Attribut ------------
        private LocataireVM locataireVueModel;
        #endregion

        #region ------------ Constructeur ------------
        /// <summary>
        /// Constructeur de la classe 
        /// </summary>
        /// <param name="locataireVM">Modèle utilisé pour la page</param>
        /// <author>Lakhdar Gibril</author>
        public FenetreLocataire(LocataireVM locataireVM)
        {
            this.locataireVueModel = locataireVM;
            this.DataContext = this.locataireVueModel;
            InitializeComponent();

            //Empeche le redimensionnement de la age
            this.MinHeight = this.Height;
            this.MaxHeight = this.Height;

            this.MinWidth = this.Width;
            this.MaxWidth = this.Width;
        }
        #endregion

        #region ----------- Méthodes privées ------------
        private void ConfirmerAjout(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void AnnulerAjout(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        #endregion
    }
}
