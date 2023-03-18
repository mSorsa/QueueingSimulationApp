using MathematicalHelper;

namespace TestMathHelper
{
    public class ExpectedValueTester
    {
        private static readonly ExpectedValueCalculator _calculator = new();

        [Theory]
        [InlineData(new double[] { 1, 2, 3, 4 }, 2.5)]
        [InlineData(new double[] { -2, -1, 0, 1, 2 }, 0.0)]
        [InlineData(new double[] { 10, 20, 30 }, 20.0)]
        public void TestCalculateExpectedValue_ValidInput_CorrectOut(double[] values, double expected)
        {
            var result = ExpectedValueCalculator.CalculateExpectedValue(values);
            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(new double[] { })]
        public void TestCalculateExpectedValue_InvalidInput_EmptyArray(double[] values)
            => Assert.Throws<DivideByZeroException>(() => ExpectedValueCalculator.CalculateExpectedValue(values));

        [Theory]
        [InlineData(null)]
        public void TestCalculateExpectedValue_InvalidInput_NullArray(double[] values)
            => Assert.Throws<ArgumentNullException>(() => ExpectedValueCalculator.CalculateExpectedValue(values));
    }
}
