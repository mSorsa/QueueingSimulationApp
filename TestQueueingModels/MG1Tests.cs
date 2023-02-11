using MM1QueueParameters;

namespace TestQueueingModels
{
    public class MG1Tests
    {
        private readonly IMG1 _mg1 = new MG1ParametersCalculator();


        [Theory]
        [InlineData(2.0, 1.0)]
        [InlineData(3.0, 2.0)]
        public void CalculateL_InvalidInputs_ThrowsException(double lambda,
            double mu, double variance = 0)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _mg1.CalculateL(lambda, mu, variance));
        }



        // W
        [Theory]
        [InlineData(2.0, 4.0, 1.0, 2.375)]
        [InlineData(6.0, 8.0, 1.0, 12.313)]
        [InlineData(1, 2, 0, 0.750)]
        [InlineData(5.2, 7.1, 2.8, 27.538)]
        public void CalculateW_ValidInputs_ReturnsCorrectResult(double lambda,
            double mu, double variance, double expectedResult)
        {
            // Act
            var result = _mg1.CalculateW(lambda, mu, variance);

            // Assert
            Assert.Equal(expected: expectedResult, actual: result, precision: 3);
        }

        // P0
        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(3, 7, 0.571)]
        [InlineData(8, 12, 0.333)]
        public void CalculatePZero_ValidInput_ReturnsExpectedResult(double lam,
            double mu, double expected)
        {
            // Act
            var result = _mg1.CalculatePZero(lam, mu);

            //Assert
            Assert.Equal(expected: expected, actual: result, precision: 2);
        }

        [Theory]
        [InlineData(8, null)]
        [InlineData(1, 0)]
        public void CalculatePZero_InvalidInput_ThrowsDivByZeroException(double lam, double mu)
            => Assert.Throws<DivideByZeroException>(() => _mg1.CalculatePZero(lam, mu));

        [Theory]
        [InlineData(-1, 10)]
        [InlineData(5, -23)]
        public void CalculatePZero_InvalidInput_ThrowsArgumentException(double lam, double mu)
            => Assert.Throws<ArgumentException>(() => _mg1.CalculatePZero(lam, mu));

    }
}
