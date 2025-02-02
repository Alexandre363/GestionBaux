using API.Model;

using Oracle.ManagedDataAccess.Client;

namespace API.Data
{
    public class BailDAO : IBailDAO
    {

        /// <summary>
        /// Permet d'ajouter un bail saisit en paramètre
        /// </summary>
        /// <param name="bail">Objet Bail à ajouter</param>
        /// <returns>True si il est présent, False sinon</returns>
        /// <author>Moreau Alexandre</author>
        public bool AjouterBail(Bail bail)
        {
            bool resultat = false; // On part du principe que l'utilisateur n'est pas présent dans la base de donnée
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                try
                {
                    con.Open();
                    Console.WriteLine("Connexion réussi pour ajouter un bail");

                    string requete = "SELECT COUNT(IDENTIFIANT),MAX(IDENTIFIANT) FROM BAILS_SAE";
                    OracleCommand commande = new OracleCommand(requete, con);

                    using (OracleDataReader reader = commande.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetByte(0) != 0)
                            {
                                bail.Identifiant = reader.GetByte(1) + 1; //Sélectionne le maximum + 1 au niveau de l'identifiant
                            }
                        }
                        if (bail.Duree == "")
                        {
                            bail.Duree = "indefini";
                        }
                        if (bail.DateRevalorisation == "")
                        {
                            bail.DateRevalorisation = "indefini";
                        }
                        if (bail.DatePayement == "")
                        {
                            bail.DatePayement = "indefini";
                        }

                        int apaye = 0;

                        if (bail.Apaye == true)
                        {
                            apaye = 1;
                        }

                        if (bail.Nom == "")
                        {
                            bail.Nom = "indefini";
                        }

                        requete = $"INSERT INTO BAILS_SAE VALUES('{bail.Identifiant}','{bail.IdLocataire}','{bail.IdLocation}','{bail.DateSignature.ToShortDateString()}','{bail.DateDebut.ToShortDateString()}','{bail.Duree}','{bail.LoyerHC}','{bail.Charge}','{bail.IdProprietaire}','{bail.DateRevalorisation}','{bail.DatePayement}','{apaye}','{bail.Nom}')";
                        commande = new OracleCommand(requete, con);
                        commande.ExecuteNonQuery();
                        Console.WriteLine("Requete réussi pour ajouter un bail");

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
        /// Permet d'annuler d'un bail
        /// </summary>
        /// <param name="id">Id de la location à supprimer</param>
        /// <returns>True si il a bien été supprimé, False sinon</returns>
        /// <author>Moreau Alexandre</author>
        public bool AnnulerBail(int id)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                bool resultat = false;
                try
                {
                    string message = String.Format("DELETE FROM BAILS_SAE WHERE IDENTIFIANT = {0}", id);
                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour la suppression d'un bail");

                    command.ExecuteNonQuery();
                    Console.WriteLine("Requete réussi pour la suppression d'un bail");
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
        /// Renvoie tous les bails 
        /// </summary>
        /// <returns>Une énumération de tous les bails</returns>
        /// <author>Moreau Alexandre</author>
        public IEnumerable<Bail> ListerBail(int idProprietaire)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                List<Bail> bails = new List<Bail>();
                try
                {
                    string message = $"SELECT * FROM BAILS_SAE WHERE IDPROPRIETAIRE = {idProprietaire}";

                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour lister des bails");

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idLocataire = reader.GetByte(1);
                            int idLocation = reader.GetByte(2);
                            int identifiant = reader.GetByte(0);

                            DateTime dateSign = reader.GetDateTime(3);
                            DateTime dateDeb = reader.GetDateTime(4);

                            string duree = reader.GetString(5);

                            float loyerHC = reader.GetFloat(6);
                            float charge = reader.GetFloat(7);

                            string dateRevalorisation = reader.GetString(9);
                            string datePayement = reader.GetString(10);
                            int apaye = reader.GetByte(11);
                            string nom = reader.GetString(12);

                            bool boolapaye = false;
                            if (apaye == 1)
                            {
                                boolapaye = true;
                            }

                            Bail bail = new Bail(identifiant,nom,idLocataire, idLocation, dateSign, dateDeb, duree, loyerHC, charge, idProprietaire, dateRevalorisation, datePayement,boolapaye);
                            bails.Add(bail);
                        }
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return bails;
            }
        }

        /// <summary>
        /// Permet de modifier un bail
        /// </summary>
        /// <param name="bail">bail à modifier</param>
        /// <returns>True s'il a bien été modifié, False sinon</returns>
        /// <author>Alexandre Moreau</author>
        public bool ModifierBail(Bail bail)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                bool resultat = false;
                int apaye = 0;
                {
                    try
                    {
                        if (bail.Apaye) 
                        {
                            apaye = 1;
                        }

                        string message = $"UPDATE BAILS_SAE SET NOM='{bail.Nom}', IDLOCATAIRE = '{bail.IdLocataire}', IDLOCATION = '{bail.IdLocation}',DATESIGNATURE = '{bail.DateSignature.ToShortDateString()}',DATEDEBUT = '{bail.DateDebut.ToShortDateString()}',DUREE = '{bail.Duree}',LOYERHC = '{bail.LoyerHC}',CHARGE = '{bail.Charge}', IDPROPRIETAIRE = '{bail.IdProprietaire}', DATEREVALORISATION = '{bail.DateRevalorisation}', DATEPAYEMENT = '{bail.DatePayement}', APAYE = '{apaye}' WHERE IDENTIFIANT = '{bail.Identifiant}'";
                        OracleCommand command = new OracleCommand(message, con);

                        con.Open();
                        Console.WriteLine("Connexion réussi pour la modification d'un bail");

                        command.ExecuteNonQuery();
                        Console.WriteLine("Requete réussi pour la suppression d'un bail");
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
    }
}
