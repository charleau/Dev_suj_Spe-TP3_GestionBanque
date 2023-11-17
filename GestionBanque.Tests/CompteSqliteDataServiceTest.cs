﻿using GestionBanque.Models;
using GestionBanque.Models.DataService;

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
    public  class CompteSqliteDataServiceTest
    {
        private const string CheminBd = "test.bd";

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Get_ShouldBeValid()
        {
            // Préparation
            CompteSqliteDataService ds = new CompteSqliteDataService(CheminBd);
            Compte compteAttendu = new Compte(1, "9864", 831.76, 1);

            // Exécution
            Compte? compteActuel = ds.Get(1);

            // Affirmation
            Assert.Equal(compteAttendu, compteActuel);
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Update_ShouldBeEqual()
        {
            CompteSqliteDataService ds = new CompteSqliteDataService(CheminBd);

            Compte cmptTest = new Compte(1, "9864", 123.45, 1);

            ds.Update(cmptTest);

            Assert.Equal(cmptTest, ds.Get(1));
        }

        [Fact]
        [AvantApresDataService(CheminBd)]
        public void Update_ShouldBenotvalid()
        {
            CompteSqliteDataService ds = new CompteSqliteDataService(CheminBd);

            Compte cmptTest = new Compte(1, "9864", -123.45, 1);

            Assert.NotEqual(cmptTest, ds.Get(1));
        }
    }
}