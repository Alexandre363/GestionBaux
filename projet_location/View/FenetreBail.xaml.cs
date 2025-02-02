using projet_location.Model.Res;
using projet_location.ViewModel;
using System;
using System.Windows;

namespace projet_location.View
{
    /// <summary>
    /// Logique d'interaction pour FenetreBail.xaml
    /// </summary>
    public partial class FenetreBail : Window
    {
        #region ------------ Attribut ------------
        private BailVM bailVueModel;
        private int jour;
        private int mois;
        #endregion

        #region ------------ Constructeur ------------
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public FenetreBail(BailVM bailVM, LocatairesVM locatairesVM, LocationsVM locationsVM, BauxVM bauxVM)
        {
            int cpt = 0;
            this.bailVueModel = bailVM;
            this.DataContext = this.bailVueModel;
            InitializeComponent();
            //Empeche le redimensionnement de la page
            this.MinHeight = this.Height;
            this.MaxHeight = this.Height;

            this.MinWidth = this.Width;
            this.MaxWidth = this.Width;
            foreach (LocataireVM loc in locatairesVM.ListeDesLocataires)
            {
                this.Locataire.Items.Add(loc);
                if (loc.Id == bailVM.IdLocataire)
                {
                    Locataire.SelectedItem = loc;
                }
            }
            foreach (ILocationVM loc in locationsVM.ListeDesLocations)
            {
                if (loc is LocationVM lo) 
                {
                    foreach (BailVM bail in bauxVM.ListeDesBaux) if (bail.IdLocation == lo.Id) cpt++;
                    if (lo.NbCouchages > cpt)
                        this.Location.Items.Add(lo);
                    if (lo.Id == bailVM.IdLocation)
                    {
                        Location.SelectedItem = lo;
                    }
                    cpt = 0;
                }
            }
            

        }
        #endregion

        #region ----------- Méthodes privées ------------
        private void ConfirmerAjout(object sender, RoutedEventArgs e)
        {
            bool sortie = true;
            LocataireVM locataire = Locataire.SelectedItem as LocataireVM;
            if (locataire != null)
            {
                bailVueModel.IdLocataire = locataire.Id;
            }
            else
            {
                MessageBox.Show(Strings.ErreurLocataire);
                sortie = false;
            }
            LocationVM location = Location.SelectedItem as LocationVM;

            if (location != null)
            {
                bailVueModel.IdLocation = location.Id;
            }
            else
            {
                MessageBox.Show(Strings.ErreurLocation);
                sortie = false;
            }

            try
            {
                if (Convert.ToInt32(DatePayement.Text.ToString()) < 1 || Convert.ToInt32(DatePayement.Text.ToString()) > 31)
                {
                    sortie = false;
                }
            }
            catch 
            {
                MessageBox.Show(Strings.ErreurDatePayement);
                sortie = false;
            }

            try
            {
                char[] verif = DateRevalorisation.Text.ToCharArray();
                int jour = Convert.ToInt32(verif[0].ToString() + verif[1].ToString());
                int mois = Convert.ToInt32(verif[3].ToString() + verif[4].ToString());
                if (jour < 1 || jour > 31 && mois < 1 || mois > 12)
                {
                    MessageBox.Show(Strings.ErreurDate);
                    sortie = false;
                }
            }
            catch
            {
                MessageBox.Show(Strings.ErreurDateRevalorisation);
                sortie = false;
            }




            if (sortie)
            {
                DialogResult = true;
            }
        }
        private void AnnulerAjout(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        #endregion
    }
}
