using System;

namespace projet_location.Model
{
    /// <summary>
    /// Interface pour un locataire
    /// </summary>
    /// <author>Lakhdar Gibril</author>
    public interface ILocataire : ICloneable
    {
        /// <summary>
        /// Renvoie ou modifie le montant des allocations familiales
        /// </summary>
        decimal AllocFamilliale { get; set; }

        /// <summary>
        /// Renvoie ou modifie les allocations logements
        /// </summary>
        decimal AllocLogement { get; set; }

        /// <summary>
        /// Renvoie ou modifie les revenus extérieurs
        /// </summary>
        decimal RevenusExterieur { get; set; }

        /// <summary>
        /// Renvoi ou modifie la date de naissance
        /// </summary>
        DateTime DateDeNaissance { get; set; }

        /// <summary>
        /// Renvoie ou modife l'adresse mail
        /// </summary>
        string AdresseMail { get; set; }

        /// <summary>
        /// Renvoie ou modifie l'identifiant
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Renvoie ou modifie la nationalité
        /// </summary>
        string Nationalite { get; set; }

        /// <summary>
        /// Renvoie ou modifie le nombre de personnes à charges
        /// </summary>
        int NbPersonneACharge { get; set; }

        /// <summary>
        /// Renvoie ou modifie le nom
        /// </summary>
        string Nom { get; set; }

        /// <summary>
        /// Renvoie ou modifie le prénom
        /// </summary>
        string Prenom { get; set; }

        /// <summary>
        /// Renvoie ou modifie la profession
        /// </summary>
        string Profession { get; set; }

        /// <summary>
        /// Renvoie ou modifie le salaire mensuel net
        /// </summary>
        decimal SalaireMensuelNet { get; set; }

        /// <summary>
        /// Renvoie ou modifie la situation familiale
        /// </summary>
        string SituationFamilliale { get; set; }

        /// <summary>
        /// Renvoie ou modifie le téléphone
        /// </summary>
        string Telephone { get; set; }

        /// <summary>
        /// Renvoie ou modifie le type de contrat
        /// </summary>
        string TypeContrat { get; set; }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du propriétaire
        /// </summary>
        int IdProprietaire { get; set; }
    }
}