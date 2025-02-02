using LiveCharts.Wpf;
using LiveCharts;
using projet_location.Model;
using projet_location.View;
using projet_location.View.components;
using projet_location.ViewModel;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Runtime.Serialization;
using LiveCharts.Definitions.Charts;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace projet_location
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LocationsVM locationsVM;
        private LocatairesVM locatairesVM;
        private ProprietaireVM proprietaireVM;
        private BauxVM bauxVM;


        /// <summary>
        /// constructeur de la MainWindow
        /// </summary>
        /// <param name="proprietaireVM">un proprietaire</param>
        public MainWindow(ProprietaireVM proprietaireVM)
        {
            
            //Pour pouvoir faire les recherches
            this.proprietaireVM = proprietaireVM;
            InitializeComponent();

            // Locations
            this.locationsVM = new LocationsVM(new Model.Locations());
            this.locationsVM.PropertyChanged += LocationsVM_PropertyChanged;
            this.locationsVM.DefinirListeLocations(proprietaireVM.Model.Id);

            // Locataires
            this.locatairesVM = new LocatairesVM(new Model.Locataires());
            this.locatairesVM.PropertyChanged += LocatairesVM_PropertyChanged;
            this.locatairesVM.DefinirListeLocataires(proprietaireVM.Model.Id);

            // Baux
            this.bauxVM = new BauxVM(new Model.Baux());
            this.bauxVM.PropertyChanged += BauxVM_PropertyChanged;
            this.bauxVM.DefinirListeDesBaux(proprietaireVM.Model.Id);

            InitChart();
        }

        #region -------- Accueil --------

        public void InitChart()
        {
            int Nbpayer = 0;
            int Nbimpayer = 0;
            foreach(BailVM bail in bauxVM.ListeDesBaux)
            {
                if(bail.Apaye == true) { Nbpayer++; }
                else { Nbimpayer++; }
            }
            Payer.Values = new ChartValues<double>{ Nbpayer };
            Impayer.Values = new ChartValues<double> { Nbimpayer };
        }

        private void MAJImpayer()
        {
            float argent = 0;
            this.ListImpayer.Children.Clear();
            foreach (BailVM bail in this.bauxVM.ListeDesBaux)
            {
                if(bail.Apaye == false)
                { 
                    this.ListImpayer.Children.Add(new VueBail(this.ListeBail.Children.Count, this.proprietaireVM, this.bauxVM, bail, locatairesVM, locationsVM));
                }
                else 
                {
                    this.ListImpayer.Children.Remove(new VueBail(this.ListeBail.Children.Count, this.proprietaireVM, this.bauxVM, bail, locatairesVM, locationsVM));
                    argent += bail.LoyerHC; 
                }
                    
            }
            Gain.Content = argent;
        }

        #endregion

        #region -------- Paramètres --------

        /// <summary>
        /// Méthode privé ButtonLangueEN_Click permettant de changer la langue du logiciel en Anglais.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Lakhdar Gibril</author>
        private void ButtonLangueEN_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");

            MainWindow window = new MainWindow(proprietaireVM)
            {
                WindowStyle = this.WindowStyle,
                WindowState = this.WindowState
            };
            this.Close();
            window.Show();
        }

        /// <summary>
        /// Méthode privé ButtonLangueFR_Click permettant de changer la langue du logiciel en Français.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Lakhdar Gibril</author>
        private void ButtonLangueFR_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");

            MainWindow window = new MainWindow(proprietaireVM)
            {
                WindowStyle = this.WindowStyle,
                WindowState = this.WindowState
            };
            this.Close();
            window.Show();
        }


        private void MonCompte_Click(object sender, RoutedEventArgs e)
        {
            ProprietaireVM proprietaireVMCopie = (ProprietaireVM)this.proprietaireVM.Clone();
            FenetreModificationCompte fen = new FenetreModificationCompte(proprietaireVMCopie);
            if (fen.ShowDialog() == true)
            {
                this.proprietaireVM.ModifierUnProprietaire(proprietaireVMCopie);
            }
        }

        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            FenetreConnexion connexion = new FenetreConnexion();
            connexion.Show();
            this.Close();

        }
        #endregion

        #region -------- Locataires --------

        /// <author>Lakhdar Gibril</author>
        private void MAJLocataire()
        {
            this.ListeLocataires.Children.Clear();
            foreach (LocataireVM locataire in this.locatairesVM.ListeDesLocataires)
            {
                this.ListeLocataires.Children.Add(new VueLocataire(this.ListeLocataires.Children.Count, locataire, this.locatairesVM, this.proprietaireVM, this.locationsVM));
            }
        }

        /// <author>Lakhdar Gibril</author>
        private void LocatairesVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ListeDesLocataires")
            {
                this.MAJLocataire();
            }
        }

        ///<author>Lakhdar Gibril</author>
        private void AjouterUnLocataire_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            foreach (LocataireVM locataires in this.locatairesVM.ListeDesLocataires) if (locataires.Id == id) id++;
            LocataireVM locataire = new LocataireVM(new Model.Locataire(id, "", "", DateTime.Now, "", "", "", "", 0, "", "", 0, 0, 0, 0, proprietaireVM.Id));
            FenetreLocataire fen = new FenetreLocataire(locataire);
            if (fen.ShowDialog() == true)
            {
                this.locatairesVM.AjouterLocataire(locataire);
            }
        }

        #endregion

        #region -------- Locations --------

        private void MAJLocations()
        {
            this.ListeLocations.Children.Clear();
            foreach (ILocationVM location in this.locationsVM.ListeDesLocations)
            {
                if (location is LocationVM loca)
                    if (loca.IdImmeuble == 0)
                        this.ListeLocations.Children.Add(new VueLocation(this.ListeLocations.Children.Count, loca, this.locationsVM, this.proprietaireVM, this.locatairesVM));
                if (location is ImmeubleVM immeuble)
                    this.ListeLocations.Children.Add(new VueImmeuble(this.ListeLocations.Children.Count, immeuble, this.locationsVM, this.proprietaireVM, this.locatairesVM));

            }
        }

        private void LocationsVM_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ListeDesLocations")
            {
                this.MAJLocations();
            }

        }
        private void AjouterUneLocation_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            foreach (ILocationVM loca in this.locationsVM.ListeDesLocations) if (loca is Location) if (loca.Id == id) id++;
            LocationVM location = new LocationVM(new Location(id, "", "", "", "", "", "", 0, proprietaireVM.Id, false, false, "", 0, 0, false, false, 0));
            FenetreLocations fen = new FenetreLocations(location);
            if (fen.ShowDialog() == true)
            {
                this.locationsVM.AjouterLocation(location);
            }
        }
        #endregion

        private void AjouterUnImmeuble_Click(object sender, RoutedEventArgs e)
        {
            int id = 1;
            foreach (ILocationVM loca in this.locationsVM.ListeDesLocations)
            {
                if (loca is ImmeubleVM) if (loca.Id == id) id++;
            }
            ImmeubleVM immeuble = new ImmeubleVM(new Model.Immeuble(id, "", "", "", "", "", "", proprietaireVM.Id));
            FenetreImmeuble fen = new FenetreImmeuble(immeuble);
            if (fen.ShowDialog() == true)
            {
                this.locationsVM.AjouterLocation(immeuble);
            }
        }

        #region  -------- Bail --------
        private void MAJBaux()
        {
            this.ListeBail.Children.Clear();
            foreach (BailVM bail in this.bauxVM.ListeDesBaux)
            {
                this.ListeBail.Children.Add(new VueBail(this.ListeBail.Children.Count, this.proprietaireVM, this.bauxVM, bail, locatairesVM, locationsVM));
            }
        }

        private void BauxVM_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ListeDesBaux")
            {
                this.MAJBaux();
                this.MAJImpayer();
                InitChart();
            }
        }

        private void AjouterUnBail_Click(object sender, RoutedEventArgs e)
        {
            int identifiant = 0;
            foreach (BailVM b in this.bauxVM.ListeDesBaux) if (b.Identifiant == identifiant) identifiant++;
            BailVM bail = new BailVM(new Model.Bail(-1,"",-1,proprietaireVM.Id,identifiant,DateTime.Now,DateTime.Now,"",0,0,"","",false));
            FenetreBail fen = new FenetreBail(bail, locatairesVM, locationsVM, bauxVM);
            if (fen.ShowDialog() == true)
            {
                this.bauxVM.AjouterBail(bail);
            }
        }

        private void RemettreZero_Click(object sender, RoutedEventArgs e)
        {
            foreach (BailVM b in this.bauxVM.ListeDesBaux) 
            {
                b.Apaye = false; 
                this.bauxVM.ModifierBail(b);
            }
        }
        #endregion
    }
}
