using API.Data;
using API.Model;

using System.Security.Cryptography;

namespace Test_projet_location
{
    public class TestProprietaire
    {
        private ProprietaireManager dao = ProprietaireManager.Instance;

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


        [Fact]
        public void TestAjoutProprietaire()
        {

            Proprietaire proprio1 = new Proprietaire(1, "1234", "Philipe", "philipe", true, "ici");
            Proprietaire proprio2 = new Proprietaire(2, "DidierLeBG", "Didier", "didier", true, "ici");

            dao.AjouterProprietaire(proprio1);
            dao.AjouterProprietaire(proprio2);

            proprio1.Id = dao.ConnexionProprietaire(proprio1.Mail, proprio1.MotDePasse);
            proprio2.Id = dao.ConnexionProprietaire(proprio2.Mail, proprio2.MotDePasse);

            proprio1.MotDePasse = HashageMotDePasse(proprio1.MotDePasse);
            proprio2.MotDePasse = HashageMotDePasse(proprio2.MotDePasse);

            Assert.Contains(proprio1, dao.ListerProprietaires());
            Assert.Contains(proprio2, dao.ListerProprietaires());

            dao.RetirerProprietaire(proprio1.Id);
            dao.RetirerProprietaire(proprio2.Id);
        }

        /// <author>Lakhdar Gibril</author>
        [Fact]
        public void TestSuppressionProprietaire()
        {
            Proprietaire proprietaire = new Proprietaire(10, "Jaximus", "Jax", "jaximus", true, "ici");
            dao.AjouterProprietaire(proprietaire);
            proprietaire.Id = dao.ConnexionProprietaire(proprietaire.Mail, proprietaire.MotDePasse);

            proprietaire.MotDePasse = HashageMotDePasse(proprietaire.MotDePasse);
            //On teste sa présence dans la base de donnée
            Assert.Contains(proprietaire, dao.ListerProprietaires());

            dao.RetirerProprietaire(proprietaire.Id);
            //On vérifie qu'il a bien été supprimé
            Assert.DoesNotContain(proprietaire, dao.ListerProprietaires());

        }

        [Fact]
        public void TestModifierProprietaire()
        {
            Proprietaire proprietaire = new Proprietaire(10, "Jaximus", "Jax", "jaximus", true, "ici");
            dao.AjouterProprietaire(proprietaire);

            proprietaire.Id = dao.ConnexionProprietaire(proprietaire.Mail, proprietaire.MotDePasse);
            proprietaire.MotDePasse = HashageMotDePasse(proprietaire.MotDePasse);

            Assert.Contains(proprietaire, dao.ListerProprietaires());

            Proprietaire proprietaire2 = new Proprietaire(proprietaire.Id, "4321", "epilihP", "epilihP", true, "ici");
            dao.ModifierProprietaire(proprietaire2);

            proprietaire2.MotDePasse = HashageMotDePasse(proprietaire2.MotDePasse);

            Assert.Contains(proprietaire2, dao.ListerProprietaires());

            dao.RetirerProprietaire(proprietaire2.Id);
        }
    }
}
