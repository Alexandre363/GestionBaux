using projet_location.Model;

using System;
using System.ComponentModel;

namespace projet_location.ViewModel
{
    /// <summary>
    /// Représente un ViewModel pour un bail
    /// </summary>
    public class BailVM : INotifyPropertyChanged, IBail
    {
        #region ----------- Attributs -----------
        private Bail model;
        #endregion

        #region ----------- Propriétés -----------

        /// <summary>
        /// Renvoie le modèle
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public Bail Model
        {
            get
            {
                return this.model;
            }

        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int Identifiant
        {
            get
            {
                return this.model.Identifiant;
            }

            set
            {
                this.model.Identifiant = value;
            }
        }

        /// <summary>
        /// Renvoie ou modifie l'identifant du locataire du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int IdLocataire
        {
            get
            {
                return this.model.IdLocataire;
            }

            set
            {
                this.model.IdLocataire = value;
                this.Notifier("IdLocataire");
            }
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant de la location du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int IdLocation
        {
            get
            {
                return this.model.IdLocation;
            }

            set
            {
                this.model.IdLocation = value;
                this.Notifier("IdLocation");
            }
        }

        /// <summary>
        /// Renvoie ou modifie la date de signature du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public DateTime DateSignature
        {
            get
            {
                return this.model.DateSignature;
            }

            set
            {
                this.model.DateSignature = value;
            }
        }

        /// <summary>
        /// Renvoie ou modifie la date de début du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public DateTime DateDebut
        {
            get
            {
                return this.model.DateDebut;
            }

            set
            {
                this.model.DateDebut = value;
            }
        }

        /// <summary>
        /// Renvoie ou modifie la durée du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public string Duree
        {
            get
            {
                return this.model.Duree;
            }

            set
            {
                this.model.Duree = value;
                this.Notifier("Duree");
            }
        }

        /// <summary>
        /// Renvoie ou modifie le loyer hors charge du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public float LoyerHC
        {
            get
            {
                return this.model.LoyerHC;
            }

            set
            {
                this.model.LoyerHC = value;
                this.Notifier("LoyerHC");
            }
        }

        /// <summary>
        /// Renvoie ou modifie les charges du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public float Charge
        {
            get
            {
                return this.model.Charge;
            }

            set
            {
                this.model.Charge = value;
                this.Notifier("Charge");
            }
        }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du propriétaire du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public int IdProprietaire
        {
            get
            {
                return this.model.IdProprietaire;
            }

            set
            {
                this.model.IdProprietaire = value;
                this.Notifier("IdProprietaire");
            }
        }

        /// <summary>
        /// Renvoie le nom du bail, nom aussi modifiable
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        public string Nom
        {
            get => this.model.Nom;
            set
            {
                this.model.Nom = value;
                this.Notifier("Nom");
            }
        }

        /// <summary>
        /// Renvoie ou modifie la date de revalorisation du loyer du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public string DateRevalorisation
        {
            get
            {
                return this.model.DateRevalorisation;
            }

            set
            {
                this.model.DateRevalorisation = value;
                this.Notifier("DateRevalorisation");
            }
        }

        /// <summary>
        /// Renvoie ou modifie la date de payement du loyer du bail
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public string DatePayement
        {
            get
            {
                return this.model.DatePayement;
            }

            set
            {
                this.model.DatePayement = value;
                this.Notifier("DatePayement");
            }
        }

        /// <summary>
        /// Renvoie ou modifie si le locataire a payé le loyer
        /// </summary>
        public bool Apaye
        {
            get
            {
                return this.model.Apaye;
            }

            set
            {
                this.model.Apaye = value;
                this.Notifier("Apaye");
            }
        }

        #endregion

        #region ------------- Constructeur -------------

        public BailVM(Bail model)
        {
            this.model = model;
            this.model.PropertyChanged += Model_PropertyChanged;
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
            return new BailVM((Bail)model.Clone());
        }
        #endregion
    }
}
