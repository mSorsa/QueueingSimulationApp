using MathematicalHelper;
using QueueingModelsInterfaces.MMCNInterface;

namespace MMCNQueueParameters.src
{
    public class MMCNParametersCalculator : IMMCN
    {
        private readonly FactorialCalculator _factorailizer;
        private readonly double _lam;
        private readonly double _mu;
        private readonly int _c;
        private readonly int _N;

        public MMCNParametersCalculator(FactorialCalculator factorializer, double lam, double mu, int c, int N)
        {
            this._factorailizer = factorializer;
            this._c = c;
            this._lam = lam;
            this._mu = mu;
            this._N = N;
        }

        public double CalculatePZero()
        {
            var rho = this._lam / this._mu / this._c;
            var offeredLoad = this._lam / this._mu;
            double factor = 1;
            double p0 = 1;
            for (var i = 1; i <= this._c; i++)
            {
                factor *= offeredLoad / i;
                p0 += factor;
            }
            if (this._c < this._N)
            {
                var rhosum = rho;
                if (this._c + 1 < this._N)
                {
                    for (var i = this._c + 2; i <= this._N; i++)
                    {
                        rhosum += Math.Pow(rho, i - this._c);
                    }
                }
                p0 += factor * rhosum;
            }
            return 1 / p0;
        }

        public double CalculatePN()
        {
            var offeredLoad = this._lam / this._mu;
            double cfactorial = 1;

            for (var i = 1; i <= this._c; i++)
                cfactorial *= i;

            return Math.Pow(offeredLoad, this._N) / cfactorial / Math.Pow(this._c, this._N - this._c) * this.CalculatePZero();
        }

        public double CalculateLambdaEffective()
            => this._lam * (1 - this.CalculatePN());

        public double CalculateL()
        {
            var LambdaEffective = this.CalculateLambdaEffective();
            var w = this.CalculateW();
            return LambdaEffective * w;
        }

        public double CalculateLQ()
        {
            var rho = this._lam / this._mu / this._c;
            var offeredLoad = this._lam / this._mu;
            var cfactorial = (double)this._factorailizer.Factorial(this._c);
            var p0 = this.CalculatePZero();

            var firstPart = (p0 * Math.Pow(offeredLoad, this._c) * rho) / (cfactorial * Math.Pow((1 - rho), 2));
            var secondPart = 1 - Math.Pow(rho, this._N - this._c) - (this._N - this._c) * Math.Pow(rho, this._N - this._c) * (1 - rho);

            var lq = firstPart * secondPart;

            return lq;
        }

        public double CalculateWQ()
        {
            var lambdaEffective = this.CalculateLambdaEffective();
            return this.CalculateLQ() / lambdaEffective;
        }


        public double CalculateW()
            => this.CalculateWQ() + (1 / this._mu);

        public double CalculateRho()
            => this._lam / this._mu / this._c;

        public double CalculateCapacityUtilization()
            => this.CalculateLambdaEffective() / this._c / this._mu;
    }
}