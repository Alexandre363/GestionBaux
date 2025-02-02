using API.Model;

using Oracle.ManagedDataAccess.Client;

namespace API.Data
{
    public class LocataireDAO : ILocataireDAO
    {

        #region ----------- Méthodes -----------

        /// <summary>
        /// Permet d'ajouter un locataire saisit en paramètre
        /// </summary>
        /// <param name="locataire">Locataire à ajouter</param>
        /// <returns>True s'il a réussi à l'ajouter, false sinon</returns>
        /// <author>Julien Guyenet</author>
        public bool AjouterLocataire(Locataire locataire)
        {
            bool resultat = false;

            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                try
                {
                    con.Open();
                    Console.WriteLine("Connexion réussi pour l'ajout d'un locataire");

                    string message = "SELECT COUNT(IDENTIFIANT),MAX(IDENTIFIANT) FROM LOCATAIRES_SAE";
                    OracleCommand command = new OracleCommand(message, con);

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetByte(0) != 0) locataire.Id = reader.GetByte(1) + 1;
                        }
                    }

                    if (locataire.Nom == "")
                    {
                        locataire.Nom = " ";
                    }

                    if (locataire.Prenom == "")
                    {
                        locataire.Prenom = " ";
                    }

                    if (locataire.DateDeNaissance == new DateTime())
                    {
                        locataire.DateDeNaissance = DateTime.Now;
                    }

                    if (locataire.Nationalite == "")
                    {
                        locataire.Nationalite = " ";
                    }

                    if (locataire.Telephone == "")
                    {
                        locataire.Telephone = " ";
                    }


                    if (locataire.AdresseMail == "")
                    {
                        locataire.AdresseMail = " ";
                    }

                    if (locataire.SituationFamilliale == "")
                    {
                        locataire.SituationFamilliale = " ";
                    }


                    if (locataire.TypeContrat == "")
                    {
                        locataire.TypeContrat = " ";
                    }

                    if (locataire.Profession == "")
                    {
                        locataire.Profession = " ";
                    }


                    message = $"INSERT INTO LOCATAIRES_SAE VALUES('{locataire.Id}','{locataire.Nom}','{locataire.Prenom}','{locataire.DateDeNaissance.ToShortDateString()}','{locataire.Nationalite}','{locataire.Telephone}','{locataire.AdresseMail}','{locataire.SituationFamilliale}','{locataire.NbPersonneACharge}','{locataire.TypeContrat}','{locataire.Profession}','{locataire.SalaireMensuelNet}','{locataire.AllocFamilliale}','{locataire.AllocLogement}','{locataire.RevenusExterieur}','{locataire.IdProprietaire}')";
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
        /// Permet de renvoier tous les locataires d'un propriétaire
        /// </summary>
        /// <param name="idProprietaire">Identifiant du propriétaire des locataires</param>
        /// <returns>Une énumération de toute les locations</returns>
        /// <author>Alexandre Moreau</author>
        public IEnumerable<Locataire> ListerLocataires(int idProprietaire)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                List<Locataire> locataires = new List<Locataire>();
                try
                {
                    string message = $"SELECT * FROM LOCATAIRES_SAE WHERE IDPROPRIETAIRE = {idProprietaire}";

                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour lister les locataires");

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetByte(0);

                            string nom = reader.GetString(1);
                            string prenom = reader.GetString(2);

                            DateTime date = reader.GetDateTime(3);

                            string nationalite = reader.GetString(4);
                            string telephone = reader.GetString(5);
                            string adresseMail = reader.GetString(6);
                            string situationFamilliale = reader.GetString(7);

                            int nbPersonneACharge = reader.GetByte(8);

                            string typeContrat = reader.GetString(9);
                            string profession = reader.GetString(10);

                            decimal salaireMensuelNet = reader.GetDecimal(11);
                            decimal allocFamilliale = reader.GetDecimal(12);
                            decimal allocLogement = reader.GetDecimal(13);
                            decimal autreRevenus = reader.GetDecimal(14);
                            int idproprietaire = reader.GetByte(15);



                            Locataire loc = new Locataire(id, nom, prenom, date, nationalite, telephone, adresseMail, situationFamilliale, nbPersonneACharge, typeContrat, profession, salaireMensuelNet, allocFamilliale, allocLogement, autreRevenus, idproprietaire);
                            locataires.Add(loc);
                        }
                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return locataires;
            }
        }

        /// <summary>
        /// Permet de supprimer un locataire
        /// </summary>
        /// <param name="id">Id du locataire à supprimer</param>
        /// <returns>True si il a bien été supprimé, false sinon</returns>
        /// <author>Nathanael Gallois</author>
        public bool RetirerLocataire(int id)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                bool resultat = false;
                try
                {
                    string message = String.Format("DELETE FROM LOCATAIRES_SAE WHERE IDENTIFIANT = {0}", id);
                    OracleCommand command = new OracleCommand(message, con);

                    con.Open();
                    Console.WriteLine("Connexion réussi pour retirer un locataire");

                    command.ExecuteNonQuery();
                    Console.WriteLine("Requete réussi pour retirer un locataire");
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
        /// Permet de modifier un locataire
        /// </summary>
        /// <param name="locataire">Locataire à modifier</param>
        /// <returns>True s'il a bien été modifié, false sinon</returns>
        /// <author>Hadrien Bourmault</author>
        public bool ModifierLocataire(Locataire locataire)
        {
            using (OracleConnection con = new OracleConnection(ConstConnexion.CONNEXION))
            {
                bool resultat = false;

                {
                    try
                    {

                        string message = $"UPDATE LOCATAIRES_SAE SET NOM = '{locataire.Nom}', PRENOM = '{locataire.Prenom}', DATEDENAISSANCE = '{locataire.DateDeNaissance.ToShortDateString()}', NATIONALITE = '{locataire.Nationalite}',TELEPHONE = '{locataire.Telephone}', ADRESSEMAIL = '{locataire.AdresseMail}', SITUATIONFAMILLIALE = '{locataire.SituationFamilliale}',NBPERSONNEACHARGE = '{locataire.NbPersonneACharge}', TYPECONTRAT = '{locataire.TypeContrat}',PROFESSION = '{locataire.Profession}',SALAIREMENSUELNET = '{locataire.SalaireMensuelNet}',ALLOCFAMILLIALE = '{locataire.AllocFamilliale}', ALLOCLOGEMENT = '{locataire.AllocLogement}', REVENUSEXTERIEUR = '{locataire.RevenusExterieur}' WHERE IDENTIFIANT = '{locataire.Id}'";
                        OracleCommand command = new OracleCommand(message, con);

                        con.Open();
                        Console.WriteLine("Connexion réussi pour la modification d'un locataire");

                        command.ExecuteNonQuery();
                        Console.WriteLine("Requete réussi pour la modification d'un locataire");
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
