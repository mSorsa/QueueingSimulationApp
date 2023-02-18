using MathematicalHelper;

namespace MMCNQueueParameters
{
    public class MMCNParametersCalculator : IMMCN
    {
        private readonly FactorialCalculator _factorailizer;

        public MMCNParametersCalculator(FactorialCalculator factorializer)
        {
            _factorailizer = factorializer;
        }

        public double CalculateL(double lam, double mu, int c, int N)
            => CalculateLambdaE(lam, mu, c, N) * CalculateW(lam, mu, c, N);

        public double CalculateL(double lambdaE, double w)
            => lambdaE * w;

        public double CalculateLambdaE(double lam, double mu, int c, int N)
            => lam * (1 - CalculatePn(lam, mu, c, N));

        public double CalculateLambdaE(double lam, double probSystemFull)
            => lam * probSystemFull;

        public double CalculateLq(double lam, double mu, int c, int N)
        {
            throw new NotImplementedException();
        }

        public double CalculateLq(double a, int c, int N, double rho, double pZero)
        {
            throw new NotImplementedException();
        }

        public double CalculatePn(double lam, double mu, int c, int N)
        {
            throw new NotImplementedException();
        }

        public double CalculatePn(double a, int c, double pZero)
        {
            throw new NotImplementedException();
        }

        public double CalculatePZero(double lam, double mu, int c, int N)
        {
            throw new NotImplementedException();
        }

        public double CalculatePZero(int c, int N, double a, double rho)
        {
            double sum = 0.0;

            for (int n = 0; n <= c; n++)
                sum += Math.Pow(a, n) / _factorailizer.Factorial(n) + Math.Pow(a, c) / _factorailizer.Factorial(c);

            for (int n = 0; n < N; n++)
                sum += Math.Pow(rho, n - c);

            return Math.Pow(sum + 1, -1);
        }

        public double CalculateRho(double lambda, double mu, int c)
            => lambda / (c * mu);

        public double CalculateW(double lam, double mu, int c, int N)
            => CalculateWq(lam, mu, c, N) + 1 / mu;

        public double CalculateW(double Wq, double mu)
            => Wq + 1 / mu;

        public double CalculateWq(double lam, double mu, int c, int N)
            => CalculateLq(lam, mu, c, N) / CalculateLambdaE(lam, mu, c, N);

        public double CalculateWq(double Lq, double lambdaE)
            => Lq / lambdaE;
    }
}