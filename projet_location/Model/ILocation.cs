using System;

namespace projet_location.Model
{
    /// <summary>
    /// interface d'une location
    /// </summary>
    /// <author>Julien Guyenet</author>
    public interface ILocation : ICloneable
    {
        /// <summary>
        /// Renvoie ou modifie l'adresse
        /// </summary>
        string Adresse { get; set; }

        /// <summary>
        /// Renvoie ou modifie le code postal
        /// </summary>
        string CodePostal { get; set; }

        /// <summary>
        /// Renvoie ou modifie le compélement d'adresse
        /// </summary>
        string ComplementAdresse { get; set; }

        /// <summary>
        /// Renvoie ou modifie l'identifiant
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Renvoie ou modifie le nom
        /// </summary>
        string Nom { get; set; }

        /// <summary>
        /// Renvoie ou modiife le pays
        /// </summary>
        string Pays { get; set; }

        /// <summary>
        /// Renvoie ou modifie la ville
        /// </summary>
        string Ville { get; set; }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du porpiétaire
        /// </summary>
        int IdProprietaire { get; set; }
    }
}