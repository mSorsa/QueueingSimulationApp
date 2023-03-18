using MMCNQueueParameters.src;
using QueueingModelsInterfaces.MMCNInterface;

namespace TestQueueingModels
{
    public class MMCNTests
    {
        private readonly IMMCN _mmcn = new MMCNParametersCalculator(new MathematicalHelper.FactorialCalculator());

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 0.722)]
        [InlineData(2.468, 3.211, 2, 3, 0.364)]
        [InlineData(0.359, 0.880, 2, 15, 0.204)]
        [InlineData(0.886, 1.360, 1, 3, 0.575)]
        [InlineData(0.865, 0.260, 2, 3, 0.865)]
        [InlineData(5.0, 0.3, 3, 10, 1.000)]
        [InlineData(2, 3, 1, 3, 0.585)]
        public void CalculateRho_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateServerUtilization(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 2.110)]
        [InlineData(2.468, 3.211, 2, 3, 0.781)]
        [InlineData(0.359, 0.880, 2, 15, 0.426)]
        [InlineData(0.886, 1.360, 1, 3, 0.990)]
        [InlineData(0.865, 0.260, 2, 3, 2.222)]
        [InlineData(5.0, 0.3, 3, 10, 9.780)]
        [InlineData(2, 3, 1, 3, 1.015)]
        public void CalculateL_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateL(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 1.461)]
        [InlineData(2.468, 3.211, 2, 3, 0.334)]
        [InlineData(0.359, 0.880, 2, 15, 1.186)]
        [InlineData(0.886, 1.360, 1, 3, 1.267)]
        [InlineData(0.865, 0.260, 2, 3, 4.939)]
        [InlineData(5.0, 0.3, 3, 10, 10.867)]
        [InlineData(2, 3, 1, 3, 0.579)]
        public void CalculateW_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateW(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 0.961)]
        [InlineData(2.468, 3.211, 2, 3, 0.022)]
        [InlineData(0.359, 0.880, 2, 15, 0.049)]
        [InlineData(0.886, 1.360, 1, 3, 0.531)]
        [InlineData(0.865, 0.260, 2, 3, 1.093)]
        [InlineData(5.0, 0.3, 3, 10, 7.534)]
        [InlineData(2, 3, 1, 3, 0.246)]
        public void CalculateWq_ValidInputs_ReturnsCorrectResults(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateWq(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 1.388)]
        [InlineData(2.468, 3.211, 2, 3, 0.052)]
        [InlineData(0.359, 0.880, 2, 15, 0.018)]
        [InlineData(0.886, 1.360, 1, 3, 0.415)]
        [InlineData(0.865, 0.260, 2, 3, 0.492)]
        [InlineData(5.0, 0.3, 3, 10, 6.780)]
        [InlineData(2, 3, 1, 3, 0.431)]
        public void CalculateLq_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateLq(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 0.278)]
        [InlineData(2.468, 3.211, 2, 3, 0.459)]
        [InlineData(0.359, 0.880, 2, 15, 0.661)]
        [InlineData(0.886, 1.360, 1, 3, 0.425)]
        [InlineData(0.865, 0.260, 2, 3, 0.050)]
        [InlineData(5.0, 0.3, 3, 10, 0.000)]
        [InlineData(2, 3, 1, 3, 0.415)]
        public void CalculateP0_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculatePZero(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 0.037)]
        [InlineData(2.468, 3.211, 2, 3, 0.052)]
        [InlineData(0.359, 0.880, 2, 15, 0.000)]
        [InlineData(0.886, 1.360, 1, 3, 0.118)]
        [InlineData(0.865, 0.260, 2, 3, 0.492)]
        [InlineData(5.0, 0.3, 3, 10, 0.820)]
        [InlineData(2, 3, 1, 3, 0.123)]
        public void CalculatePn_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculatePn(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 1.444)]
        [InlineData(2.468, 3.211, 2, 3, 2.339)]
        [InlineData(0.359, 0.880, 2, 15, 0.359)]
        [InlineData(0.886, 1.360, 1, 3, 0.782)]
        [InlineData(0.865, 0.260, 2, 3, 0.450)]
        [InlineData(5.0, 0.3, 3, 10, 0.900)]
        [InlineData(2, 3, 1, 3, 1.754)]
        public void CalculateLambdaE_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateLambdaE(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }
    }
}
