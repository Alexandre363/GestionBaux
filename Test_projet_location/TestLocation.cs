using API.Model;

namespace Test_projet_location
{
    public class TestLocation
    {

        private LocationManager dao = LocationManager.Instance;

        /// <summary>
        /// Permet de créer une location par défaut
        /// </summary>
        /// <returns>Objet Location</returns>
        /// <author>Lakhdar Gibri</author>
        internal static void CreateLocation(Proprietaire proprietaire)
        {
            Location loc = new Location(0, "Rimbaud", "21 Avenue du sommeil", "RDC, Rimbaud", "21000", "Dijon", "France", 1, proprietaire.Id, true, true, "hier", 30, 1, true, true, 3);
            LocationManager.Instance.AjouterLocation(loc);
        }
        /// <summary>
        /// Créer un propriétaire par défaut
        /// </summary>
        /// <returns>Objet Propriétaire</returns>
        /// <author>Lakhdar Gibril</author>
        public static Proprietaire CreateProprietaire()
        {
            return ProprietaireManager.Instance.ObtenirProprietaireParMailMdp("testunit", "testunit"); ;
        }

        /// <summary>
        /// Liste les ids des locations d'un proprietaire
        /// </summary>
        /// <param name="proprietaire">un proprietaire</param>
        /// <returns>retourne une liste d'entier</returns>
        public static List<int> IdLocation(Proprietaire proprietaire)
        {
            List<int> ids = new List<int>();
            foreach (Location l in LocationManager.Instance.ListerLocation(proprietaire.Id))
            {
                ids.Add(l.Id);
            }
            return ids;
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
        /// Reinitialise toutes les données d'un proprietaire
        /// </summary>
        /// <param name="proprietaire">un proprietaire</param>
        private static void Reinitialiser(Proprietaire proprietaire)
        {
            SupprimerLocation(IdLocation(proprietaire));
        }

        [Fact]
        public void TestAjout()
        {
            Proprietaire proprietaire = CreateProprietaire();
            Reinitialiser(proprietaire);

            Location location = new Location(0, "loca4", "Scheisse", "", "7", "Berlin", "Allemagne", 0, proprietaire.Id, true, true, "hier", 30, 1, true, true, 3);
            Location location3 = new Location(0, "loca6", "8", "", "7", "Berlin", "Allemagne", 0, proprietaire.Id, true, true, "hier", 30, 1, true, true, 3);

            dao.AjouterLocation(location);
            dao.AjouterLocation(location3);
            List<int> idLocation = IdLocation(proprietaire);

            location.Id = idLocation[0];
            location3.Id = idLocation[1];

            Assert.Contains(location, dao.ListerLocation(proprietaire.Id));
            Assert.Contains(location3, dao.ListerLocation(proprietaire.Id));
            Reinitialiser(proprietaire);
        }

        [Fact]
        public void TestSuppressionLocation()
        {
            Proprietaire proprietaire = CreateProprietaire();
            Reinitialiser(proprietaire);

            Location locationJaximus = new Location(0, "Jaximus", "7 avenue des Bourgognes", "21000 Saint-Julien-Les-Villas", "21000", "Dijon", "France", 1, proprietaire.Id, true, true, "hier", 30, 1, true, true, 3);

            dao.AjouterLocation(locationJaximus);
            Assert.Contains(locationJaximus, dao.ListerLocation(proprietaire.Id));
            List<int> idLocation = IdLocation(proprietaire);

            dao.RetirerLocation(idLocation[0]);

            Assert.DoesNotContain(locationJaximus, dao.ListerLocation(proprietaire.Id));

            Reinitialiser(proprietaire);
        }

        [Fact]
        public void TestModifierLocation()
        {
            Proprietaire proprietaire = CreateProprietaire();
            Reinitialiser(proprietaire);
            CreateLocation(proprietaire);

            List<int> idLocation = IdLocation(proprietaire);

            Location locationBarbarus = new Location(idLocation[0], "Barbarus", "7 avenue des Bourgognes", "21000 Saint-Julien-Les-Villas", "21000", "Dijon", "France", 1, proprietaire.Id, true, true, "hier", 30, 1, true, true, 3);

            dao.ModifierLocation(locationBarbarus);
            Assert.Contains(locationBarbarus, dao.ListerLocation(proprietaire.Id));


            Reinitialiser(proprietaire);
        }
    }
}
