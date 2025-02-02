using projet_location.ViewModel;

using System;
using System.Windows;

namespace projet_location.View
{
    /// <summary>
    /// Logique d'interaction pour FenetreCoonexion.xaml
    /// </summary>
    public partial class FenetreInscription : Window
    {
        ProprietaireVM proprietaireVM;

        /// <summary>
        /// Constructeur de la fenetre d'inscription
        /// </summary>
        public FenetreInscription()
        {
            proprietaireVM = new ProprietaireVM(new Model.Proprietaire(0, "", "", "", false, ""));
            this.DataContext = this.proprietaireVM;
            InitializeComponent();

            //Empeche le redimensionnement de la age
            this.MinHeight = this.Height;
            this.MaxHeight = this.Height;

            this.MinWidth = this.Width;
            this.MaxWidth = this.Width;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            FenetreConnexion window = new FenetreConnexion();
            window.Show();
            this.Close();
        }

        private void Sinscrire_Click(object sender, RoutedEventArgs e)
        {
            if (NomProprietaire.Text == "")
            {
                MessageBox.Show("Veuillez rentrer un nom");
            }
           
            else if(MailProprietaire.Text == "")
            {
                MessageBox.Show("Veuillez rentrer un mail");
            }
            else if (MDPProprietaire.Password == "")
            {
                MessageBox.Show("Veuillez rentrer un mot de passe");
            }
            else if(AdresseProprietaire.Text == "")
            {
                MessageBox.Show("Veuillez rentrer une adresse");
            }
            else
            {
                this.proprietaireVM.Model.MotDePasse = MDPProprietaire.Password;
                this.proprietaireVM.Model.Mail = MailProprietaire.Text;
                this.proprietaireVM.Model.Id = 1;
                try
                {
                    this.proprietaireVM.AjouterCeProprietaire();
                    FenetreConnexion window = new FenetreConnexion();
                    window.Show();
                    this.Close();
                }
                catch (Exception)
                {
                    ErreurInscription.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
