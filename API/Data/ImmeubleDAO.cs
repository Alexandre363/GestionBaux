using API.Model;

using Oracle.ManagedDataAccess.Client;

namespace API.Data
{
    /// <summary>
    /// DAO permettant d'être en lien avec la BDD
    /// </summary>
    public class ImmeubleDAO : IImmeubleDAO
    {
        private const string CONNEXION = "User Id =IQ_BD_BOURMAULT; Password =BOURMAULT0000; Data Source = srv-iq-ora:1521/orclpdb.iut21.u-bourgogne.fr";

        #region ----------- Méthodes -----------

        /// <summary>
        /// Permet de lister les immeubles d'un proprietaire
        /// </summary>
        /// <param name="idProprietaire">id du propriétaire</param>
        /// <returns>Une énumération d'immeuble</returns>
        /// <author>Julien Guyenet</author>
        public IEnumerable<Immeuble> ListerImmeuble(int idProprietaire)
        {
            using (OracleConnection con = new OracleConnection(CONNEXION))
            {
                List<Immeuble> immeubles = new List<Immeuble>();
                try
                {
                    string message = $"SELECT * FROM IQ_BD_BOURMAULT.IMMEUBLES_SAE WHERE IDPROPRIETAIRE = {idProprietaire}";

                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour lister les appartements d'un immeuble");

                    using (OracleDataReader readerList = command.ExecuteReader())
                    {
                        while (readerList.Read())
                        {
                            int id = readerList.GetByte(0);
                            string nom = readerList.GetString(1);
                            string adresse = readerList.GetString(2);
                            string complementadresse = readerList.GetString(3);
                            string codepostal = readerList.GetString(4);
                            string ville = readerList.GetString(5);
                            string pays = readerList.GetString(6);

                            Immeuble immeuble = new Immeuble(id, nom, adresse, complementadresse, codepostal, ville, pays, idProprietaire);
                            immeubles.Add(immeuble);
                        }
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return immeubles;
            }
        }

        /// <summary>
        /// Permet d'ajouter un immeuble
        /// </summary>
        /// <param name="immeuble">l'immeuble à ajouter</param>
        /// <returns>True si l'ajout à fonctionnée, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool AjouterImmeuble(Immeuble immeuble)
        {
            bool resultat = false; // On part du principe que l'immeuble est déjà présent dans la bdd
            using (OracleConnection con = new OracleConnection(CONNEXION))
            {
                try
                {
                    con.Open();
                    Console.WriteLine("Connexion réussi pour l'ajout d'un immeuble");

                    string requete = "SELECT COUNT(IDENTIFIANT),MAX(IDENTIFIANT) FROM IMMEUBLES_SAE";
                    OracleCommand commande = new OracleCommand(requete, con);

                    using (OracleDataReader reader = commande.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetByte(0) != 0) immeuble.Id = reader.GetByte(1) + 1;
                        }

                        requete = $"INSERT INTO IMMEUBLES_SAE VALUES('{immeuble.Id}','{immeuble.Nom}','{immeuble.Adresse}','{immeuble.ComplementAdresse}','{immeuble.CodePostal}','{immeuble.Ville}','{immeuble.Pays}','{immeuble.IdProprietaire}')";
                        commande = new OracleCommand(requete, con);
                        commande.ExecuteNonQuery();
                        Console.WriteLine("Requete réussi pour l'ajout d'un immeuble");

                        con.Close();
                        resultat = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return resultat;
        }

        /// <summary>
        /// Permet de modifier un immeuble
        /// </summary>
        /// <param name="immeuble">Immeuble à modifier</param>
        /// <returns>True si la modification a fonctionnée, false sinon</returns>
        /// <author>Gibril Lakhdar</author>
        public bool ModifierImmeuble(Immeuble immeuble)
        {
            bool resultat = false;
            using (OracleConnection con = new OracleConnection(CONNEXION))
            {
                try
                {
                    string requete = $"UPDATE IMMEUBLES_SAE SET NOM = '{immeuble.Nom}', ADRESSE = '{immeuble.Adresse}', COMPLEMENTADRESSE = '{immeuble.ComplementAdresse}', CODEPOSTAL = '{immeuble.CodePostal}', VILLE = '{immeuble.Ville}', PAYS = '{immeuble.Pays}', IDPROPRIETAIRE = '{immeuble.IdProprietaire}' WHERE IDENTIFIANT = '{immeuble.Id}'";
                    OracleCommand commande = new OracleCommand(requete, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour la modification d'un immeuble");

                    commande.ExecuteNonQuery();
                    Console.WriteLine("Requete réussi pour la modification d'un immeuble");

                    con.Close();
                    resultat = true;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return resultat;
        }

        /// <summary>
        /// Permet de retirer un immeuble
        /// </summary>
        /// <param name="id">Id de l'immeuble à supprimer</param>
        /// <returns>True si la suppression a fonctionnée et false sinon</returns>
        /// <author>Gibril Lakhdar</author>
        public bool RetirerImmeuble(int id)
        {
            bool resultat = false;
            using (OracleConnection con = new OracleConnection(CONNEXION))
            {
                try
                {
                    string requete = $"DELETE FROM IMMEUBLES_SAE WHERE IDENTIFIANT = {id}";
                    OracleCommand commande = new OracleCommand(requete, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour la suppression d'un immeuble");

                    commande.ExecuteNonQuery();
                    Console.WriteLine("Requete réussi pour la suppression d'un immeuble");

                    con.Close();
                    resultat = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return resultat;
        }

        #endregion
    }
}