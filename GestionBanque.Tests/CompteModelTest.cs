using GestionBanque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Tests
{
    public class CompteModelTest
    {
        [Fact]

        public void TestDeposer_ShouldBeEqual()
        {
            double montantDepot = 45.50;
            double montantAttendu = 90.05;

            Compte compte = new Compte(1, "cmpt1", 44.55, 2);

            compte.Deposer(montantDepot);

            Assert.Equal(montantAttendu, compte.Balance);
        }

        [Fact]
        public void TestDeposer_ShouldThrowException()
        {
            double montantDepot = -45.43;

            Compte compte = new Compte(1, "cmpt1", 52.25, 2);

            Assert.Throws<ArgumentOutOfRangeException>(() => compte.Deposer(montantDepot));
        }

        [Fact]
        public void TestRetirer_ShouldBeEqual()
        {
            double montantRetrait = 45.43;
            double montantAttendu = 60.07;

            Compte compte = new Compte(1, "cmpt1", 105.50, 2);

            compte.Retirer(montantRetrait);

            Assert.Equal(montantAttendu, compte.Balance);
        }

        [Fact]
        public void TestRetirer_ShouldThrowException()
        {
            double montantRetrait = 45.43;

            Compte compte = new Compte(1, "cmpt1", 0.00, 2);

            Assert.Throws<ArgumentOutOfRangeException>(() => compte.Retirer(montantRetrait));
        }
    }
}
