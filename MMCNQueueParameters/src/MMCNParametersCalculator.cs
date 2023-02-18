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
            double rho = CalculateServerUtilization(lam, mu, c, N);
            double sum = CalculatePZero(lam, mu, c, N) * CalculateA(lam, mu) * rho;
            
            sum /= (_factorailizer.Factorial(c) * Math.Pow(1 - rho, 2));

            double bracket = 1 - Math.Pow(rho, N - c) - (N - c) * Math.Pow(rho, N - c) * (1 - rho);

            return sum * bracket;
        }

        private double CalculateA(double lam, double mu)
            => Math.Round(lam / mu, 5);

        public double CalculateLq(double a, int c, int N, double rho, double pZero)
        {
            throw new NotImplementedException();
        }

        public double CalculatePn(double lam, double mu, int c, int N)
        {
            double sum = Math.Pow(CalculateA(lam, mu), N);
            sum /= (_factorailizer.Factorial(c) * Math.Pow(c, N - c));
            sum *= CalculatePZero(lam, mu, c, N);

            return sum;
        }

        public double CalculatePn(double a, int c, double pZero)
        {
            throw new NotImplementedException();
        }

        public double CalculatePZero(double lam, double mu, int c, int N)
        {
            double sum = 0.0;
            double a = CalculateA(lam, mu);

            for (int n = 1; n <= c; n++)
                sum += (Math.Pow(a, n) / _factorailizer.Factorial(n)) + (Math.Pow(a, c) / _factorailizer.Factorial(c));

            double rho = CalculateRho(lam, mu, c);

            double factor = 0.0;
            for (int n = c + 1; n <= N; n++)
                factor += Math.Pow(rho, n - c);

            sum = 1 + sum * factor;

            return 1/sum;
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

        private double CalculateRho(double lam, double mu, int c)
            => Math.Round(lam / (c * mu), 5);


        public double CalculateServerUtilization(double lam, double mu, int c, int N)
            => 1 - CalculatePZero(lam, mu, c, N);

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