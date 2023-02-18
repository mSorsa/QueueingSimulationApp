namespace MathematicalHelper
{
    public class ExpectedValueCalculator
    {
        public double CalculateExpectedValue(double[] values)
        {
            if (values is null)
                throw new ArgumentNullException("Values is null.");
            if (!values.Any())
                throw new DivideByZeroException("No arguments to calculate expected value from!");

            double result = 0;

            for (var i = 0; i < values.Length; i++)
                result += values[i];

            return result / values.Length;
        }
    }
}
