using MathematicalHelper;

namespace TestMathHelper
{
    public class FactorializerTester
    {
        private static readonly FactorialCalculator factorialize = new();

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(5, 120)]
        [InlineData(6, 720)]
        [InlineData(7, 5040)]
        [InlineData(8, 40320)]
        [InlineData(9, 362880)]
        [InlineData(10, 3628800)]
        [InlineData(11, 39916800)]
        [InlineData(12, 479001600)]
        public void FactorialTests_Correct(int num, int expected)
        {
            // Arrange, and Act
            var actual = factorialize.Factorial(num);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        [InlineData(-10)]
        [InlineData(-1000)]
        public void FactorialTests_Invalid(int num)
            => Assert.Throws<ArgumentException>(() => factorialize.Factorial(num));

        [Theory]
        [InlineData(13)]
        [InlineData(1000)]
        [InlineData(2365)]
        [InlineData(int.MaxValue)]
        public void FactorialTest_OutOfRange(int num)
            => Assert.Throws<OverflowException>(() => factorialize.Factorial(num));
    }
}
