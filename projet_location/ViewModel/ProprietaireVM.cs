using projet_location.Data;
using projet_location.Model;

using System.ComponentModel;
using System.Threading.Tasks;

namespace projet_location.ViewModel
{
    /// <summary>
    /// Vue modèle d'un propriétaire
    /// </summary>
    /// <author>Hadrien Bourmault</author>
    public class ProprietaireVM : INotifyPropertyChanged, IProprietaire
    {
        #region -------------- Attributs --------------
        private Proprietaire model;
        #endregion

        #region -------------- Propriétés --------------

        /// <summary>
        /// Renvoie ou modifie l'identifiant du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int Id
        {
            get => this.model.Id;
            set => this.model.Id = value;
        }

        /// <summary>
        /// Renvoie ou modifie le mot de passe du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public string MotDePasse
        {
            get => this.model.MotDePasse;
            set => this.model.MotDePasse = value;
        }

        /// <summary>
        /// Renvoie ou modifie le nom du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public string Nom
        {
            get => this.model.Nom;
            set => this.model.Nom = value;
        }

        /// <summary>
        /// Renvoie ou modifie le mail du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public string Mail
        {
            get => this.model.Mail;
            set => this.model.Mail = value;
        }

        /// <summary>
        /// Renvoie ou modifie le type de personne du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public bool TypePersonne
        {
            get => this.model.TypePersonne;
            set => this.model.TypePersonne = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'adresse du modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public string Adresse
        {
            get => this.model.Adresse;
            set => this.model.Adresse = value;
        }

        public Proprietaire Model { get => this.model; }

        #endregion

        #region ------------- Constructeurs -------------

        public ProprietaireVM(Proprietaire model)
        {
            this.model = model;
        }

        #endregion

        public async void AjouterCeProprietaire()
        {
            await new ProprietaireDAO().AjouterProprietaire(this.Model);
        }

        public async void ActualiserCeProprietaireId(Proprietaire proprietaire)
        {
            await new ProprietaireDAO().ModifierProprietaire(proprietaire);
        }

        public async void ModifierUnProprietaire(ProprietaireVM proprietaireVM)
        {
            await new ProprietaireDAO().ModifierProprietaire(proprietaireVM.Model);
        }

        public async Task DefinirProprietaireParMailMdp(string mail, string mdp)
        {

            this.model = await new ProprietaireDAO().ObtenirProprietaireParMailMdp(mail, mdp);
        }

        #region ---------- Observation -------------
        /// <summary>
        /// Stocke le nom de la propriété qui a effectuée le changement à l'aide de la fonction notifier
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void Notifier(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Model_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != null) this.Notifier(e.PropertyName);
        }

        /// <summary>
        /// Clone une locationVM, elle sera semblable à la locationVM clonée
        /// </summary>
        /// <returns>Un objet location similaire à la cette locationVM</returns>
        /// <author>Hadrien Bourmault</author>
        public object Clone()
        {
            return new ProprietaireVM((Proprietaire)model.Clone());
        }
        #endregion
    }
}
