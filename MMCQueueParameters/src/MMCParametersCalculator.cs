using MathematicalHelper;
using QueueingModelsInterfaces.MMCInterface;

namespace MMCQueueParameters.src
{
    public class MMCParametersCalculator : IMMC
    {
        private readonly FactorialCalculator _factorializer;

        public MMCParametersCalculator(FactorialCalculator? factorialCalculator)
            => this._factorializer = factorialCalculator ?? new(); 

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
            var firstHalf = 0.0;
            var rho = this.CalculateRho(lam, mu, c);

            for (var n = 0; n < c; n++)
            {
                firstHalf += Math.Pow(c * rho, n) / this._factorializer.Factorial(n);
            }

            var p1 = Math.Pow(c * rho, c);
            var p2 = 1.0 / this._factorializer.Factorial(c);
            var p3 = (1 / (1 - rho));

            var secondHalf = p1 * p2 * p3;

            var sum = firstHalf + secondHalf;
            return Math.Pow(sum, -1);
        }

        public double CalculateL(double lam, double mu, int c)
        {
            var rho = this.CalculateRho(lam, mu, c);
            var top = Math.Pow((rho * c), c + 1) * this.CalculatePZero(lam, mu, c);
            var bottom = c * this._factorializer.Factorial(c) * (Math.Pow(1 - rho, 2));

            return (top / bottom) + (c * rho);
        }

        public double CalculateWq(double lam, double mu, int c)
            => this.CalculateW(lam, this.CalculateL(lam, mu, c)) - (1 / mu);
    }
}