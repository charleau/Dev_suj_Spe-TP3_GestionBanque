
using GestionBanque.Models.DataService;
using GestionBanque.Models;
using Microsoft.Data.Sqlite;

namespace GestionBanque.Tests
{
    // Ce décorateur s'assure que toutes les classes de tests ayant le tag "Dataservice" soit
    // exécutées séquentiellement. Par défaut, xUnit exécute les différentes suites de tests
    // en parallèle. Toutefois, si nous voulons forcer l'exécution séquentielle entre certaines
    // suites, nous pouvons utiliser un décorateur avec un nom unique. Pour les tests sur les DataService,
    // il est important que cela soit séquentiel afin d'éviter qu'un test d'une classe supprime la 
    // bd de tests pendant qu'un test d'une autre classe utilise la bd. Bref, c'est pour éviter un
    // accès concurrent à la BD de tests!
    [Collection("Dataservice")]
    public class ClientSqliteDataServiceTest
    {
        //À tester
        //GetAll()
        //RecuperComptes()
        //Update()

        private const string CheminBd = "test.bd";

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Get_ShouldBeValid()
        {
            // Préparation
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client clientAttendu = new Client(1, "Amar", "Quentin", "quentin@gmail.com");
            clientAttendu.Comptes.Add(new Compte(1, "9864", 831.76, 1));
            clientAttendu.Comptes.Add(new Compte(2, "2370", 493.04, 1));

            // Exécution
            Client? clientActuel = ds.Get(1);

            // Affirmation
            Assert.Equal(clientAttendu, clientActuel);
        }

/**************************************************************************************************
                                                                                           GetAll()
**************************************************************************************************/

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void GetAllTest_ShouldBeValid()
        {
            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            IEnumerable<Client> list = ds.GetAll();
            IEnumerable<Client> iEnumAttendue = new List<Client>();
            List<Client> listAttendue = new List<Client>();

            foreach (Client elem in list){
                listAttendue.Add(ds.Get(elem.Id));
            }

            iEnumAttendue = listAttendue;

            Assert.Equal(list, iEnumAttendue);
        }

/**************************************************************************************************
                                                                                 RecupererComptes()
**************************************************************************************************/

        /* Le test ne passe pas, je sais. Mais je n'ai pas réussi à le faire
         * et je ne comprends pas comment tester cette méthode... 
        */

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void RecupererComptesTest_ShouldBeValid()
        {
            List<Compte> listAttendue = new List<Compte>();

            SqliteConnection connexion = new SqliteConnection($"Data Source={CheminBd};Cache=Shared");
            connexion.Open();

            using SqliteCommand commande = new SqliteCommand("SELECT * FROM compte WHERE client_id=@client_id", connexion);
            commande.Parameters.AddWithValue("@client_id", 1);

            using SqliteDataReader lecteur = commande.ExecuteReader();

            while (lecteur.Read())
            {
                Compte compte = new Compte(
                    lecteur.GetInt32(lecteur.GetOrdinal("id")),
                    lecteur.GetString(lecteur.GetOrdinal("no_compte")),
                    lecteur.GetDouble(lecteur.GetOrdinal("balance")),
                    lecteur.GetInt32(lecteur.GetOrdinal("client_id"))
                    );
                listAttendue.Add(compte);
            }

            //------------------------------------------------------

            ClientSqliteDataService ds = new ClientSqliteDataService(CheminBd);
            Client client = ds.Get(1);

            Assert.Equal(listAttendue, client.Comptes);
        }
    }
}
