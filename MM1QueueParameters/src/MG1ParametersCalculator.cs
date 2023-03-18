using QueueingModelsInterfaces.MG1Interface;

namespace MG1QueueParameters.src
{
    public class MG1ParametersCalculator : IMG1
    {
        private double _lambda;
        private double _mu;
        private double _sigma;

        public MG1ParametersCalculator(double lambda, double mu, double sigma = 0)
        {
            this.SetLambda(lambda);
            this.SetMu(mu);
            this.SetSigma(sigma);
        }

        public void SetLambda(double value)
            => this._lambda = value;

        public void SetMu(double value)
            => this._mu = value;

        public void SetSigma(double value)
            => this._sigma = value;

        public double CalculateRho()
            => this._mu is 0
                ? throw new DivideByZeroException("Service rate [mu] cannot be zero when calculating Rho.")
                : this._lambda / this._mu;

        public double CalculateL()
        {
            if (this._lambda >= this._mu)
                throw new ArgumentException("Arrival rate [lambda] must be less than Service rate [mu].");

            var rho = this.CalculateRho();

            var L = rho + (this._lambda * this._lambda
                * this.GetMG1StandardTop()
                / GetMG1StandardBottom(rho));

            return L;
        }

        private static double GetMG1StandardBottom(double rho)
            => rho is 1
            ? throw new ArgumentException("Rho cannot be 1. Division by zero when calculating MG1 parameter.")
            : 2 * (1 - rho);

        private double GetMG1StandardTop()
        {
            if (this._mu is 0)
                throw new DivideByZeroException("Mu cannot be 0. Division by zero when calculating MG1 parameter.");

            var musqrd = Math.Pow(this._mu, 2);

            return (1 / musqrd) + this._sigma;
        }

        public double CalculateW()
        {
            if (this._mu is 0)
                throw new DivideByZeroException("Service rate [mu] cannot be zero when calculating W.");
            if (this._lambda >= this._mu)
                throw new ArgumentException("Arrival rate [lambda] must be less than Service rate [mu].");

            var first = 1 / this._mu;

            var topparen = this.CalculateStandardTopParenthesis();
            var bottomparen = GetDivisionBottom(this.CalculateRho());

            var W = first + Math.Round(this._lambda * topparen / bottomparen, 3);

            return W;
        }

        private static double GetDivisionBottom(double rho)
            => rho is 1
                ? throw new ArgumentException("Rho cannot be 1. Division by zero when calculating MG1 parameter.")
                : 2 * (1 - rho);

        private double CalculateStandardTopParenthesis()
            => this._mu == 0
                ? throw new DivideByZeroException($"Calculating bottom part of parenthesis with values mu = {this._mu}, and sigma = {this._sigma} results in division by 0.")
                : (1 / (this._mu * this._mu)) + this._sigma;

        public double CalculateWq()
        {
            var topparen = this.CalculateStandardTopParenthesis();
            var bottomparen = GetDivisionBottom(this.CalculateRho());

            return Math.Round(this._lambda * topparen / bottomparen, 3);
        }

        private static double CalculateStandardTopParenthesis(double mu, double sigma)
            => mu == 0
                ? throw new DivideByZeroException($"Calculating bottom part of parenthesis with values mu = {mu}, and sigma = {sigma} results in division by 0.")
                : (1 / (mu * mu)) + sigma;

        public double CalculateLq()
        {
            var top = this._lambda * this._lambda * CalculateStandardTopParenthesis(this._mu, this._sigma);

            return top / GetDivisionBottom(this.CalculateRho());
        }

        public double CalculatePZero()
            => this._lambda <= 0
                ? throw new ArgumentException("Arrival rate [lambda] must be greater than 0.")
                : this._mu < 0
                    ? throw new ArgumentException("Service rate [mu] must be greater than 0.")
                    : this._mu is 0
                        ? throw new DivideByZeroException("Service rate [mu] cannot be 0.")
                        : 1 - this.CalculateRho();
    }
}