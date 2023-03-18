using MathematicalHelper;
using QueueingModelsInterfaces.MGInfinityInterface;

namespace MGInfinityQueueParameters.src
{
    public class MGInfinityParametersCalculator : IMGInfinity
    {
        private readonly FactorialCalculator _calculator;

        public MGInfinityParametersCalculator(FactorialCalculator? factorialCalculator) 
            => this._calculator = factorialCalculator ?? new();

        public double CalculatePZero(double lambda, double mu)
        {
            muCheck(mu);
            return Math.Pow(Math.E, (-lambda / mu));
        }

        private static void muCheck(double mu)
        {
            if (mu == 0)
                throw new DivideByZeroException("When calculating, if mu is 0 it causes division by 0.");
        }

        public double CalculateW(double mu)
        {
            muCheck(mu);

            return 1 / mu;
        }

        public double CalculateWq()
            => 0;

        public double CalculateL(double lambda, double mu)
        {
            muCheck(mu);

            return lambda / mu;
        }

        public double CalculateLq()
            => 0;

        public double CalculatePn(double lambda, double mu, int n)
        {
            if (n < 0)
                throw new ArgumentException("n cannot be less than 0 as it causes in factorial of negative numbers.");

            muCheck(mu);

            var top = Math.Pow(Math.E, -lambda / mu) * Math.Pow(lambda / mu, n);
            double bottom = FactorialCalculator.Factorial(n);

            return top / bottom;
        }
    }
}