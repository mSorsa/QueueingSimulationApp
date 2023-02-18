using MathematicalHelper;
using QueueingModelsInterfaces.MMCNInterface;

namespace MMCNQueueParameters.src
{
    public class MMCNParametersCalculator : IMMCN
    {
        private readonly FactorialCalculator _factorailizer;

        public MMCNParametersCalculator(FactorialCalculator factorializer)
            => this._factorailizer = factorializer;

        public double CalculateL(double lam, double mu, int c, int N)
            => this.CalculateLambdaE(lam, mu, c, N) * this.CalculateW(lam, mu, c, N);

        public double CalculateL(double lambdaE, double w)
            => lambdaE * w;

        public double CalculateLambdaE(double lam, double mu, int c, int N)
            => lam * (1 - this.CalculatePn(lam, mu, c, N));

        public double CalculateLambdaE(double lam, double probSystemFull)
            => lam * probSystemFull;

        public double CalculateLq(double lam, double mu, int c, int N)
        {
            var rho = CalculateRho(lam, mu, c);
            var sum = this.CalculatePZero(lam, mu, c, N) * CalculateA(lam, mu) * rho;

            sum /= this._factorailizer.Factorial(c) * Math.Pow(1 - rho, 2);

            var bracket = 1 - Math.Pow(rho, N - c) - ((N - c) * Math.Pow(rho, N - c) * (1 - rho));

            return sum * bracket;
        }

        private static double CalculateA(double lam, double mu)
            => Math.Round(lam / mu, 5);

        public double CalculateLq(double a, int c, int N, double rho, double pZero)
            => throw new NotImplementedException();

        public double CalculatePn(double lam, double mu, int c, int N)
        {
            var sum = Math.Pow(CalculateA(lam, mu), N);
            sum /= this._factorailizer.Factorial(c) * Math.Pow(c, N - c);
            sum *= this.CalculatePZero(lam, mu, c, N);

            return sum;
        }

        public double CalculatePn(double a, int c, double pZero)
            => throw new NotImplementedException();

        public double CalculatePZero(double lam, double mu, int c, int N)
        {
            var sum = 0.0;
            var a = CalculateA(lam, mu);

            for (var n = 1; n <= c; n++)
                sum += (Math.Pow(a, n) / this._factorailizer.Factorial(n)) + (Math.Pow(a, c) / this._factorailizer.Factorial(c));

            var rho = CalculateRho(lam, mu, c);

            var factor = 0.0;
            for (var n = c + 1; n <= N; n++)
                factor += Math.Pow(rho, n - c);

            sum = 1 + (sum * factor);

            return 1 / sum;
        }

        public double CalculatePZero(int c, int N, double a, double rho)
        {
            var sum = 0.0;

            for (var n = 0; n <= c; n++)
                sum += (Math.Pow(a, n) / this._factorailizer.Factorial(n)) + (Math.Pow(a, c) / this._factorailizer.Factorial(c));

            var factor = 0.0;
            for (var n = 0; n < N; n++)
                factor += Math.Pow(rho, n - c);

            sum = (sum * factor) + 1;
            return 1 / sum;
        }

        private static double CalculateRho(double lam, double mu, int c)
            => Math.Round(lam / (c * mu), 5);

        public double CalculateServerUtilization(double lam, double mu, int c, int N)
            => 1 - this.CalculatePZero(lam, mu, c, N);

        public double CalculateW(double lam, double mu, int c, int N)
            => this.CalculateWq(lam, mu, c, N) + (1 / mu);

        public double CalculateW(double Wq, double mu)
            => Wq + (1 / mu);

        public double CalculateWq(double lam, double mu, int c, int N)
            => this.CalculateLq(lam, mu, c, N) / this.CalculateLambdaE(lam, mu, c, N);

        public double CalculateWq(double Lq, double lambdaE)
            => Lq / lambdaE;
    }
}