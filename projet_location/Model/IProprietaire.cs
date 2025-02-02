using System;

namespace projet_location.Model
{
    /// <summary>
    /// Interface pour un propriétaire
    /// </summary>
    public interface IProprietaire : ICloneable
    {
        /// <summary>
        /// Renvoie ou modifie l'identifiant
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        int Id { get; set; }


        /// <summary>
        /// Renvoie ou modifie le mot de passe
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        string MotDePasse { get; set; }

        /// <summary>
        /// Renvoie ou modifie le nom
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        string Nom { get; set; }

        /// <summary>
        /// Renvoie ou modifie le mail
        /// </summary>
        /// <author>HadrienBourmault</author>
        string Mail { get; set; }

        /// <summary>
        /// Renvoie ou modifie le type de personne (physique ou morale)
        /// </summary>
        /// <author>Alexandre Moreau</author>
        public bool TypePersonne { get; set; }

        /// <summary>
        /// Renvoie ou modifie l'adresse
        /// </summary>
        /// <author>Hadrien Bourmault</author>
        public string Adresse { get; set; }
    }
}