using MathematicalHelper;

namespace TestMathHelper
{
    public class BigParenTester
    {
        private static readonly BigParenCalculator _calculator = new(new FactorialCalculator());

        [Theory]
        [InlineData(8, 6, 28)]
        [InlineData(4, 0, 1)]
        [InlineData(4, 1, 4)]
        [InlineData(7, 3, 35)]
        [InlineData(12, 10, 66)]
        [InlineData(9, 2, 36)]
        public void CalculateBigParenExpression_ValidInputs_ReturnsExpectedValue(int n, int k, double expected)
        {
            // Act
            var actual = _calculator.CalculateBigParen(n, k);
            // Assert
            Assert.Equal(expected: expected, actual: actual);
        }
    }
}
