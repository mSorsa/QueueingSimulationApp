using MathematicalHelper;
using MMCKKQueueParameters.src;

namespace TestQueueingModels
{
    public class MMCKKTests
    {
        private static readonly FactorialCalculator _factorialCalculator = new();
        private static readonly BigParenCalculator _bigParenCalculator = new(_factorialCalculator);
        
        private static readonly IMMCKK _mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator);

        [Theory]
        [InlineData(1.0, 1.0, 2, 5, 0.019)]
        [InlineData(3.254, 2.284, 2, 2, 0.170)]
        [InlineData(0.225, 1.250, 3, 5, 0.437)]
        [InlineData(0.336, 5, 4, 10, 0.522)]
        [InlineData(6.396, 5, 2, 10, 0.000)]
        public void CalculatePZero_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            // Act
            var actual = _mmckk.CalculatePZero(lam, mu, c, K);
            // Assert
            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(6.396, 5.0, 2, 10, 8.437)]
        [InlineData(3, 2.0, 1, 7, 6.333)]
        [InlineData(0.673, 1.263, 2, 12, 8.250)]
        [InlineData(0.250, 0.335, 2, 8, 5.344)]
        [InlineData(0.015, 0.860, 3, 6, 0.103)]
        
        public void CalculateL_ValidInputs_ReturnsCorrectResult(double lam, double mu, int c, int K, double expected)
        {
            // Act
            var actual = _mmckk.CalculateL(lam, mu, c, K);
            // Assert
            Assert.Equal(expected: expected, actual: actual, tolerance: 0.001); // Tolerance because c# rounds 0.5 downwards.
        }
    }
}
