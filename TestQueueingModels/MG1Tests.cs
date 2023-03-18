using MG1QueueParameters.src;
using QueueingModelsInterfaces.MG1Interface;

namespace TestQueueingModels
{
    public class MG1Tests
    {
        // CalculateL
        [Theory]
        [InlineData(0.5, 0.6, 1.0, 3.667)]
        [InlineData(4.0, 7.0, 2.36, 45.006)]
        [InlineData(1.236, 2.587, 0.556, 1.510)]
        public void CalculateL_ValidInputs_ReturnsCorrectResult(double lambda, double mu, double variance, double expected)
        {
            IMG1 _mg1 = new MG1ParametersCalculator(lambda, mu, variance);
            var actual = _mg1.CalculateL();

            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        [Theory]
        [InlineData(2.0, 1.0)]
        [InlineData(3.0, 2.0)]
        public void CalculateL_InvalidInputs_ThrowsException(double lambda,
            double mu, double variance = 0)
        {
            IMG1 _mg1 = new MG1ParametersCalculator(lambda, mu, variance);
            _ = Assert.Throws<ArgumentException>(() => _mg1.CalculateL());
        }

        // W
        [Theory]
        [InlineData(2.0, 4.0, 1.0, 2.375)]
        [InlineData(6.0, 8.0, 1.0, 12.313)]
        [InlineData(1, 2, 0, 0.750)]
        [InlineData(5.2, 7.1, 2.8, 27.538)]
        public void CalculateW_ValidInputs_ReturnsCorrectResult(double lambda,
            double mu, double variance, double expected)
        {
            IMG1 _mg1 = new MG1ParametersCalculator(lambda, mu, variance);
            // Act
            var result = _mg1.CalculateW();

            // Assert
            Assert.Equal(expected: expected, actual: result, precision: 3);
        }

        [Theory]
        [InlineData(2.0, 1.0)]
        public void CalculateW_InvalidInputs_ThrowsArgException(double lambda,
            double mu, double variance = 0)
        {
            IMG1 _mg1 = new MG1ParametersCalculator(lambda, mu, variance);
            _ = Assert.Throws<ArgumentException>(() => _mg1.CalculateW());
        }

        // Wq
        [Theory]
        [InlineData(1.236, 2.587, 0.556, 0.835)]
        [InlineData(5.364, 7.551, 1.789, 16.729)]
        [InlineData(0.001, 0.002, 0.003, 250.000)]
        public void CalculateWq_ValidInputs_ReturnsCorrectResult(double lambda, double mu, double variance, double expected)
        {
            IMG1 _mg1 = new MG1ParametersCalculator(lambda, mu, variance);
            var actual = _mg1.CalculateWq();

            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        // Lq
        [Theory]
        [InlineData(0.001, 0.002, 0.003, 0.250)]
        [InlineData(2.5, 2.6, 3.0, 255.769)]
        [InlineData(0.26, 0.398, 0.556, 0.670)]
        public void CalculateLq_ValidInputs_ReturnsCorrectResult(double lambda, double mu, double variance, double expected)
        {
            IMG1 _mg1 = new MG1ParametersCalculator(lambda, mu, variance);
            var actual = _mg1.CalculateLq();

            Assert.Equal(expected: expected, actual: actual, precision: 3);
        }

        // P0
        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(3, 7, 0.571)]
        [InlineData(8, 12, 0.333)]
        [InlineData(2.0, 4.0, 0.5)]
        [InlineData(3.0, 4.0, 0.25)]
        public void CalculatePZero_ValidInput_ReturnsExpectedResult(double lambda,
            double mu, double expected)
        {
            // Act
            IMG1 _mg1 = new MG1ParametersCalculator(lambda, mu);
            var result = _mg1.CalculatePZero();

            //Assert
            Assert.Equal(expected: expected, actual: result, precision: 3);
        }

        [Theory]
        [InlineData(8, null)]
        [InlineData(1, 0)]
        public void CalculatePZero_InvalidInput_ThrowsDivByZeroException(double lambda, double mu)
        {
            IMG1 _mg1 = new MG1ParametersCalculator(lambda, mu);
            _ = Assert.Throws<DivideByZeroException>(() => _mg1.CalculatePZero());
        }

        [Theory]
        [InlineData(-1, 10)]
        [InlineData(5, -23)]
        public void CalculatePZero_InvalidInput_ThrowsArgumentException(double lambda, double mu)
        {
            IMG1 _mg1 = new MG1ParametersCalculator(lambda, mu);
            _ = Assert.Throws<ArgumentException>(() => _mg1.CalculatePZero());
        }
    }
}
