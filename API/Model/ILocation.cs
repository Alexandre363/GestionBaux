namespace API.Model
{
    /// <summary>
    /// Représente une location
    /// </summary>
    /// <author>Julien Guyenet</author>
    public interface ILocation
    {
        /// <summary>
        /// Renvoie ou modifie l'adresse de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        public string Adresse { get; set; }

        /// <summary>
        /// Renvoie ou modifie le code postal de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        string CodePostal { get; set; }

        /// <summary>
        /// Renvoie ou modifie le complément d'adresse de la location
        /// </summary>
        /// <author>Julien Guyeent</author>
        string ComplementAdresse { get; set; }

        /// <summary>
        /// Renvoie ou modifie l'identifiant de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        int Id { get; set; }

        /// <summary>
        /// Renvoie ou modifie l'identifiant du propriétaire de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        int IdProprietaire { get; set; }

        /// <summary>
        /// Renvoie ou modifie le nom de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        string Nom { get; set; }

        /// <summary>
        /// Renvoie ou modifie le pays de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        string Pays { get; set; }

        /// <summary>
        /// Renvoie ou modifie la ville de la location
        /// </summary>
        /// <author>Julien Guyenet</author>
        string Ville { get; set; }
    }
}