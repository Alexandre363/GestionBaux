using API.Data;
using API.Model;


namespace Test_projet_location
{
    public class TestImmeuble
    {
        private static ImmeubleManager immeubleDAO = ImmeubleManager.Instance;

        /// <summary>
        /// Liste les ids des baux d'un proprietaire
        /// </summary>
        /// <param name="proprietaire">un proprietaire</param>
        /// <returns>retourne une liste d'entier</returns>
        private static List<int> IdImmeuble(Proprietaire proprietaire)
        {
            List<int> ids = new List<int>();
            foreach (Immeuble b in immeubleDAO.ListerImmeuble(proprietaire.Id))
            {
                ids.Add(b.Id);
            }
            return ids;
        }

        /// <summary>
        /// Supprime toutes les immeubles d'une liste d'entier qui correspond a des ids existant
        /// </summary>
        /// <param name="ids">liste d'entier</param>
        private static void SupprimerImmeuble(List<int> ids)
        {
            foreach (int id in ids) immeubleDAO.RetirerImmeuble(id);
        }

        /// <summary>
        /// Permet de créer un propriétaire par défaut
        /// </summary>
        /// <returns>Objet Proprietaire</returns>
        /// <author>Lakhdar Gibril</author>
        private Proprietaire CreateProprietaire()
        {
            return ProprietaireManager.Instance.ObtenirProprietaireParMailMdp("testunit", "testunit"); ;
        }

        /// <summary>
        /// Permet de créer un immeuble par défaut
        /// </summary>
        /// <param name="proprietaire">propriétaire de la location</param>
        /// <returns>Objet Immeuble</returns>
        private Immeuble CreateImmeuble(Proprietaire proprietaire)
        {
            return new Immeuble(1, "Markus", "11 avenue des Deez", "RDC", "10000", "Troyes", "France", proprietaire.Id);
        }


        [Fact]
        public void TestAjoutImmeuble()
        {
            Proprietaire proprietaire = CreateProprietaire();
            SupprimerImmeuble(IdImmeuble(proprietaire));
            Immeuble immeuble = CreateImmeuble(proprietaire);

            immeubleDAO.AjouterImmeuble(immeuble);
            immeuble.Id = IdImmeuble(proprietaire)[0];
            Assert.Contains(immeuble, immeubleDAO.ListerImmeuble(proprietaire.Id));

            SupprimerImmeuble(IdImmeuble(proprietaire));

        }

            ///<author>Lakhdar Gibril</author>
        [Fact]
        public void TestSuppressionImmeuble()
        {
            Proprietaire proprietaire = CreateProprietaire();
            SupprimerImmeuble(IdImmeuble(proprietaire));
            Immeuble immeuble = CreateImmeuble(proprietaire);

            immeubleDAO.AjouterImmeuble(immeuble);
            immeuble.Id = IdImmeuble(proprietaire)[0];
            Assert.Contains(immeuble, immeubleDAO.ListerImmeuble(immeuble.IdProprietaire));

            immeubleDAO.RetirerImmeuble(immeuble.Id);
            Assert.DoesNotContain(immeuble, immeubleDAO.ListerImmeuble(immeuble.IdProprietaire));

            SupprimerImmeuble(IdImmeuble(proprietaire));
        }

        [Fact]
        public void TestModificationImmeuble()
        {
            Proprietaire proprietaire = CreateProprietaire();
            SupprimerImmeuble(IdImmeuble(proprietaire));
            Immeuble immeuble = CreateImmeuble(proprietaire);

            immeubleDAO.AjouterImmeuble(immeuble);
            Assert.Contains(immeuble, immeubleDAO.ListerImmeuble(immeuble.IdProprietaire));

            immeuble.Ville = "Dijon";
            immeubleDAO.ModifierImmeuble(immeuble);
            Assert.Contains(immeuble, immeubleDAO.ListerImmeuble(immeuble.IdProprietaire));

            SupprimerImmeuble(IdImmeuble(proprietaire));
        }
        
    }
}
