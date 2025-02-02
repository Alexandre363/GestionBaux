using API.Model;

namespace Test_projet_location
{
    public class TestBail
    {


        private static BailManager dao = BailManager.Instance;

        /// <summary>
        /// Permet de créer un locataire par défaut
        /// </summary>
        /// <returns>Objet Locataire</returns>
        /// <author>Lakhdar Gibril</author>
        private static void CreateLocataire(Proprietaire proprietaire)
        {
            Locataire loc = new Locataire(1, "Doe", "John", Convert.ToDateTime(DateTime.Now.ToShortDateString()), "Française", "08-12-12-12-12", "johndoe@gmail.com", "célibataire", 0, "CDI", "développeur Pascal", 1200, 0, 0, 0, proprietaire.Id);
            LocataireManager.Instance.AjouterLocataire(loc);
        }

        /// <summary>
        /// Permet de créer une location par défaut
        /// </summary>
        /// <returns>Objet Location</returns>
        /// <author>Lakhdar Gibri</author>
        private static void CreateLocation(Proprietaire proprietaire)
        {
            Location loc = new Location(1, "Rimbaud", "21 Avenue du sommeil", "RDC, Rimbaud", "21000", "Dijon", "France", 0, proprietaire.Id, true, true, "hier", 30, 1, true, true, 3);
            LocationManager.Instance.AjouterLocation(loc);
        }
        /// <summary>
        /// Créer un propriétaire par défaut
        /// </summary>
        /// <returns>Objet Propriétaire</returns>
        /// <author>Lakhdar Gibril</author>
        private static Proprietaire CreateProprietaire()
        {
            return ProprietaireManager.Instance.ObtenirProprietaireParMailMdp("testunit", "testunit"); ;
        }

        /// <summary>
        /// Liste les ids des locations d'un proprietaire
        /// </summary>
        /// <param name="proprietaire">un proprietaire</param>
        /// <returns>retourne une liste d'entier</returns>
        private static List<int> IdLocation(Proprietaire proprietaire)
        {
            List<int> ids = new List<int>();
            foreach (Location l in LocationManager.Instance.ListerLocation(proprietaire.Id))
            {
                ids.Add(l.Id);
            }
            return ids;
        }

        /// <summary>
        /// Liste les ids des locataires d'un proprietaire
        /// </summary>
        /// <param name="proprietaire">un proprietaire</param>
        /// <returns>retourne une liste d'entier</returns>
        private static List<int> IdLocataire(Proprietaire proprietaire)
        {
            List<int> ids = new List<int>();
            foreach (Locataire l in LocataireManager.Instance.ListerLocataire(proprietaire.Id))
            {
                ids.Add(l.Id);
            }
            return ids;
        }

        /// <summary>
        /// Liste les ids des baux d'un proprietaire
        /// </summary>
        /// <param name="proprietaire">un proprietaire</param>
        /// <returns>retourne une liste d'entier</returns>
        private static List<int> IdBail(Proprietaire proprietaire)
        {
            List<int> ids = new List<int>();
            foreach (Bail b in dao.ListerBail(proprietaire.Id))
            {
                ids.Add(b.Identifiant);
            }
            return ids;
        }

        /// <summary>
        /// Permet de créer un bail à partir d'une location
        /// </summary>
        /// <param name="idLocation">id de la location du bail</param>
        /// <param name="idLocataire">id du locataire du bail</param>
        /// <returns>Objet Bail</returns>
        /// <author>Lakhdar Gibril</author>
        private static Bail CreationBail(int idLocation, int idLocataire, Proprietaire proprietaire)
        {
            return new Bail(0, "",idLocataire, idLocation, Convert.ToDateTime(DateTime.Now.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToShortDateString()), "2 mois", 100, 0, proprietaire.Id, "un jour", "demain",false);
        }

        /// <summary>
        /// Supprime toutes les locations d'une liste d'entier qui correspond a des ids existant
        /// </summary>
        /// <param name="ids">liste d'entier</param>
        private static void SupprimerLocation(List<int> ids)
        {
            foreach (int id in ids) LocationManager.Instance.RetirerLocation(id);
        }

        /// <summary>
        /// Supprime toutes les locataires d'une liste d'entier qui correspond a des ids existant
        /// </summary>
        /// <param name="ids">liste d'entier</param>
        private static void SupprimerLocataire(List<int> ids)
        {
            foreach (int id in ids) LocataireManager.Instance.RetirerLocataire(id);
        }

        /// <summary>
        /// Supprime toutes les baux d'une liste d'entier qui correspond a des ids existant
        /// </summary>
        /// <param name="ids">liste d'entier</param>
        private static void SupprimerBail(List<int> ids)
        {
            foreach (int id in ids) BailManager.Instance.AnnulerBail(id);
        }

        /// <summary>
        /// Reinitialise toutes les données d'un proprietaire
        /// </summary>
        /// <param name="proprietaire">un proprietaire</param>
        private static void Reinitialiser(Proprietaire proprietaire)
        {
            SupprimerBail(IdBail(proprietaire));
            SupprimerLocataire(IdLocataire(proprietaire));
            SupprimerLocation(IdLocation(proprietaire));
        }

        /// <summary>
        /// Test de suppression d'un bail
        /// </summary>
        [Fact]
        public void TestSuppressionBail()
        {
            Proprietaire proprietaire = CreateProprietaire();
            Reinitialiser(proprietaire);

            CreateLocataire(proprietaire);
            CreateLocation(proprietaire);

            List<int> idLocataire = IdLocataire(proprietaire);
            List<int> idLocation = IdLocation(proprietaire);

            Bail bail = CreationBail(idLocation[0], idLocataire[0], proprietaire);

            dao.AjouterBail(bail);
            Assert.Contains(bail, dao.ListerBail(proprietaire.Id));

            List<int> idBail = IdBail(proprietaire);
            dao.AnnulerBail(idBail[0]);
            Assert.DoesNotContain(bail, dao.ListerBail(proprietaire.Id));
            Reinitialiser(proprietaire);
        }

        /// <summary>
        /// test d'ajout d'un bail
        /// </summary>
        [Fact]
        public void TestAjouterBail()
        {
            Proprietaire proprietaire = CreateProprietaire();
            Reinitialiser(proprietaire);

            CreateLocataire(proprietaire);
            CreateLocation(proprietaire);

            List<int> idLocataire = IdLocataire(proprietaire);
            List<int> idLocation = IdLocation(proprietaire);


            Bail bail = CreationBail(idLocation[0], idLocataire[0], proprietaire);

            dao.AjouterBail(bail);
            List<int> idBail = IdBail(proprietaire);
            bail.Identifiant = idBail[0];
            Assert.Contains(bail, dao.ListerBail(proprietaire.Id));
            Reinitialiser(proprietaire);
        }
    }
}
