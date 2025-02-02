using projet_location.Model;

using System;
using System.ComponentModel;

namespace projet_location.ViewModel
{
    /// <summary>
    /// Représente une vue modèle pour un locataire
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    public class LocataireVM : INotifyPropertyChanged, ILocataire
    {
        #region ----------- Attributs ---------------
        private Locataire model;
        #endregion

        #region ----------- Propriétés ---------------

        /// <summary>
        /// Renvoie 
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public Locataire Model => this.model;
        /// <summary>
        /// Modifie ou Retourne l'id du locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public int Id
        {
            get => this.model.Id;
            set => this.model.Id = value;
        }

        /// <summary>
        /// Renvoie ou Modifie le nom du locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public string Nom
        {
            get => this.model.Nom;
            set => this.model.Nom = value;
        }

        /// <summary>
        /// Renvoie ou Modifie le prénom du locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public string Prenom
        {
            get => this.model.Prenom;
            set => this.model.Prenom = value;
        }

        /// <summary>
        /// Renvoie ou Modifie la nationalité du locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public string Nationalite
        {
            get => this.model.Nationalite;
            set => this.model.Nationalite = value;
        }

        /// <summary>
        /// Renvoie ou modifie l'adresse mail du locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public string AdresseMail
        {
            get => this.model.AdresseMail;
            set => this.model.AdresseMail = value;
        }

        /// <summary>
        /// Renvoie la date de naissance du locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public DateTime DateDeNaissance
        {
            get => this.model.DateDeNaissance;
            set => this.model.DateDeNaissance = value; // Utile pour la désérialisation
        }

        /// <summary>
        /// Retourne ou Modifie le numéro de téléphone du locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public string Telephone
        {
            get => this.model.Telephone;
            set => this.model.Telephone = value;
        }

        /// <summary>
        /// Renvoie ou modifie le type du contrat pour le locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public string TypeContrat
        {
            get => this.model.TypeContrat;
            set => this.model.TypeContrat = value;
        }

        /// <summary>
        /// Renvoie ou Modifie la situation familiale du locataire
        /// </summary>
        public string SituationFamilliale
        {
            get => this.model.SituationFamilliale;
            set => this.model.SituationFamilliale = value;
        }

        /// <summary>
        /// Renvoie ou modifie le métier du locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public string Profession
        {
            get => this.model.Profession;
            set => this.model.Profession = value;
        }

        /// <summary>
        /// Renvoie ou Modifie le nombre de personne à charge pour le locataire 
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public int NbPersonneACharge
        {
            get => this.model.NbPersonneACharge;
            set => this.model.NbPersonneACharge = value;
        }

        /// <summary>
        /// Renvoie ou modifie le salaire mensuel net du locataire
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public decimal SalaireMensuelNet
        {
            get => this.model.SalaireMensuelNet;
            set => this.model.SalaireMensuelNet = value;
        }

        /// <summary>
        /// Renvoie le montant d'allocation familliale que perçoit le locataire ou le modifie
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public decimal AllocFamilliale
        {
            get => this.model.AllocFamilliale;
            set => this.model.AllocFamilliale = value;
        }

        /// <summary>
        /// Renvoie le montant d'allocation logement que touche le locataire ou le change
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public decimal AllocLogement
        {
            get => this.model.AllocLogement;
            set => this.model.AllocLogement = value;
        }

        /// <summary>
        /// Renvoie le montant d'autres revenus que perçoit le locataire ou le change
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public decimal RevenusExterieur
        {
            get => this.model.RevenusExterieur;
            set => this.model.RevenusExterieur = value;
        }

        /// <summary>
        /// Renvoie l'id du propriétaire d'un locataire
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int IdProprietaire
        {
            get => this.model.IdProprietaire;
            set => this.model.IdProprietaire = value;
        }
        #endregion

        #region ------------ Constructeur --------------
        /// <summary>
        /// Constructeur de la classe LocataireVM
        /// </summary>
        /// <param name="model">modèle de locataire utilisé</param>
        public LocataireVM(Locataire model)
        {
            this.model = model;
            this.model.PropertyChanged += Model_PropertyChanged;
        }
        #endregion

        #region ------------ Méthodes --------------
        public override string ToString()
        {
            return $"{this.model.Nom} {this.model.Prenom}";
        }
        #endregion

        #region ------------- Observation ---------------
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
        /// Renvoie un clone de LocataireVM
        /// </summary>
        /// <returns>un objet de la classe LocataireVM</returns>
        /// <author>Lakhdar Gibril</author>
        public object Clone()
        {
            return new LocataireVM((Locataire)model.Clone());
        }
        #endregion
    }
}
