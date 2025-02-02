using API.Model;

using Oracle.ManagedDataAccess.Client;

namespace API.Data
{
    /// <summary>
    /// DAO permettant d'être en lien avec la BDD
    /// </summary>
    public class LocationDAO : ILocationDAO
    {
        #region ----------- Méthodes -----------

        /// <summary>
        /// Permet d'ajouter une location saisit en paramètre
        /// </summary>
        /// <param name="location">Objet Location à ajouter</param>
        /// <returns>True si il est présent, false sinon</returns>
        /// <author>Alexandre Moreau</author>
        public bool AjouterLocation(Location location)
        {
            bool resultat = false;

            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                try
                {
                    List<Location> memoire = (List<Location>)this.ListerLocations(location.IdProprietaire);
                    con.Open();
                    Console.WriteLine("Connexion réussi pour l'ajout d'un location");

                    string message = "SELECT COUNT(IDENTIFIANT),MAX(IDENTIFIANT) FROM LOCATIONS_SAE";
                    OracleCommand command = new OracleCommand(message, con);

                    using (OracleDataReader readerId = command.ExecuteReader())
                    {
                        location.Id = 0;
                        while (readerId.Read())
                        {
                            if (readerId.GetByte(0) != 0) location.Id = readerId.GetByte(1) + 1;
                        }
                        readerId.Close();

                    }

                    int typeHabitat = 0;
                    if (location.TypeHabitat)
                    {
                        typeHabitat = 1;
                    }

                    int typePropriete = 0;
                    if (location.TypePropriete)
                    {
                        typePropriete = 1;
                    }

                    int typeChauffage = 0;
                    if (location.TypeChauffage)
                    {
                        typeChauffage = 1;
                    }

                    int typeEauChaude = 0;
                    if (location.TypeEauChaude)
                    {
                        typeEauChaude = 1;
                    }

                    if (location.Nom == "")
                    {
                        location.Nom = " ";
                    }
                    if (location.Adresse == "")
                    {
                        location.Adresse = " ";
                    }
                    if (location.ComplementAdresse == "")
                    {
                        location.ComplementAdresse = " ";
                    }
                    if (location.CodePostal == "")
                    {
                        location.CodePostal = " ";
                    }
                    if (location.Pays == "")
                    {
                        location.Pays = " ";
                    }
                    if (location.Ville == "")
                    {
                        location.Ville = " ";
                    }
                    if (location.PeriodeConstruction == "")
                    {
                        location.PeriodeConstruction = " ";
                    }

                    message = $"INSERT INTO LOCATIONS_SAE VALUES('{location.Id}','{location.Nom}','{location.Adresse}','{location.ComplementAdresse}','{location.CodePostal}','{location.Ville}','{location.Pays}','{location.IdImmeuble}','{location.IdProprietaire}','{typeHabitat}','{typePropriete}','{location.PeriodeConstruction}','{location.SurfaceHabitable}','{location.NbPiecesPrincipales}','{typeChauffage}','{typeEauChaude}','{location.NbCouchages}')";
                    command = new OracleCommand(message, con);

                    command.ExecuteNonQuery();
                    Console.WriteLine("Requete réussi pour l'ajout d'un locataire");

                    con.Close();

                    resultat = true;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return resultat;
            }
        }

        /// <summary>
        /// Permet de renvoyer toute les locations d'un immeuble
        /// </summary>
        /// <param name="idProprietaire">id du propriétaire de l'immeuble</param>
        /// <param name="idImmeuble">id de l'immeuble</param>
        /// <returns>Une énumérations de tous les appartements</returns>
        /// <author>Julien Guyenet</author>
        public IEnumerable<Location> ListerAppartements(int idProprietaire, int idImmeuble)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                List<Location> locations = new List<Location>();
                try
                {
                    string message = $"SELECT * FROM IQ_BD_BOURMAULT.LOCATIONS_SAE WHERE IDPROPRIETAIRE = {idProprietaire} AND IDIMMEUBLE = {idImmeuble}";

                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour lister les appartements");

                    using (OracleDataReader readerList = command.ExecuteReader())
                    {
                        while (readerList.Read())
                        {
                            bool typeHabitat = true;
                            bool typePropriete = true;
                            bool typeChauffage = true;
                            bool typeAuChaude = true;

                            if (readerList.GetByte(9) == 0)
                            {
                                typeHabitat = false;
                            }
                            if (readerList.GetByte(10) == 0)
                            {
                                typePropriete = false;
                            }
                            if (readerList.GetByte(14) == 0)
                            {
                                typeChauffage = false;
                            }
                            if (readerList.GetByte(15) == 0)
                            {
                                typeAuChaude = false;
                            }

                            int id = readerList.GetByte(0);
                            string nom = readerList.GetString(1);
                            string adresse = readerList.GetString(2);
                            string complementadresse = readerList.GetString(3);
                            string codepostal = readerList.GetString(4);
                            string ville = readerList.GetString(5);
                            string pays = readerList.GetString(6);
                            int idimmeuble = readerList.GetByte(7);
                            int idproprietaire = readerList.GetByte(8);
                            string periodeConstruction = readerList.GetString(11);
                            float surfaceHabitable = readerList.GetFloat(12);
                            int nbPiecesHabitable = readerList.GetByte(13);
                            int nbCouchages = readerList.GetByte(16);



                            Location loc = new Location(id, nom, adresse, complementadresse, codepostal, ville, pays, idimmeuble, idproprietaire, typeHabitat, typePropriete, periodeConstruction, surfaceHabitable, nbPiecesHabitable, typeChauffage, typeAuChaude, nbCouchages);
                            locations.Add(loc);
                        }
                        readerList.Close();
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return locations;
            }
        }

