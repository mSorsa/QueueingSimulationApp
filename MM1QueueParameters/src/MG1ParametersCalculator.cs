namespace MM1QueueParameters
{
    public class MG1ParametersCalculator : IMG1
    {

        public double CalculateL(double lambda, double mu, double sigma = 0)
        {
            if (lambda >= mu)
                throw new ArgumentException("Arrival rate [lambda] must be less than Service rate [mu].");

            double rho = CalculateRho(lambda, mu);

            double top = Math.Pow(lambda, 2) * GetMG1StandardTop(lambda, mu, sigma);
            double bottom = GetMG1StandardBottom(rho);

            double L = top / bottom;

            return L + rho;
        }

        private static double GetMG1StandardBottom(double rho)
            => 2 * (1 - rho);

        private static double GetMG1StandardTop(double lam, double mu, double sigma)
        {
            double musqrd = Math.Pow(mu, 2);
            double sigmasqrd = Math.Pow(sigma, 2);

            return ((1 / musqrd) + sigmasqrd);
        }


        public double CalculateW(double lambda, double mu, double sigma)
        {
            double first = 1 / mu;

            double topparen = CalculateStandardTopParenthesis(mu, sigma);
            double bottomparen = GetDivisionBottom(CalculateRho(lambda, mu));

            double W = first + Math.Round((lambda * topparen / bottomparen), 3);

            return W;
        }

        private static double GetDivisionBottom(double rho)
            => 2 * (1 - rho);

        private static double CalculateStandardTopParenthesis(double mu, double sigma)
        {
            if (mu * mu + sigma == 0)
                throw new DivideByZeroException($"Calculating bottom part of parenthesis with values mu = {mu}, and sigma = {sigma} results in division by 0.");

            return (1 / (mu * mu) + (sigma));
        }

        public double CalculateRho(double lambda, double mu)
        {
            if (mu is 0)
                throw new DivideByZeroException("Service rate [mu] cannot be zero when calculating Rho.");
            if (mu < 0)
                throw new ArgumentException("Service rate [mu] must be greater than 0.");

            return lambda / mu;
        }


        public double CalculateWq(double lambda, double mu)
            => lambda / (mu * (mu - lambda));


        public double CalculateLq(double lambda, double mu)
            => lambda * lambda / (mu * (mu - lambda));



        public double CalculatePZero(double lambda, double mu)
        {
            if (lambda <= 0)
                throw new ArgumentException("Arrival rate [lambda] must be greater than 0.");
            if (mu is 0)
                throw new DivideByZeroException("Service rate [mu] cannot be 0.");
            if (mu < 0)
                throw new ArgumentException("Service rate [mu] must be greater than 0.");

            return 1 - CalculateRho(lambda, mu);
        }

    }
}