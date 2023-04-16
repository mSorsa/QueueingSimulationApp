using MMCNQueueParameters.src;
using QueueingModelsInterfaces.MMCNInterface;

namespace TestQueueingModels
{
    public class MMCNTests
    {
        private IMMCN _mmcn;
        private readonly FactorialCalculator _factorialCalculator = new();

        [Theory]
        [InlineData(2.0, 2.0, 2, 2, 0.400)]
        [InlineData(1.5, 2.0, 1, 7, 0.722)]
        [InlineData(2.468, 3.211, 2, 3, 0.364)]
        [InlineData(0.359, 0.880, 2, 15, 0.204)]
        [InlineData(0.886, 1.360, 1, 3, 0.575)]
        [InlineData(0.865, 0.260, 2, 3, 0.860)]
        [InlineData(5.0, 0.3, 3, 10, 1.000)]
        [InlineData(2, 3, 1, 3, 0.585)]
        public void CalculateRho_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            this._mmcn = new MMCNParametersCalculator(this._factorialCalculator, lam, mu, c, n);
            // Act
            var actual = this._mmcn.CalculateCapacityUtilization();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(2.0, 2.0, 2, 2, 0.800)]
        [InlineData(1.5, 2.0, 1, 7, 2.110)]
        [InlineData(2.468, 3.211, 2, 3, 0.781)]
        [InlineData(0.359, 0.880, 2, 15, 0.426)]
        [InlineData(0.886, 1.360, 1, 3, 0.990)]
        [InlineData(0.865, 0.260, 2, 3, 2.203)]
        [InlineData(5.0, 0.3, 3, 10, 9.780)]
        [InlineData(2, 3, 1, 3, 1.015)]
        public void CalculateL_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            this._mmcn = new MMCNParametersCalculator(this._factorialCalculator, lam, mu, c, n);
            // Act
            var actual = this._mmcn.CalculateL();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(2.0, 2.0, 2, 2, 0.500)]
        [InlineData(1.5, 2.0, 1, 7, 1.461)]
        [InlineData(2.468, 3.211, 2, 3, 0.334)]
        [InlineData(0.359, 0.880, 2, 15, 1.186)]
        [InlineData(0.886, 1.360, 1, 3, 1.267)]
        [InlineData(0.865, 0.260, 2, 3, 4.925)]
        [InlineData(5.0, 0.3, 3, 10, 10.867)]
        [InlineData(2, 3, 1, 3, 0.579)]
        public void CalculateW_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            this._mmcn = new MMCNParametersCalculator(this._factorialCalculator, lam, mu, c, n);
            // Act
            var actual = this._mmcn.CalculateW();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(2.0, 2.0, 2, 2, 0.000)]
        [InlineData(1.5, 2.0, 1, 7, 0.961)]
        [InlineData(2.468, 3.211, 2, 3, 0.022)]
        [InlineData(0.359, 0.880, 2, 15, 0.049)]
        [InlineData(0.886, 1.360, 1, 3, 0.531)]
        [InlineData(0.865, 0.260, 2, 3, 1.079)]
        [InlineData(5.0, 0.3, 3, 10, 7.534)]
        [InlineData(2, 3, 1, 3, 0.246)]
        public void CalculateWq_ValidInputs_ReturnsCorrectResults(double lam, double mu, int c, int n, double expected)
        {
            this._mmcn = new MMCNParametersCalculator(this._factorialCalculator, lam, mu, c, n);
            // Act
            var actual = this._mmcn.CalculateWQ();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(2.0, 2.0, 2, 2, 0.000)]
        [InlineData(1.5, 2.0, 1, 7, 1.388)]
        [InlineData(2.468, 3.211, 2, 3, 0.052)]
        [InlineData(0.359, 0.880, 2, 10, 0.018)]
        [InlineData(0.886, 1.360, 1, 3, 0.415)]
        [InlineData(0.865, 0.260, 2, 3, 0.483)]
        [InlineData(5.0, 0.3, 3, 10, 6.780)]
        [InlineData(2, 3, 1, 3, 0.431)]
        public void CalculateLq_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            this._mmcn = new MMCNParametersCalculator(this._factorialCalculator, lam, mu, c, n);
            // Act
            var actual = this._mmcn.CalculateLQ();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(2.0, 2.0, 2, 2, 0.400)]
        [InlineData(1.5, 2.0, 1, 7, 0.278)]
        [InlineData(2.468, 3.211, 2, 3, 0.459)]
        [InlineData(0.359, 0.880, 2, 15, 0.661)]
        [InlineData(0.886, 1.360, 1, 3, 0.425)]
        [InlineData(0.865, 0.260, 2, 3, 0.052)]
        [InlineData(5.0, 0.3, 3, 10, 0.000)]
        [InlineData(2, 3, 1, 3, 0.415)]
        public void CalculateP0_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            this._mmcn = new MMCNParametersCalculator(this._factorialCalculator, lam, mu, c, n);
            // Act
            var actual = this._mmcn.CalculatePZero();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(2.0, 2.0, 2, 2, 0.200)]
        [InlineData(1.5, 2.0, 1, 7, 0.037)]
        [InlineData(2.468, 3.211, 2, 3, 0.052)]
        [InlineData(0.359, 0.880, 2, 15, 0.000)]
        [InlineData(0.886, 1.360, 1, 3, 0.118)]
        [InlineData(0.865, 0.260, 2, 3, 0.483)]
        [InlineData(5.0, 0.3, 3, 10, 0.820)]
        [InlineData(2, 3, 1, 3, 0.123)]
        public void CalculatePn_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            this._mmcn = new MMCNParametersCalculator(this._factorialCalculator, lam, mu, c, n);
            // Act
            var actual = this._mmcn.CalculatePN();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(2.0, 2.0, 2, 2, 1.600)]
        [InlineData(1.5, 2.0, 1, 7, 1.444)]
        [InlineData(2.468, 3.211, 2, 3, 2.339)]
        [InlineData(0.359, 0.880, 2, 15, 0.359)]
        [InlineData(0.886, 1.360, 1, 3, 0.782)]
        [InlineData(0.865, 0.260, 2, 3, 0.447)]
        [InlineData(5.0, 0.3, 3, 10, 0.900)]
        [InlineData(2, 3, 1, 3, 1.754)]
        public void CalculateLambdaE_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int n, double expected)
        {
            this._mmcn = new MMCNParametersCalculator(this._factorialCalculator, lam, mu, c, n);
            // Act
            var actual = this._mmcn.CalculateLambdaEffective();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }
    }
}
