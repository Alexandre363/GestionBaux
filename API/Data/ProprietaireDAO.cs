using API.Model;

using Oracle.ManagedDataAccess.Client;

using System.Security.Cryptography;

namespace API.Data
{
    /// <summary>
    /// Le dao liant le proprietaire à la base de donnée
    /// </summary>
    /// <author>Julien Guyenet</author>
    public class ProprietaireDAO : IProprietaireDAO
    {
        #region ----------- Méthodes -----------
        /// <summary>
        /// Permet de renvoyer tous les proprietaires 
        /// </summary>
        /// <returns>Une énumération de tous les proprietaires de l'application</returns>
        public IEnumerable<Proprietaire> ListerProprietaires()
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                List<Proprietaire> proprietaires = new List<Proprietaire>();
                try
                {
                    string message = $"SELECT * FROM PROPRIETAIRES_SAE";

                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour lister les propriétaires");

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetByte(0);

                            string mdp = reader.GetString(1);
                            string nom = reader.GetString(2);
                            string mail = reader.GetString(3);
                            bool typePersonne = false;
                            if (reader.GetByte(4) == 1) typePersonne = true;
                            string adresse = reader.GetString(5);


                            Proprietaire proprio = new Proprietaire(id, mdp, nom, mail, typePersonne, adresse);
                            proprietaires.Add(proprio);
                        }
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return proprietaires;
            }
        }

        /// <summary>
        /// Permet d'ajouter un proprietaire saisit en paramètre
        /// </summary>
        /// <param name="proprietaire">Proprietaire à ajouter</param>
        /// <returns>True si l'ajout a fonctionné, false sinon</returns>
        /// <author>Lakhdar Gibril</author>
        public bool AjouterProprietaire(Proprietaire proprietaire)
        {
            bool resultat = false; // On part du principe que l'utilisateur n'est pas présent dans la base de donnée
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                try
                {
                    con.Open();
                    Console.WriteLine("Connexion réussi pour ajouter un propriétaire");

                    string requete = "SELECT COUNT(IDENTIFIANT),MAX(IDENTIFIANT) FROM PROPRIETAIRES_SAE";
                    OracleCommand commande = new OracleCommand(requete, con);

                    using (OracleDataReader reader = commande.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetByte(0) != 0)
                            {
                                proprietaire.Id = reader.GetByte(1) + 1; //Sélectionne le maximum + 1 au niveau de l'identifiant
                            }
                        }
                        int typePersonne = 0;
                        if (proprietaire.TypePersonne)
                        {
                            typePersonne = 1;
                        }
                        requete = $"INSERT INTO PROPRIETAIRES_SAE VALUES('{proprietaire.Id}','{HashageMotDePasse(proprietaire.MotDePasse)}','{proprietaire.Nom}','{proprietaire.Mail}','{typePersonne}','{proprietaire.Adresse}')";
                        commande = new OracleCommand(requete, con);
                        commande.ExecuteNonQuery();
                        Console.WriteLine("Requete réussi pour ajouter un propriétaire");

                        con.Close();
                        resultat = true;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                return resultat;
            }
        }

        /// <summary>
        /// Permet de supprimer un proprietaire
        /// </summary>
        /// <param name="id">Id du proprietaire à supprimer</param>
        /// <returns>True s'il a bien été supprimé, false sinon</returns>
        public bool RetirerProprietaire(int id)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                bool resultat = false;
                try
                {
                    string message = String.Format("DELETE FROM PROPRIETAIRES_SAE WHERE IDENTIFIANT = {0}", id);
                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour supprimer un propriétaire");

                    command.ExecuteNonQuery();
                    Console.WriteLine("Requete réussi pour supprimer un propriétaire");

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
        /// Permet de modifier un proprietaire
        /// </summary>
        /// <param name="proprietaire">proprietaire à modifier</param>
        /// <returns>True s'il a bien été modifié, false sinon</returns>
        public bool ModifierProprietaire(Proprietaire proprietaire)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                bool result = false;
                try
                {
                    int typePersonne = 0;
                    if (proprietaire.TypePersonne)
                    {
                        typePersonne = 1;
                    }

                    string message = $"UPDATE PROPRIETAIRES_SAE SET NOM = '{proprietaire.Nom}', MOTDEPASSE = '{HashageMotDePasse(proprietaire.MotDePasse)}', MAIL = '{proprietaire.Mail}', TYPEPERSONNE = '{typePersonne}', ADRESSE = '{proprietaire.Adresse}' WHERE IDENTIFIANT = {proprietaire.Id}";
                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour modifier un propriétaire");

                    command.ExecuteNonQuery();
                    Console.WriteLine("Requete réussi pour modifier un propriétaire");
                    con.Close();
                    result = true;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return result;
            }
        }

        /// <summary>
        /// Permet de se connecter a son compte
        /// </summary>
        /// <param name="mail">mail du proprietaire</param>
        /// <param name="mdp">mot de passe du proprietaire</param>
        /// <returns>id du proprietaire</returns>
        /// <author>Alexandre Moreau</author>
        public int ConnexionProprietaire(string mail, string mdp)
        {


            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                int idProprietaire = 0;

                try
                {
                    string message = $"SELECT IDENTIFIANT FROM PROPRIETAIRES_SAE WHERE MAIL = '{mail}' AND MOTDEPASSE = '{HashageMotDePasse(mdp)}'";

                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour se connecter à un compte");

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idProprietaire = reader.GetByte(0);
                        }
                        reader.Close();
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return idProprietaire;

            }
        }

        /// <summary>
        /// Obtient un proprietaire
        /// </summary>
        /// <param name="mail">mail du proprietaire</param>
        /// <param name="mdp">mot de passe du proprietaire</param>
        /// <returns>Le propriétaire s'il a été trouvé</returns>
        /// <author>Julien Guyenet</author>
        public Proprietaire ObtenirProprietaireParMailMdp(string mail, string mdp)
        {


            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                int id = -1;
                string nom = "";
                bool typePersonne = true;
                string adresse = "";
                try
                {
                    string message = $"SELECT * FROM PROPRIETAIRES_SAE WHERE MAIL = '{mail}' AND MOTDEPASSE = '{HashageMotDePasse(mdp)}'";

                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour obtenir un propriétaire");

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader.GetByte(0);
                            nom = reader.GetString(3);
                            if (reader.GetByte(4) == 0)
                            {
                                typePersonne = false;
                            }
                            adresse = reader.GetString(5);
                        }
                        reader.Close();
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return new Proprietaire(id, mdp, nom, mail, typePersonne, adresse);
            }
        }

        /// <summary>
        /// Permet de renvoyer un mot de passe haché
        /// </summary>
        /// <param name="motDePasse">Mot de passe a haché</param>
        /// <returns>Le mot de passe haché</returns>
        /// <author>Lakhdar Gibril</author>
        private static string HashageMotDePasse(string motDePasse)
        {
            byte[] motDePasseHash;
            using (var sha = new SHA256Managed())
            {
                motDePasseHash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(motDePasse)); //Permet de Hasher selon un certain type d'encodage et de récupérer la valeur des octets du mot de passe
                sha.Clear();
            }
            return Convert.ToBase64String(motDePasseHash);

        }
        #endregion
    }
}
