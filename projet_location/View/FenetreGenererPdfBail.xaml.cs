using projet_location.ViewModel;
using Aspose.Pdf;
using System;
using System.Windows;
using System.Windows.Input;
using System.Reflection.Metadata;
using Ookii.Dialogs.Wpf;
using System.Globalization;
using System.Threading;

namespace projet_location.View
{
    /// <summary>
    /// Logique d'interaction pour FenetreGenererPdfBail.xaml
    /// </summary>
    public partial class FenetreGenererPdfBail : Window
    {

        private BailVM model;
        private ProprietaireVM proprietaireVM;
        private LocataireVM locataireVM;
        private LocationVM locationVM;

        /// <summary>
        /// Constructeur de la fenetre de génération de pdf pour les bails
        /// </summary>
        public FenetreGenererPdfBail(BailVM model, ProprietaireVM proprietaireVM, LocataireVM locataireVM, LocationVM locationVM)
        {
            this.model = model;
            this.proprietaireVM = proprietaireVM;
            this.locataireVM = locataireVM;
            this.locationVM = locationVM;
            InitializeComponent();
        }

        #region ---------- Méthodes -------------
        /// <summary>
        /// Permet de générer un fichier pdf de bail
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public void GenererPdfBail(object sender, RoutedEventArgs e)
        {
            CultureInfo cultureCourante = CultureInfo.CurrentUICulture;

            if (cultureCourante.Name.Equals("fr-FR")) 
            {
                this.PdfEnFr();
                MessageBox.Show("Votre fichier a bien été créer");
            }
            if (cultureCourante.Name.Equals("en-GB"))
            {
                this.PdfEnEn();
                MessageBox.Show("Your file has been created");
            }
         
        }

        private void PdfEnFr()
        {
            //Création du document et de pages
            Aspose.Pdf.Document document = new Aspose.Pdf.Document();
            Aspose.Pdf.Page page = document.Pages.Add();


            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("BAIL PROFESSIONNEL \n"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("DESIGNATION DES PARTIES"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Entre les soussignés :"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("D'une part,"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment($"1. Le(s) Bailleur(s) \n {proprietaireVM.Nom} deumeurant à {proprietaireVM.Adresse}; \n Désigné(s) ci-après le Bailleur \n"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Et d'autres part,"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment($"2. Le(s) Preneur(s) \n {locataireVM.Nom} {locataireVM.Prenom}, né(e) le {locataireVM.DateDeNaissance}, de nationalité {locataireVM.Nationalite}; \n désigné(s) ci-après le Preneur"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Le Bailleur et le Preneur étant ci-après désignés, ensemble les Parties \n"));

            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("ARTICLE 1 - DESIGNATION"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment($"Le présent bail porte sur des locaux ('Les Lieux loués') dépendant d'une location situé {locationVM.Adresse} {locationVM.ComplementAdresse},{locationVM.CodePostal} ,nommée {locationVM.Nom}, comprenant : \n {locationVM.NbPiecesPrincipales} pièces principales, d'une superficie de {locationVM.SurfaceHabitable} mètre carré \n"));

            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("ARTICLE 2 - DUREE"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment($"Le présent bail débutera à partir du {model.DateDebut}, et aura pour durée {model.Duree} mois. Ce dernier sera a payer tout les {model.DatePayement} des mois suivants avant la fin du bail présent."));

            document.Save(Convert.ToString(this.CheminAcces.Text) + '/' + Convert.ToString(this.nomFichier.Text) + ".pdf");
        }

        private void PdfEnEn()
        {
            //Création du document et de pages
            Aspose.Pdf.Document document = new Aspose.Pdf.Document();
            Aspose.Pdf.Page page = document.Pages.Add();


            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("PROFESSIONAL LEASE \n"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("PARTIES APPOINTMENT"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Between the undersigned:"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("On the one hand,"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment($"1. The Landlord(s) \n {proprietaireVM.Nom} mourning at {proprietaireVM.Adresse}; \n Designated hereinafter the Landlord \n"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Et In the other one hand,"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment($"2.The lessee(s) \n {locataireVM.Nom} {locataireVM.Prenom}, born the {locataireVM.DateDeNaissance}, of nationality {locataireVM.Nationalite}; \n Designated hereinafter the Lessee"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("The Landlord and The lessee hereinafter referred to, together the Parties \n"));

            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("ARTICLE 1 - DESIGNATION"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment($"This lease concerns premises ('Leased Premises') dependent on a rental located {locationVM.Adresse} {locationVM.ComplementAdresse},{locationVM.CodePostal} ,named {locationVM.Nom}, including : \n {locationVM.NbPiecesPrincipales} main rooms, with an area of {locationVM.SurfaceHabitable} square meter \n"));

            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("ARTICLE 2 - PERIOD"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment($"This lease will begin on {model.DateDebut}, and will last {model.Duree} month. The latter will have to pay all the {model.DatePayement} months before the end of the current lease."));

            document.Save(Convert.ToString(this.CheminAcces.Text) + '/' + Convert.ToString(this.nomFichier.Text) + ".pdf");
        }

        private void ParcourirDossier_Click(object sender, RoutedEventArgs e)
        {
            // Créer une instance de VistaFolderBrowserDialog (Ookii.Dialogs)
            VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
            // Afficher la boîte de dialogue et récupérer le résultat
            bool? result = folderBrowserDialog.ShowDialog(this);
            folderBrowserDialog.Description = "Sélectionner un dossier";

            //Ajout des informations nécessaires dans le document pdf
           
            // Vérifier si l'utilisateur a sélectionné un dossier
            if (result == true)
            {
                // Récupérer le chemin d'accès du dossier sélectionné
                string selectedFolderPath = folderBrowserDialog.SelectedPath;

                // Utiliser le chemin d'accès comme nécessaire
                CheminAcces.Text = selectedFolderPath;
            }
        }
        #endregion
    }
}
