using MathematicalHelper;

namespace MMCQueueParameters.src
{
    public class MMCParametersCalculator : IMMC
    {
        private readonly FactorialCalculator _factorializer;

        public MMCParametersCalculator(FactorialCalculator factorialCalculator)
        { _factorializer = factorialCalculator; }


        public double CalculateL(double lambda, double mu, int c)
            => lambda / (mu - lambda / c);

        public double CalculateW(double lambda, double mu, int c)
            => 1 / (mu - lambda / c);

        public double CalculateWq(double lambda, double mu, int c)
            => lambda / (mu * (mu - lambda / c));

        public double CalculateLq(double lambda, double mu, int c)
            => lambda * lambda / (mu * (mu - lambda / c));

        public double CalculatePn(int n, double lambda, double mu, int c)
        {
            double rho = lambda / (mu * c);
            double result = 0;

            for (int k = 0; k <= n; k++)
                result += Math.Pow(rho, k) / _factorializer.Factorial(k) * Math.Pow(c, n - k) / _factorializer.Factorial(n - k);

            return Math.Pow(rho, n) * result;
        }
    }
}