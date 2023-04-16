using MathematicalHelper;
using QueueingModelsInterfaces.MMCInterface;

namespace MMCQueueParameters.src
{
    public class MMCParametersCalculator : IMMC
    {
        private readonly FactorialCalculator _factorializer;
        private double _lam;
        private double _mu;
        private int _c;

        public MMCParametersCalculator(FactorialCalculator? factorialCalculator, double lam, double mu, int c)
        {
            this._factorializer = factorialCalculator ?? new();
            this.SetLambda(lam);
            this.SetMu(mu);
            this.SetC(c);
        }

        private void SetLambda(double value)
            => this._lam = value;
        private void SetMu(double value)
            => this._mu = value;
        private void SetC(int value)
            => this._c = value;

        public double CalculateRho()
            => this._lam / (this._c * this._mu);

        public double CalculateW()
            => this.CalculateL() / this._lam;

        public double CalculateLq()
            => this._lam * this.CalculateWq();

        public double CalculateLminusLq()
            => this._c * this.CalculateRho();

        public double CalculatePZero()
        {
            var firstHalf = 0.0;
            var rho = this.CalculateRho();

            for (var n = 0; n < this._c; n++)
            {
                firstHalf += Math.Pow(this._c * rho, n) / _factorializer.Factorial(n);
            }

            var p1 = Math.Pow(this._c * rho, this._c);
            var p2 = 1.0 / _factorializer.Factorial(this._c);
            var p3 = 1 / (1 - rho);

            var secondHalf = p1 * p2 * p3;

            var sum = firstHalf + secondHalf;
            return Math.Pow(sum, -1);
        }

        public double CalculateL()
        {
            var rho = this.CalculateRho();
            var top = Math.Pow(rho * this._c, this._c + 1) * this.CalculatePZero();
            var bottom = this._c * _factorializer.Factorial(this._c) * Math.Pow(1 - rho, 2);

            return (top / bottom) + (this._c * rho);
        }

        public double CalculateWq()
            => this.CalculateW() - (1 / this._mu);
    }
}