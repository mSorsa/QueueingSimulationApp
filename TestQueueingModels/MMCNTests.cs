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
        [InlineData(0.865, 0.260, 2, 3, 0.860)]
        [InlineData(5.0, 0.3, 3, 10, 1.000)]
        [InlineData(2, 3, 1, 3, 0.415)]
        public void CalculateRho_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateServerUtilization(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 0.722)]
        [InlineData(0.359, 0.880, 2, 15, 0.426)]
        [InlineData(0.886, 1.360, 1, 3, 0.990)]
        [InlineData(0.865, 0.260, 2, 3, 2.203)]
        [InlineData(5.0, 0.3, 3, 10, 9.780)]
        public void CalculateL_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateL(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 1.461)]
        [InlineData(0.359, 0.880, 2, 15, 1.186)]
        [InlineData(0.886, 1.360, 1, 3, 1.267)]
        [InlineData(0.865, 0.260, 2, 3, 4.925)]
        [InlineData(5.0, 0.3, 3, 10, 10.867)]
        public void CalculateW_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateW(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 0.961)]
        [InlineData(0.359, 0.880, 2, 15, 0.049)]
        [InlineData(0.886, 1.360, 1, 3, 0.531)]
        [InlineData(0.865, 0.260, 2, 3, 1.079)]
        [InlineData(5.0, 0.3, 3, 10, 7.534)]
        public void CalculateWq_ValidInputs_ReturnsCorrectResults(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateWq(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 1.388)]
        [InlineData(0.359, 0.880, 2, 15, 0.018)]
        [InlineData(0.886, 1.360, 1, 3, 0.415)]
        [InlineData(0.865, 0.260, 2, 3, 0.483)]
        [InlineData(5.0, 0.3, 3, 10, 6.780)]
        public void CalculateLq_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateLq(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 0.278)]
        [InlineData(0.359, 0.880, 2, 15, 0.661)]
        [InlineData(0.886, 1.360, 1, 3, 0.425)]
        [InlineData(0.865, 0.260, 2, 3, 0.052)]
        [InlineData(5.0, 0.3, 3, 10, 0.000)]
        [InlineData(9, 5, 2, 10, 0.079)]
        public void CalculateP0_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculatePZero(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 0.037)]
        [InlineData(0.359, 0.880, 2, 15, 0.000)]
        [InlineData(0.886, 1.360, 1, 3, 0.118)]
        [InlineData(0.865, 0.260, 2, 3, 0.483)]
        [InlineData(5.0, 0.3, 3, 10, 0.820)]
        public void CalculatePn_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculatePn(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(1.5, 2.0, 1, 7, 1.444)]
        [InlineData(0.359, 0.880, 2, 15, 0.359)]
        [InlineData(0.886, 1.360, 1, 3, 0.782)]
        [InlineData(0.865, 0.260, 2, 3, 0.447)]
        [InlineData(5.0, 0.3, 3, 10, 0.900)]
        public void CalculateLambdaE_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            // Act
            var actual = this._mmcn.CalculateLambdaE(lam, mu, c, n);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }
    }
}