        /// <summary>
        /// Permet de renvoyer toutes les locations 
        /// </summary>
        /// <param name="idProprietaire">Id du propriétaires des locations</param>
        /// <returns>Une énumération de toute les locations</returns>
        /// <author>Hadrien Bourmault</author>
        public IEnumerable<Location> ListerLocations(int idProprietaire)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                List<Location> locations = new List<Location>();
                try
                {
                    string message = $"SELECT * FROM IQ_BD_BOURMAULT.LOCATIONS_SAE WHERE IDPROPRIETAIRE = {idProprietaire}";

                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour lister les locations");

                    using (OracleDataReader readerList = command.ExecuteReader())
                    {
                        while (readerList.Read())
                        {
                            bool typeHabitat = true;
                            bool typePropriete = true;
                            bool typeChauffage = true;
                            bool typeAuChaude = true;

                            if (readerList.GetByte(9) == 0)
                            {
                                typeHabitat = false;
                            }
                            if (readerList.GetByte(10) == 0)
                            {
                                typePropriete = false;
                            }
                            if (readerList.GetByte(14) == 0)
                            {
                                typeChauffage = false;
                            }
                            if (readerList.GetByte(15) == 0)
                            {
                                typeAuChaude = false;
                            }

                            int id = readerList.GetByte(0);
                            string nom = readerList.GetString(1);
                            string adresse = readerList.GetString(2);
                            string complementadresse = readerList.GetString(3);
                            string codepostal = readerList.GetString(4);
                            string ville = readerList.GetString(5);
                            string pays = readerList.GetString(6);
                            int idImmeuble = readerList.GetByte(7);
                            int idproprietaire = readerList.GetByte(8);
                            string periodeConstruction = readerList.GetString(11);
                            float surfaceHabitable = readerList.GetFloat(12);
                            int nbPiecesHabitable = readerList.GetByte(13);
                            int nbCouchages = readerList.GetByte(16);



                            Location loc = new Location(id, nom, adresse, complementadresse, codepostal, ville, pays, idImmeuble, idproprietaire, typeHabitat, typePropriete, periodeConstruction, surfaceHabitable, nbPiecesHabitable, typeChauffage, typeAuChaude, nbCouchages);
                            locations.Add(loc);
                        }
                        readerList.Close();
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return locations;
            }
        }

        /// <summary>
        /// Permet de supprimer une location
        /// </summary>
        /// <param name="id">Id de la location à supprimer</param>
        /// <returns>True si elle a bien été supprimée, false sinon</returns>
        /// <author>Hadrien Bourmault</author>
        public bool RetirerLocation(int id)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                bool resultat = false;
                try
                {
                    string message = String.Format("DELETE FROM LOCATIONS_SAE WHERE IDENTIFIANT = {0}", id);
                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour supprimer une location");

                    command.ExecuteNonQuery();
                    Console.WriteLine("Requete réussi pour supprimer une location");
                    con.Close();
                    resultat = true;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return resultat;
            }
        }

        /// <summary>
        /// Permet de modifier une location
        /// </summary>
        /// <param name="location">Location à modifier</param>
        /// <returns>True si elle a bien été modifiée, false sinon</returns>
        /// <author>Hadrien Bourmault</author>
        public bool ModifierLocation(Location location)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                bool resultat = false;

                {
                    try
                    {
                        int typeHabitat = 0;
                        if (location.TypeHabitat)
                        {
                            typeHabitat = 1;
                        }

                        int typePropriete = 0;
                        if (location.TypePropriete)
                        {
                            typePropriete = 1;
                        }

                        int typeChauffage = 0;
                        if (location.TypeChauffage)
                        {
                            typeChauffage = 1;
                        }

                        int typeEauChaude = 0;
                        if (location.TypeEauChaude)
                        {
                            typeEauChaude = 1;
                        }


                        string message = $"UPDATE LOCATIONS_SAE SET NOM = '{location.Nom}', ADRESSE = '{location.Adresse}', COMPLEMENTADRESSE = '{location.ComplementAdresse}', CP = '{location.CodePostal}', VILLE = '{location.Ville}', PAYS = '{location.Pays}', IDIMMEUBLE = '{location.IdImmeuble}', TYPEHABITAT = '{typeHabitat}', TYPEPROPRIETE = '{typePropriete}', PERIODECONSTRUCTION = '{location.PeriodeConstruction}', SURFACEHABITABLE = '{location.SurfaceHabitable}', NBPIECESPRINCIPALES = '{location.NbPiecesPrincipales}', TYPECHAUFFAGE = '{typeChauffage}', TYPEEAUCHAUDE = '{typeEauChaude}', NBCOUCHAGES = '{location.NbCouchages}' WHERE IDENTIFIANT = {location.Id}";
                        OracleCommand command = new OracleCommand(message, con);

                        con.Open();
                        Console.WriteLine("Connexion réussi pour modifier une location");

                        command.ExecuteNonQuery();
                        Console.WriteLine("Requete réussi pour modifier une location");
                        con.Close();
                        resultat = true;
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    return resultat;
                }
            }
        }
        #endregion
    }
}