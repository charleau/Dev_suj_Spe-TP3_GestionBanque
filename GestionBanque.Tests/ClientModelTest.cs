using GestionBanque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Tests
{
    public class ClientModelTest
    {

/**************************************************************************************************
                                                                                      Setter de nom
**************************************************************************************************/

        [Fact]
        public void TestSetterNom_ShouldBeEqual()
        {
            Client client = new Client(1, "Ndong", "Saliou", "saliou@ndong.com");

            client.Nom = "Test";

            Assert.Equal("Test", client.Nom);
        }

        [Fact]
        public void TestSetterPrenom_ShouldThrowException()
        {
            Client client = new Client(1, "Ndong", "Saliou", "saliou@ndong.com");

            Assert.Throws<ArgumentException>(() => client.Nom = "");
        }

/**************************************************************************************************
                                                                                   Setter de prenom
**************************************************************************************************/

        [Fact]
        public void TestSetterPrenom_ShouldBeEqual()
        {
            Client client = new Client(1, "Ndong", "Saliou", "saliou@ndong.com");

            client.Prenom = "Test";

            Assert.Equal("Test", client.Prenom);
        }

        [Fact]
        public void TestSetterNom_ShouldThrowException()
        {
            Client client = new Client(1, "Ndong", "Saliou", "saliou@ndong.com");

            Assert.Throws<ArgumentException>(() => client.Prenom = "");
        }

/**************************************************************************************************
                                                                                 Setter de courriel
**************************************************************************************************/

        [Theory]
        [InlineData("saliou@senegal")]
        [InlineData("")]
        [InlineData("saliou.com")]
        [InlineData("saliou")]
        public void TestSetterCourriel_ShouldThrowExcepetion(string testEmail)
        {
            Client client = new Client(1, "Ndong", "Saliou", "saliou@ndong.com");

            Assert.Throws<ArgumentException>(() => client.Courriel = testEmail);
        }

        [Fact]
        public void TestSetterCourriel_ShouldBeEqual()
        {
            Client client = new Client(1, "Ndong", "Saliou", "saliou@ndong.com");

            client.Courriel = "saliou@senegal.com";

            Assert.Equal("saliou@senegal.com", client.Courriel);
        }
    }
}
