using projet_location.Data;
using projet_location.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_location.ViewModel
{
    /// <summary>
    /// Modèle de vue pour la liste des baux
    /// </summary>
    /// <author>Hadrien Bourmault</author>
    public class BauxVM
    {
        #region --------- Attributs -----------

        private Baux modele;
        private List<BailVM> listeDesBaux;

        #endregion

        #region --------- Propriétés -----------

        /// <summary>
        /// Retourne ou modifie le modèle des baux
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public Baux Modele
        {
            get
            {
                return this.modele;
            }

            set
            {
                this.modele = value;
            }
        }

        /// <summary>
        /// Retourne la liste des baux
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public IEnumerable<BailVM> ListeDesBaux
        {
            get
            {
                return this.listeDesBaux;
            }
        }

        #endregion

        #region --------- Constructeur ---------

        public BauxVM(Baux baux)
        {
            this.modele = baux;
            this.listeDesBaux = new List<BailVM>();
            this.modele.PropertyChanged += Model_PropertyChanged;
        }

        #endregion

        #region --------- Méthodes ---------

        private void MAJListeDesBaux()
        {
            this.listeDesBaux.Clear();
            foreach(Bail bail in this.modele.ListeDesBails)
            {
                this.listeDesBaux.Add(new BailVM(bail));
            }
            this.Notifier("ListeDesBaux");
        }

        /// <summary>
        /// Modifie la liste des baux à l'aide du DAO
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire des baux</param>
        /// <author>Hadrien Bourmault</author>
        public async void DefinirListeDesBaux(int idProprietaire)
        {
            this.modele.DefinirListeBails(await new BailDAO().ListerBaux(idProprietaire));
        }

        /// <summary>
        /// Méthode permettant d'ajouter un bail
        /// </summary>
        /// <param name="bailVM">Modèle de bail à ajouter</param>
        /// <author>Hadrien Bourmault</author>
        public async void AjouterBail(BailVM bailVM)
        {
            await new BailDAO().AjouterBail(bailVM.Model);
            this.modele.DefinirListeBails(await new BailDAO().ListerBaux(bailVM.IdProprietaire));
        }

        /// <summary>
        /// Méthode permettant de modifier un bail
        /// </summary>
        /// <param name="bailVM">Modèle de bail à modifier</param>
        /// <author>Hadrien Bourmault</author>
        public async void ModifierBail(BailVM bailVM)
        {
            await new BailDAO().ModifierBail(bailVM.Model);
            this.modele.DefinirListeBails(await new BailDAO().ListerBaux(bailVM.IdProprietaire));
        }

        public async void AnnulerBail(BailVM bailVM)
        {
            await new BailDAO().AnnulerBail(bailVM.Model);
            this.modele.DefinirListeBails(await new BailDAO().ListerBaux(bailVM.IdProprietaire));
        }

        #endregion

        #region ---------- Observation -----------
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Notifier(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Model_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ListeDesBaux")
            {
                this.MAJListeDesBaux();
            }
        }
        #endregion
    }
}
