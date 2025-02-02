using projet_location.ViewModel;

using System.Windows;

namespace projet_location.View
{
    /// <summary>
    /// Logique d'interaction pour FenetreModificationCompte.xaml
    /// </summary>
    public partial class FenetreModificationCompte : Window
    {
        ProprietaireVM proprietaireVM;

        /// <summary>
        /// constructeur de la fenetre de modification de compte
        /// </summary>
        /// <param name="proprietaireVM">un proprietaire</param>
        public FenetreModificationCompte(ProprietaireVM proprietaireVM)
        {
            this.proprietaireVM = proprietaireVM;
            this.DataContext = proprietaireVM.Model;
            InitializeComponent();

            //Empeche le redimensionnement de la age
            this.MinHeight = this.Height;
            this.MaxHeight = this.Height;

            this.MinWidth = this.Width;
            this.MaxWidth = this.Width;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            proprietaireVM.Model.Nom = NomProprietaire.Text;
            if (MDPProprietaire.Password != "") proprietaireVM.Model.MotDePasse = MDPProprietaire.Password;
            proprietaireVM.Model.Mail = MailProprietaire.Text;
            this.proprietaireVM.ActualiserCeProprietaireId(proprietaireVM.Model);
            DialogResult = true;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
