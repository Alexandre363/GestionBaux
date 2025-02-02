using System;
using System.IO.Packaging;

namespace projet_location.Model
{
    /// <summary>
    /// Interface pour un bail
    /// </summary>
    /// <author>Hadrien Bourmault</author>
    public interface IBail
    {
        /// <summary>
        /// Renvoie ou modifie l'identifiant du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        int Identifiant { get; set; }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du locataire lié au bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        int IdLocataire { get; set; }

        /// <summary>
        /// Renvoie ou modifie l'identifiant de la location lié au bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        int IdLocation { get; set; }

        /// <summary>
        /// Renvoie ou modifie la date de signature
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        DateTime DateSignature { get; set; }

        /// <summary>
        /// Renvoie ou modifie le la date de prise d'effet du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        DateTime DateDebut { get; set; }

        /// <summary>
        /// Renvoie ou modifie la durée du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        string Duree { get; set; }

        /// <summary>
        /// Renvoie ou modifie le loyer hors charges
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        float LoyerHC { get; set; }

        /// <summary>
        /// Renvoie ou modifie les charges
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        float Charge { get; set; }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du proprétaire du bail
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        int IdProprietaire { get; set; }

        /// <summary>
        /// Renvoie ou modifie le nom du bail 
        /// </summary>
        /// <author>Lakhdar Gibril</author>
        string Nom { get; set; }

        /// <summary>
        /// Renvoie ou modifie la date à laquelle le loyer peut être revalorisé
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        string DateRevalorisation { get; set; }

        /// <summary>
        /// Renvoie ou modifie la date de payement du loyer chaque mois
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        string DatePayement { get; set; }

        /// <summary>
        /// Renvoie ou modifie si le locataire à payer le loyer
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        bool Apaye { get; set; }

    }
}
