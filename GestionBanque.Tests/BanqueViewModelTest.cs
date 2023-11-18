using GestionBanque.Models.DataService;
using GestionBanque.ViewModels;
using GestionBanque.ViewModels.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Tests
{
    public class BanqueViewModelTest
    {

        private readonly Mock<IInteractionUtilisateur> _interUtilMock = new Mock<IInteractionUtilisateur>();
        private readonly Mock<IDataService<BanqueViewModel>> _pDataService = new Mock<IDataService<BanqueViewModel>>();

        public BanqueViewModelTest()
        {
            // Configuration du Mock pour IInteractionUtilisateur dans le constructeur
            // car nous voulons le même comportement partout dans les tests
            _interUtilMock.Setup(iu => iu.AfficherMessageErreur(It.IsAny<string>()));
            _interUtilMock.Setup(iu => iu.PoserQuestion(It.IsAny<string>())).Returns(true);
        }

        [Fact]
        public void Constructeur_ShouldBeValid()
        {
            // Préparation
            //_pDataService.Setup(pds => pds.GetAll()).Returns()
        }
    }
}
