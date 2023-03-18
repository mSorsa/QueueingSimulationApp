using MathematicalHelper;
using MMCQueueParameters.src;
using QueueingModelsInterfaces.MMCInterface;

namespace TestQueueingModels
{
    public class MMCTests
    {
        [Theory]
        [InlineData(1.0, 2.0, 3, 0.167)]
        [InlineData(2.468, 3.211, 2, 0.384)]
        [InlineData(11, 13, 5, 0.169)]
        public void CalculateRho_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, double expected)
        {
            IMMC _mmc = new MMCParametersCalculator(new FactorialCalculator(), lam, mu, c);
            // Act
            var actual = _mmc.CalculateRho();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(11, 13, 5, 0.847)]
        [InlineData(5, 3, 2, 5.455)]
        [InlineData(3.266, 1.280, 10, 2.552)]
        public void CalculateL_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, double expected)
        {
            IMMC _mmc = new MMCParametersCalculator(new FactorialCalculator(), lam, mu, c);
            // Act
            var actual = _mmc.CalculateL();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(3.0, 5.0, 2, 0.220)]
        [InlineData(3.266, 1.280, 5, 0.826)]
        [InlineData(0.8, 0.5, 3, 2.391)]
        public void CalculateW_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, double expected)
        {
            IMMC _mmc = new MMCParametersCalculator(new FactorialCalculator(), lam, mu, c);
            // Act
            var actual = _mmc.CalculateW();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(3.0, 5.0, 2, 0.020)]
        [InlineData(3.266, 1.280, 5, 0.045)]
        [InlineData(0.8, 0.5, 3, 0.391)]
        public void CalculateWq_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, double expected)
        {
            IMMC _mmc = new MMCParametersCalculator(new FactorialCalculator(), lam, mu, c);
            // Act
            var actual = _mmc.CalculateWq();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(3.0, 5.0, 2, 0.059)]
        [InlineData(3.266, 1.280, 5, 0.146)]
        [InlineData(0.8, 0.5, 3, 0.313)]
        public void CalculateLq_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, double expected)
        {
            IMMC _mmc = new MMCParametersCalculator(new FactorialCalculator(), lam, mu, c);
            // Act
            var actual = _mmc.CalculateLq();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(3.0, 5.0, 2, 0.538)]
        [InlineData(3.266, 1.280, 5, 0.076)]
        [InlineData(0.8, 0.5, 3, 0.187)]
        public void CalculatePZero_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, double expected)
        {
            IMMC _mmc = new MMCParametersCalculator(new FactorialCalculator(), lam, mu, c);
            // Act
            var actual = _mmc.CalculatePZero();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }
    }
}
