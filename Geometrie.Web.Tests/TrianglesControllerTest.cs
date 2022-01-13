using Geometrie.Web.Controllers;
using Geometrie.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HuitMortsSixBlesses.Web.Tests
{
    public class TrianglesControllerTest
    {
        [Fact]
        public void TrianglesController_Index_VerifierTypeDeVueEtModele()
        {
            //ARRANGE
            //pr�parer un mock du service
            var mock = new Mock<IHuitMortsSixBlessesService>();
            //je pr�pare un faux r�sultat d'appel du service
            var liste = new List<Panier_Fournisseur>();
            //je mets �a dans mon mock sous forme d'une fausse m�thode
            mock.Setup(service => service.GetAllTriangles()).Returns(liste);
            //instancier le controller avec ce mock
            var controller = new TrianglesController(mock.Object);

            //ACT
            var result = controller.Index();

            //ASSERT
            //V�rifier que je re�ois une vue
            Assert.IsType<ViewResult>(result);
            //v�rifier le modele
            Assert.Equal(liste, (result as ViewResult).Model as IEnumerable<Panier_Fournisseur>);

            //Utilit� du mock : v�rifier les appels des objets mock�s
            //Ici je v�rifie que la m�thode GetAllTriangles a �t� appel�e une fois
            mock.Verify(service => service.GetAllTriangles(), Times.Once);

        }


        [Fact]
        public void TrianglesController_Ajouter_GET_VerifierTypeDeVueEtModele()
        {
            //ARRANGE
            var mock = new Mock<IHuitMortsSixBlessesService>();
            var controller = new TrianglesController(mock.Object);

            //ACT
            var result = controller.Ajouter();

            //ASSERT
            //V�rifier que je re�ois une vue
            Assert.IsType<ViewResult>(result);
            //v�rifier le modele
            Assert.IsType<TriangleVM>((result as ViewResult).Model);
        }

        [Fact]
        public void TrianglesController_Ajouter_POST_VerifierTypeDeVueEtModele()
        {
            //ARRANGE
            //pr�parer un mock du service
            var mock = new Mock<IHuitMortsSixBlessesService>();
            //je pr�pare un faux r�sultat d'appel du service
            var triangle = new Panier_Fournisseur(new Ligne(1,1), new Ligne(2, 1), new Ligne(2,2));
            //je mets �a dans mon mock sous forme d'une fausse m�thode
            mock.Setup(service => service.Insert(It.IsAny<Panier_Fournisseur>())).Returns(triangle);
            //instancier le controller avec ce mock
            var controller = new TrianglesController(mock.Object);


            //ACT
            var vm = new TriangleVM { X1 = 1, Y1 = 1, X2 = 2, Y2 = 1, X3 = 2, Y3 = 2 };
            var result = controller.Ajouter(vm);

            //ASSERT
            //V�rifier que je re�ois une vue
            Assert.IsType<RedirectToActionResult>(result);

            //Utilit� du mock : v�rifier les appels des objets mock�s
            //Ici je v�rifie que la m�thode Insert a �t� appel�e une fois
            mock.Verify(service => service.Insert(It.IsAny<Panier_Fournisseur>()), Times.Once);

        }

        [Fact]
        public void TrianglesController_Ajouter_POST_NONVALIDE_VerifierTypeDeVueEtModele()
        {
            //ARRANGE
            //pr�parer un mock du service
            var mock = new Mock<IHuitMortsSixBlessesService>();
            //je pr�pare un faux r�sultat d'appel du service
            var triangle = new Panier_Fournisseur(new Ligne(1, 1), new Ligne(2, 1), new Ligne(2, 2));
            //je mets �a dans mon mock sous forme d'une fausse m�thode
            mock.Setup(service => service.Insert(It.IsAny<Panier_Fournisseur>())).Returns(triangle);
            //instancier le controller avec ce mock
            var controller = new TrianglesController(mock.Object);


            //ACT
            var vm = new TriangleVM { X1 = 1, Y1 = 1, X2 = 2, Y2 = 1, X3 = 2, Y3 = 2 };
            controller.ModelState.AddModelError("X1", "pas bon");
            var result = controller.Ajouter(vm);

            //ASSERT
            //V�rifier que je re�ois une vue
            Assert.IsType<ViewResult>(result);

            //Utilit� du mock : v�rifier les appels des objets mock�s
            //Ici je v�rifie que la m�thode Insert a �t� appel�e une fois
            mock.Verify(service => service.Insert(It.IsAny<Panier_Fournisseur>()), Times.Never);

        }
    }
}
