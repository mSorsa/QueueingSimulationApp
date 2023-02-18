using MathematicalHelper;

namespace MMCKKQueueParameters.src
{
    public class MMCKKParametersCalculator : IMMCKK
    {
        private readonly FactorialCalculator _factorializer;
        private readonly BigParenCalculator _bigParenCalculator;

        public MMCKKParametersCalculator(FactorialCalculator factorializer,
            BigParenCalculator bigParenCalculator)
        {
            _factorializer = factorializer;
            _bigParenCalculator = bigParenCalculator;
        }
        
        public double CalculatePZero(double lam, double mu, int c, int K)
        {
            double sum = 0.0;

            for (int n = 0; n < c; n++)
                sum += _bigParenCalculator.CalculateBigParen(K, n)
                        * Math.Pow((lam / mu), n);

            for (int n = c; n <= K; n++)
                sum += (_factorializer.Factorial(K) / (_factorializer.Factorial(K - n)
                        * _factorializer.Factorial(c) * Math.Pow(c, n - c)))
                        * Math.Pow((lam / mu), n);

            return Math.Pow(sum, -1);
        }

        public double CalculateL(double lam, double mu, int c, int K)
        {
            double sum = 0.0;

            for (int n = 1; n <= K; n++)
                sum += n * CalculatePn(lam, mu, c, K, n);

            return sum;
        }

        private double CalculatePn(double lam, double mu, int c, int K, int n)
        {
            if (n >= 0 && n < c)
                return _bigParenCalculator.CalculateBigParen(K, n)
                        * Math.Pow((lam / mu), n)
                        * CalculatePZero(lam, mu, c, K);

            if (n >= c && n <= K)
                return _factorializer.Factorial(K)
                        / (_factorializer.Factorial(K - n) * _factorializer.Factorial(c) * Math.Pow(c, n - c))
                  * Math.Pow((lam / mu), n)
                  * CalculatePZero(lam, mu, c, K);

            throw new ArgumentException("n must be greater than 0 and less than K");
        }

        public double CalculateW(double lam, double mu, int c, int K)
            => CalculateL(lam, mu, c, K) / CalculateLambdaE(lam, mu, c, K);

        public double CalculateW(double L, double lambdaE)
            => L / lambdaE;

        public double CalculateLambdaE(double lam, double mu, int c, int K)
        {
            double sum = 0.0;

            for (int n = 0; n <= K; n++)
                sum += (K - n) * lam * CalculatePn(lam, mu, c, K, n);

            return sum;
        }

        public double CalculateWq(double lam, double mu, int c, int K)
            => CalculateLq(lam, mu, c, K) / CalculateLambdaE(lam, mu, c, K);

        public double CalculateWq(double lq, double lambdaE)
            => lq / lambdaE;

        public double CalculateLq(double lam, double mu, int c, int K)
        {
            double sum = 0.0;

            for (int n = c + 1; n <= K; n++)
                sum += (n - c) * CalculatePn(lam, mu, c, K, n);
            
            return sum;
        }

        public double CalculateRho(double lam, double mu, int c, int K)
            => (CalculateL(lam, mu, c, K) - CalculateLq(lam, mu, c, K)) / c;

        public double CalculateRho(double mu, int c, double lambdaE)
            => lambdaE / (c * mu);

        public double CalculateRho(double L, double Lq, int c)
            => (L - Lq) / c;
    }
}