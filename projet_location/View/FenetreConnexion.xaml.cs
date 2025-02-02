using projet_location.Model;
using projet_location.ViewModel;

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace projet_location.View
{
    /// <summary>
    /// Logique d'interaction pour FenetreConnexion.xaml
    /// </summary>
    public partial class FenetreConnexion : Window
    {

        /// <summary>
        /// Constructeur de la fenetre de connexion
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public FenetreConnexion()
        {
            InitializeComponent();

            //Empeche le redimensionnement de la age
            this.MinHeight = this.Height;
            this.MaxHeight = this.Height;

            this.MinWidth = this.Width;
            this.MaxWidth = this.Width;
        }

        private void ChangerLangueEn_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            FenetreConnexion window = new FenetreConnexion
            {
                WindowStyle = this.WindowStyle,
                WindowState = this.WindowState
            };
            this.Close();
            window.Show();
            window.Francais.Visibility = Visibility.Visible;
            window.Anglais.Visibility = Visibility.Hidden;
        }

        private void ChangerLangueFr_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");
            FenetreConnexion window = new FenetreConnexion
            {
                WindowStyle = this.WindowStyle,
                WindowState = this.WindowState
            };
            this.Close();
            window.Show();
            window.Francais.Visibility = Visibility.Hidden;
            window.Anglais.Visibility = Visibility.Visible;
        }

        private void Sinscrire_Click(object sender, RoutedEventArgs e)
        {
            FenetreInscription window = new FenetreInscription();
            window.Show();
            this.Close();
        }

        private async void SeConnecter_Click(object sender, RoutedEventArgs e)
        {
            Proprietaire proprioNull = new Proprietaire(1, "", "", "", false, "");
            ProprietaireVM proprio = new ProprietaireVM(proprioNull);

            MainWindow window = new MainWindow(proprio);
            window.Show();
            this.Close();
            /*
            if (MailProprietaire.Text != "" && MDPProprietaire.Password != "")
            {
                try
                {
                    await proprio.DefinirProprietaireParMailMdp(MailProprietaire.Text, MDPProprietaire.Password);
                    if (proprio == null || proprio.Equals(proprioNull) || proprio.Id == -1) throw new Exception("Le proprietaire n'a pas été trouvé");
                    else
                    {
                        MainWindow window = new MainWindow(proprio);
                        window.Show();
                        this.Close();
                    }

                }
                catch (Exception)
                {
                    ErreurConnexion.Visibility = Visibility.Visible;
                    CacherErreur();
                }
            }
            else
            {
                ErreurConnexion.Visibility = Visibility.Visible;
                CacherErreur();
            }
            */
        }

        private async void CacherErreur()
        {
            await this.Dispatcher.Invoke(async () =>
            {
                await Task.Delay(3000);
                ErreurConnexion.Visibility = Visibility.Hidden;
            });
        }


        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SeConnecter_Click(sender, e);
            }
        }
    }
}
