using API.Model;

namespace Test_projet_location
{
    public class TestLocataire
    {
        private static LocataireManager dao = LocataireManager.Instance;

        /// <summary>
        /// Permet de créer un locataire par défaut
        /// </summary>
        /// <returns>Objet Locataire</returns>
        /// <author>Lakhdar Gibril</author>
        private static void CreateLocataire(Proprietaire proprietaire)
        {
            Locataire locataireBarbarus = new Locataire(0, "Barbara", "bidule", Convert.ToDateTime(DateTime.Now.ToShortDateString()), "21000", "Dijon", "France", "celib", 3, "oui", "touriste", 10, 100, 150, 10, proprietaire.Id);

            dao.AjouterLocataire(locataireBarbarus);
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
        /// Supprime toutes les locataires d'une liste d'entier qui correspond a des ids existant
        /// </summary>
        /// <param name="ids">liste d'entier</param>
        private static void SupprimerLocataire(List<int> ids)
        {
            foreach (int id in ids) LocataireManager.Instance.RetirerLocataire(id);
        }

        /// <summary>
        /// Reinitialise toutes les données d'un proprietaire
        /// </summary>
        /// <param name="proprietaire">un proprietaire</param>
        private static void Reinitialiser(Proprietaire proprietaire)
        {
            SupprimerLocataire(IdLocataire(proprietaire));
        }

        [Fact]
        public void TestAjouterLocataire()
        {
            Proprietaire proprietaire = CreateProprietaire();
            Reinitialiser(proprietaire);

            Locataire locataireBarbarus = new Locataire(0, "Barbara", "bidule", Convert.ToDateTime(DateTime.Now.ToShortDateString()), "21000", "Dijon", "France", "celib", 3, "oui", "touriste", 10, 100, 150, 10, proprietaire.Id);
            Locataire loc1 = new Locataire(0, "john", "atan", Convert.ToDateTime(DateTime.Now.ToShortDateString()), "21000", "Dijon", "France", "bilec", 3, "non", "etsiruot", 150, 15, 15, 0, proprietaire.Id);

            dao.AjouterLocataire(locataireBarbarus);
            dao.AjouterLocataire(loc1);

            List<int> idLocataire = IdLocataire(proprietaire);
            locataireBarbarus.Id = idLocataire[0];
            loc1.Id = idLocataire[1];

            Assert.Contains(locataireBarbarus, dao.ListerLocataire(proprietaire.Id));
            Assert.Contains(loc1, dao.ListerLocataire(proprietaire.Id));
            Reinitialiser(proprietaire);
        }


        [Fact]
        public void TestModifierLocataire()
        {
            Proprietaire proprietaire = CreateProprietaire();
            Reinitialiser(proprietaire);

            CreateLocataire(proprietaire);

            List<int> idLocataire = IdLocataire(proprietaire);

            Locataire locataireBarbarus = new Locataire(idLocataire[0], "Barbara", "bidule", Convert.ToDateTime(DateTime.Now.ToShortDateString()), "21000", "Dijon", "France", "celib", 3, "oui", "touriste", 10, 100, 150, 10, proprietaire.Id);
            dao.ModifierLocataire(locataireBarbarus);
            Assert.Contains(locataireBarbarus, dao.ListerLocataire(proprietaire.Id));
            Reinitialiser(proprietaire);
        }

        [Fact]
        public void TestSuppressionLocataire()
        {

            Proprietaire proprietaire = CreateProprietaire();
            Reinitialiser(proprietaire);

            Locataire loc1 = new Locataire(0, "john", "atan", Convert.ToDateTime(DateTime.Now.ToShortDateString()), "21000", "Dijon", "France", "bilec", 3, "non", "etsiruot", 150, 15, 15, 0, proprietaire.Id);
            dao.AjouterLocataire(loc1);
            Assert.Contains(loc1, dao.ListerLocataire(proprietaire.Id));
            List<int> idLocataire = IdLocataire(proprietaire);
            dao.RetirerLocataire(idLocataire[0]);
            Assert.DoesNotContain(loc1, dao.ListerLocataire(proprietaire.Id));
            Reinitialiser(proprietaire);
        }

    }
}
