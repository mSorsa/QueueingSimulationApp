using MM1QueueParameters;

namespace TestQueueingModels
{
    public class MM1Tests
    {
        private readonly IMM1 _mm1 = new MM1ParametersCalculator();

        [Theory]
        [InlineData(2.0, 3.0, 2.0)]
        [InlineData(3.0, 4.0, 3.0)]
        [InlineData(1.0, 2.0, 1.0)]
        public void CalculateL_ValidInputs_ReturnsCorrectResult(double lambda, double mu, double expectedResult)
        {
            // Arrange
            var calculator = new MM1ParametersCalculator();

            // Act
            var result = calculator.CalculateL(lambda, mu);

            // Assert
            Assert.Equal(expectedResult, result, 2);
        }

        [Theory]
        [InlineData(2.0, 1.0)]
        [InlineData(3.0, 2.0)]
        public void CalculateL_InvalidInputs_ThrowsException(double lambda, double mu)
        {
            // Arrange
            var calculator = new MM1ParametersCalculator();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => calculator.CalculateL(lambda, mu));
        }

        [Theory]
        [InlineData(2.0, 3.0, 1.0)]
        [InlineData(3.0, 4.0, 1.0)]
        [InlineData(5.0, 8.0, 0.333)]
        public void CalculateW_ValidInputs_ReturnsCorrectResult(double lambda, double mu, double expectedResult)
        {
            // Arrange
            var calculator = new MM1ParametersCalculator();

            // Act
            var result = calculator.CalculateW(lambda, mu);

            // Assert
            Assert.Equal(expectedResult, result, 2);
        }
    }
}
