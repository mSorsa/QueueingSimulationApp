using MathematicalHelper;

namespace MMCQueueParameters.src
{
    public class MMCParametersCalculator : IMMC
    {
        private readonly FactorialCalculator _factorializer;

        public MMCParametersCalculator(FactorialCalculator? factorialCalculator)
        { _factorializer = factorialCalculator ?? new(); }

        public double CalculateRho(double lam, double mu, int c)
            => lam / (c * mu);

        public double CalculateW(double lam, double L)
            => L / lam;

        public double CalculateLq(double lam, double Wq)
            => lam * Wq;

        public double CalculateLminusLq(double c, double rho)
            => c * rho;

        public double CalculatePZero(double lam, double mu, int c)
        {
            double firstHalf = 0.0;
            double rho = CalculateRho(lam, mu, c);

            for (int n = 0; n < c; n++)
            {
                firstHalf += Math.Pow(c * rho, n) / _factorializer.Factorial(n);
            }

            double p1 = Math.Pow(c * rho, c);
            double p2 = 1.0 / _factorializer.Factorial(c);
            double p3 = (1 / (1 - rho));
            
            double secondHalf = p1 * p2 * p3;
            
            double sum = firstHalf + secondHalf;
            return Math.Pow(sum, -1);
        }

        public double CalculateL(double lam, double mu, int c)
        {
            double rho = CalculateRho(lam, mu, c);
            double top = Math.Pow((rho * c), c + 1) * CalculatePZero(lam, mu, c);
            double bottom = c * _factorializer.Factorial(c) * (Math.Pow(1 - rho, 2));

            return (top / bottom) + (c * rho);
        }

        public double CalculateWq(double lam, double mu, int c)
            => CalculateW(lam, CalculateL(lam, mu, c)) - (1 / mu);
    }
}