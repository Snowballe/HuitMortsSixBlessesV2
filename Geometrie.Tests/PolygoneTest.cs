using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HuitMortsSixBlesses.Tests
{
    public class PolygoneTest
    {
        [Fact]
        public void Polygone_Indexeur_voirSiLesPointsSontDansLOrdre()
        {
            //arrange
            var p1 = new Ligne(1, 9);
            var p2 = new Ligne(22, 76);
            var p3 = new Ligne(128, 876);

            var t = new Panier_Fournisseur(p1, p2, p3);
            //act
            var pRecup1 = t[0];
            var pRecup2 = t[1];
            var pRecup3 = t[2];

            //assert
            Assert.NotNull(pRecup1);
            Assert.NotNull(pRecup2);
            Assert.NotNull(pRecup3);
            Assert.Equal(p1, pRecup1);
            Assert.Equal(p2, pRecup2);
            Assert.Equal(p3, pRecup3);
        }

        [Fact]
        public void Polygone_Count_voirSiCEstBon()
        {
            //arrange
            var p1 = new Ligne(1, 9);
            var p2 = new Ligne(22, 76);
            var p3 = new Ligne(128, 876);
            var p4 = new Ligne(4, 654);

            var t = new Panier_Fournisseur(p1, p2, p3);
            var q = new Panier_Adherent(p1, p2, p3, p4);
            //act
            var nbPointsDuTriangle = t.Count;
            var nbPointsDuQuadrilatere = q.Count;

            //assert
            Assert.Equal(3, nbPointsDuTriangle);
            Assert.Equal(4, nbPointsDuQuadrilatere);
        }

        [Fact]
        public void Polygone_Contructeur_LeveUneErreurSiUnPointEstNul()
        {
            //arrange
            var p1 = new Ligne(1, 9);
            Ligne p2 = null;
            var p3 = new Ligne(128, 876);

            var ex = Assert.Throws<GeometrieException>(() => new Panier_Fournisseur(p1, p2, p3));

            Assert.Equal(TypesDeForme.Polygone, ex.Type);
        }

        [Fact]
        public void Polygone_CalculerPerimetre_VerifierLaValeur()
        {
            //arrange
            var p1 = new Ligne(0, 0);
            var p2 = new Ligne(0, 1);
            var p3 = new Ligne(1, 1);
            var p4 = new Ligne(1, 0);

            var t = new Panier_Fournisseur(p1, p2, p3);
            var q = new Panier_Adherent(p1, p2, p3, p4);
            //act
            var periTriangle = t.CalculerPerimetre();
            var periQuadrilatere = q.CalculerPerimetre();

            //assert
            Assert.Equal(2 + Math.Sqrt(2), periTriangle);
            Assert.Equal(4, periQuadrilatere);
        }

        [Fact]
        public void Polygone_ToString_RenvoieQuelquechose()
        {
            //arrange
            var p1 = new Ligne(0, 0);
            var p2 = new Ligne(0, 1);
            var p3 = new Ligne(1, 1);
            var p4 = new Ligne(1, 0);

            var t = new Panier_Fournisseur(p1, p2, p3);
            var q = new Panier_Adherent(p1, p2, p3, p4);
            //act
            var sTriangle = t.ToString();
            var sQuadrilatere = q.ToString();

            //assert
            Assert.NotNull(sTriangle);
            Assert.NotNull(sQuadrilatere);
            Assert.NotEmpty(sTriangle);
            Assert.NotEmpty(sQuadrilatere);
        }

        [Fact]
        public void Polygone_GetEnumerator_voirSiCEstBon()
        {
            //arrange
            var p1 = new Ligne(1, 9);
            var p2 = new Ligne(22, 76);
            var p3 = new Ligne(128, 876);
            var p4 = new Ligne(4, 654);

            var t = new Panier_Fournisseur(p1, p2, p3);
            var q = new Panier_Adherent(p1, p2, p3, p4);
            //act


            //assert
            Assert.NotEmpty(t);
            Assert.NotEmpty(q);
            Assert.Equal(new Ligne[] { p1, p2, p3 }, t);
            Assert.Equal(new Ligne[] { p1, p2, p3, p4 }, q);
        }
    }
}
