using MathematicalHelper;
using MMCKKQueueParameters.src;
using QueueingModelsInterfaces.MMCKKInterface;

namespace TestQueueingModels
{
    public class MMCKKTests
    {
        private static readonly FactorialCalculator _factorialCalculator = new();
        private static readonly BigParenCalculator _bigParenCalculator = new(_factorialCalculator);

        // P0
        [Theory]
        [InlineData(1.0, 1.0, 2, 5, 0.019)]
        [InlineData(3.254, 2.284, 2, 2, 0.170)]
        [InlineData(0.225, 1.250, 3, 5, 0.437)]
        [InlineData(0.336, 5, 4, 10, 0.522)]
        [InlineData(6.396, 5, 2, 10, 0.000)]
        [InlineData(1.268, 2.555, 3, 6, 0.085)]
        [InlineData(7.233, 5.560, 2, 10, 0.000)]
        public void CalculatePZero_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);
            // Act
            var actual = _mmckk.CalculatePZero();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        // L
        [Theory]
        [InlineData(6.396, 5.0, 2, 10, 8.437)]
        [InlineData(3, 2.0, 1, 7, 6.333)]
        [InlineData(0.673, 1.263, 2, 12, 8.250)]
        [InlineData(0.250, 0.335, 2, 8, 5.344)]
        [InlineData(0.015, 0.860, 3, 6, 0.103)]
        [InlineData(1.268, 2.555, 3, 6, 2.116)]
        [InlineData(7.233, 5.560, 2, 10, 8.463)]
        public void CalculateL_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);
            // Act
            var actual = _mmckk.CalculateL();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }


        // Lq
        [Theory]
        [InlineData(0.015, 0.860, 4, 6, 0.000)]
        [InlineData(2, 3, 2, 8, 3.075)]
        [InlineData(1.268, 2.555, 3, 6, 0.188)]
        [InlineData(7.233, 5.560, 2, 10, 6.463)]
        public void CalculateLq_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);
            // Act
            var actual = _mmckk.CalculateLq();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        // LambdaE
        [Theory]
        [InlineData(2, 3, 2, 8, 5.910)]
        [InlineData(1.268, 2.555, 3, 6, 4.925)]
        [InlineData(7.233, 5.560, 2, 10, 11.120)]
        public void CalculateLambdaE_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);
            // Act
            var actual = _mmckk.CalculateLambdaE();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        // W
        [Theory]
        [InlineData(0.673, 1.263, 2, 12, 3.269)]
        [InlineData(0.250, 0.335, 2, 8, 8.049)]
        [InlineData(5, 6, 3, 10, 0.361)]
        [InlineData(0.015, 0.860, 4, 6, 1.163)]
        [InlineData(1.268, 2.555, 3, 6, 0.430)]
        [InlineData(7.233, 5.560, 2, 10, 0.761)]
        public void CalculateW_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);
            // Act
            var actual = _mmckk.CalculateW();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(0.673, 1.263, 2, 12, 3.269)]    // Same inputs as original CalcW, since the results should be the same.
        [InlineData(0.250, 0.335, 2, 8, 8.049)]
        [InlineData(5, 6, 3, 10, 0.361)]
        [InlineData(0.015, 0.860, 4, 6, 1.163)]
        [InlineData(1.268, 2.555, 3, 6, 0.430)]
        [InlineData(7.233, 5.560, 2, 10, 0.761)]
        public void CalculateAlternateW_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);
            // Act
            var actual = _mmckk.CalculateW(_mmckk.CalculateL(), _mmckk.CalculateLambdaE());
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }


        // Wq
        [Theory]
        [InlineData(2, 3, 2, 8, 0.520)]
        [InlineData(1.268, 2.555, 3, 6, 0.038)]
        [InlineData(7.233, 5.560, 2, 10, 0.581)]
        public void CalculateWq_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);
            // Act
            var actual = _mmckk.CalculateWq();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(2, 3, 2, 8, 0.520)]    // Same inputs as original CalcWq, since the results should be the same.
        [InlineData(1.268, 2.555, 3, 6, 0.038)]
        [InlineData(7.233, 5.560, 2, 10, 0.581)]
        public void CalculateAlternateWq_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);
            // Act
            var actual = _mmckk.CalculateWq(_mmckk.CalculateLq(), _mmckk.CalculateLambdaE());
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        // Rho
        [Theory]
        [InlineData(2, 3, 2, 8, 0.985)]
        [InlineData(1.268, 2.555, 3, 6, 0.643)]
        [InlineData(7.233, 5.560, 2, 10, 1)]
        public void CalculateRho_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);
            // Act
            var actual = _mmckk.CalculateRho();
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(2, 3, 2, 8, 0.985)]    // Same inputs as original CalcRho, since the results should be the same.
        [InlineData(1.268, 2.555, 3, 6, 0.643)]
        [InlineData(7.233, 5.560, 2, 10, 1)]
        public void CalculateAlternateRho_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);
            // Act
            var actual = _mmckk.CalculateRho(_mmckk.CalculateL(), _mmckk.CalculateLq());
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(2, 3, 2, 8, 0.985)]    // Same inputs as original CalcRho, since the results should be the same.
        [InlineData(1.268, 2.555, 3, 6, 0.643)]
        [InlineData(7.233, 5.560, 2, 10, 1)]
        public void CalculateAlternate2Rho_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);
            // Act
            var actual = _mmckk.CalculateRho(_mmckk.CalculateLambdaE());
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }
    }
}
