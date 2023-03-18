using MathematicalHelper;
using QueueingModelsInterfaces.MMCKKInterface;

namespace MMCKKQueueParameters.src
{
    public class MMCKKParametersCalculator : IMMCKK
    {
        private readonly FactorialCalculator _factorializer;
        private readonly BigParenCalculator _bigParenCalculator;

        private double _lam;
        private double _mu;
        private int _c;
        private int _K;

        public MMCKKParametersCalculator(FactorialCalculator factorializer,
            BigParenCalculator bigParenCalculator,
            double lam,
            double mu,
            int c,
            int K)
        {
            this._factorializer = factorializer;
            this._bigParenCalculator = bigParenCalculator;
            this.SetLambda(lam);
            this.SetMu(mu);
            this.SetC(c);
            this.SetK(K);
        }

        public void SetLambda(double value)
            => this._lam = value;
        public void SetMu(double value)
            => this._mu = value;
        public void SetC(int value)
            => this._c = value;
        public void SetK(int value)
            => this._K = value;

        public double CalculatePZero()
        {
            var sum = 0.0;

            for (var n = 0; n < this._c; n++)
                sum += this._bigParenCalculator.CalculateBigParen(this._K, n)
                        * Math.Pow(this._lam / this._mu, n);

            for (var n = this._c; n <= this._K; n++)
                sum += FactorialCalculator.Factorial(this._K) / (FactorialCalculator.Factorial(this._K - n)
                        * FactorialCalculator.Factorial(this._c) * Math.Pow(this._c, n - this._c))
                        * Math.Pow(this._lam / this._mu, n);

            return Math.Pow(sum, -1);
        }

        public double CalculateL()
        {
            var sum = 0.0;

            for (var n = 1; n <= this._K; n++)
                sum += n * this.CalculatePn(n);

            return sum;
        }

        private double CalculatePn(int n)
        {
            return n >= 0 && n < this._c
                ? this._bigParenCalculator.CalculateBigParen(this._K, n)
                        * Math.Pow(this._lam / this._mu, n)
                        * this.CalculatePZero()
                : n >= this._c && n <= this._K
                    ? FactorialCalculator.Factorial(this._K)
                        / (FactorialCalculator.Factorial(this._K - n) * FactorialCalculator.Factorial(this._c)
                            * Math.Pow(this._c, n - this._c))
                        * Math.Pow(this._lam / this._mu, n)
                        * this.CalculatePZero()
                    : throw new ArgumentException("n must be greater than 0 and less than K");
        }

        public double CalculateW()
            => this.CalculateL() / this.CalculateLambdaE();

        public double CalculateW(double L, double lambdaE)
            => L / lambdaE;

        public double CalculateLambdaE()
        {
            var sum = 0.0;

            for (var n = 0; n <= this._K; n++)
                sum += (this._K - n) * this._lam * this.CalculatePn(n);

            return sum;
        }

        public double CalculateWq()
            => this.CalculateLq() / this.CalculateLambdaE();

        public double CalculateWq(double lq, double lambdaE)
            => lq / lambdaE;

        public double CalculateLq()
        {
            var sum = 0.0;

            for (var n = this._c + 1; n <= this._K; n++)
                sum += (n - this._c) * this.CalculatePn(n);

            return sum;
        }

        public double CalculateRho()
            => (this.CalculateL() - this.CalculateLq()) / this._c;

        public double CalculateRho(double lambdaE)
            => lambdaE / (this._c * this._mu);

        public double CalculateRho(double L, double Lq)
            => (L - Lq) / this._c;
    }
}