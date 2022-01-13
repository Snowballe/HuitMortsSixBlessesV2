using System;
using Xunit;

namespace HuitMortsSixBlesses.Tests
{
    /// <summary>
    /// Classe de test de la classe <see cref="Ligne"/>
    /// </summary>
    public class PointTest
    {
        /// <summary>
        /// Valide le constructeur de <see cref="Ligne"/>
        /// </summary>
        [Fact]
        public void Point_ValiderConstructeur()
        {
            //Test en 3 étapes SEA Setup / Execute / Assert
            //ou AAA : Arrange / Act /Assert

            //Arrange : je prépare les variables dont j'ai besoin pour tester
            var abs = 3;
            var ord = 4;

            //Act : je lance ce que je veux tester
            var p = new Ligne(abs, ord);

            //Assert : faire toutes les vérifications possibles
            Assert.NotNull(p);
            Assert.IsType<Ligne>(p);
            Assert.Equal(abs, p.X);
            Assert.Equal(ord, p.Y);
        }


        /// <summary>
        /// valide aussi le consructeur, mais avec plusieurs valeurs à
        /// tester
        /// </summary>
        /// <param name="abs">abscisse du point</param>
        /// <param name="ord">ordonnée du point</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(-1, -1)]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(int.MaxValue, int.MaxValue)]
        [InlineData(int.MaxValue, int.MinValue)]
        [InlineData(int.MinValue, int.MaxValue)]
        public void Point_ValiderConstructeurAvecTheory(int abs, int ord)
        {
            //arrange

            //Act : je lance ce que je veux tester
            var p = new Ligne(abs, ord);

            //Assert : faire toutes les vérifications possibles
            Assert.NotNull(p);
            Assert.IsType<Ligne>(p);
            Assert.Equal(abs, p.X);
            Assert.Equal(ord, p.Y);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(-1, -1)]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(int.MaxValue, int.MaxValue)]
        [InlineData(int.MaxValue, int.MinValue)]
        [InlineData(int.MinValue, int.MaxValue)]
        public void Point_ToString_ValiderRetour(int abs, int ord)
        {
            //arrange
            var p = new Ligne(abs, ord);
            //var expected = $"({abs};{ord})";

            //Act : je lance ce que je veux tester
            var result = p.ToString();

            //Assert : faire toutes les vérifications possibles
            Assert.NotNull(result);
            Assert.IsType<string>(result);
            Assert.NotEmpty(result);//ça vérifie qu'il y a au moins un caractère...
                                    //Assert.Equal(expected, result);//ici je vérifie carément que c'est "(X;Y)"
                                    //C'est pas forcément une bonne idée
        }

        [Theory]
        [InlineData(1, 1, 2, 1, 1)]
        [InlineData(1, 1, 4, 1, 3)]
        public void Point_CalculerDistance_ValiderRetour(int abs_A, int ord_A, int abs_B, int ord_B, double expected)
        {
            //arrange
            var pA = new Ligne(abs_A, ord_A);
            var pB = new Ligne(abs_B, ord_B);

            //act
            var result = pA.CalculerDistance(pB);

            //assert
            Assert.IsType<double>(result);
            Assert.True(result >= 0);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Point_CalculerDistance_ArgumentNullException()
        {
            //arrange
            var p1 = new Ligne(3, 4);

            //act & assert d'un coup (pour les exceptions, pas le choix)
            var ex = Assert.Throws<ArgumentException>(() => p1.CalculerDistance(null));

            //autres assert
            Assert.Equal("autrePoint", ex.ParamName);
        }
    }
}
