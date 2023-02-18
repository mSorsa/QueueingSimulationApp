using MathematicalHelper;
using MMCQueueParameters.src;

namespace TestQueueingModels
{
    public class MMCTests
    {
        private static readonly IMMC _mmc = new MMCParametersCalculator(new FactorialCalculator());
        
        [Theory]
        [InlineData(1.0, 2.0, 3, 0.167)]
        [InlineData(2.468, 3.211, 2, 0.384)]
        [InlineData(11, 13, 5, 0.169)]
        public void CalculateRho_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, double expected)
        {
            // Act
            var actual = _mmc.CalculateRho(lam, mu, c);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(11, 13, 5, 0.847)]
        [InlineData(5, 3, 2, 5.455)]
        [InlineData(3.266, 1.280, 10, 2.552)]
        public void CalculateL_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, double expected)
        {
            // Act
            var actual = _mmc.CalculateL(lam, mu, c);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(3.0, 5.0, 2, 0.538)]
        [InlineData(3.266, 1.280, 5, 0.076)]
        [InlineData(0.8, 0.5, 3, 0.187)]
        public void CalculatePZero_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, double expected)
        {
            // Act
            var actual = _mmc.CalculatePZero(lam, mu, c);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

    }
}
