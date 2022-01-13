using System;
using Xunit;

namespace HuitMortsSixBlesses.DAL.Tests
{
    public class PolygoneDepot_DAL_Tests
    {
        [Fact]
        public void PolygoneDepot_DAL_TesterGetAll()
        {
            var depot = new PolygoneDepot_DAL();
            var polygones = depot.GetAll();

            Assert.NotNull(polygones);
        }

        [Fact]
        public void PolygoneDepot_DAL_TesterGetByID()
        {
            var depot = new PolygoneDepot_DAL();
            var polygone = depot.GetByID(3); //Si j'écris ce test il faut que je sois
                                              //sûr que cet ID existera dans ma BDD de test

            Assert.NotNull(polygone);
            Assert.Equal(3,polygone.ID);
            Assert.NotEmpty(polygone.Points);
        }

        [Fact]
        public void PolygoneDepot_DAL_TesterInsert()
        {
            var p1 = new Lignes_DAL(3, 8);
            var p2 = new Lignes_DAL(344, 623);
            var p3 = new Lignes_DAL(12, 876);

            var poly = new Polygone_DAL(new Lignes_DAL[] { p1, p2, p3 });

            var depot = new PolygoneDepot_DAL();

            depot.Insert(poly);

            Assert.NotNull(poly);
            Assert.NotNull(poly.DateCreation); //Si j'ai récupéré la date de création
                                               //, c'est que ça marche
            //Quoi d'autre ?
        }
    }
}
