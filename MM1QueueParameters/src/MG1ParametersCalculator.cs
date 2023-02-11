using System.Collections.Generic;

namespace MM1QueueParameters
{
    public class MG1ParametersCalculator : IMG1
    {
        // ρ
        public double CalculateRho(double lambda, double mu)
        {
            if (mu is 0)
                throw new DivideByZeroException("Service rate [mu] cannot be zero when calculating Rho.");
            if (mu < 0)
                throw new ArgumentException("Service rate [mu] must be greater than 0.");

            return lambda / mu;
        }

        // L
        public double CalculateL(double lambda, double mu, double sigma = 0)
        {
            if (lambda >= mu)
                throw new ArgumentException("Arrival rate [lambda] must be less than Service rate [mu].");

            double rho = CalculateRho(lambda, mu);

            double L = rho + (lambda * lambda) 
                * GetMG1StandardTop(mu, sigma) 
                / GetMG1StandardBottom(rho);

            return L;
        }

        private static double GetMG1StandardBottom(double rho)
        {
            if (rho is 1)
                throw new ArgumentException("Rho cannot be 1. Division by zero when calculating MG1 parameter.");
            
            return 2 * (1 - rho);
        }

        private static double GetMG1StandardTop(double mu, double sigma)
        {
            if (mu is 0)
                throw new DivideByZeroException("Mu cannot be 0. Division by zero when calculating MG1 parameter.");

            double musqrd = Math.Pow(mu, 2);

            return (1 / musqrd) + sigma;
        }

        // W
        public double CalculateW(double lambda, double mu, double sigma)
        {
            if (mu is 0)
                throw new DivideByZeroException("Service rate [mu] cannot be zero when calculating W.");
            if(lambda >= mu)
                throw new ArgumentException("Arrival rate [lambda] must be less than Service rate [mu].");
            
            double first = 1 / mu;

            double topparen = CalculateStandardTopParenthesis(mu, sigma);
            double bottomparen = GetDivisionBottom(CalculateRho(lambda, mu));

            double W = first + Math.Round((lambda * topparen / bottomparen), 3);

            return W;
        }

        private static double GetDivisionBottom(double rho)
        {
            if (rho is 1)
                throw new ArgumentException("Rho cannot be 1. Division by zero when calculating MG1 parameter.");
            
            return 2 * (1 - rho);
        }

        private static double CalculateStandardTopParenthesis(double mu, double sigma)
        {
            if (mu * mu + sigma == 0)
                throw new DivideByZeroException($"Calculating bottom part of parenthesis with values mu = {mu}, and sigma = {sigma} results in division by 0.");

            return (1 / (mu * mu) + (sigma));
        }



        public double CalculateWq(double lambda, double mu, double sigma)
        {
            double topparen = CalculateStandardTopParenthesis(mu, sigma);
            double bottomparen = GetDivisionBottom(CalculateRho(lambda, mu));

            double W = Math.Round((lambda * topparen / bottomparen), 3);

            return W;
        }


        public double CalculateLq(double lambda, double mu, double sigma = 0)
        {
            double top = (lambda * lambda) * CalculateStandardTopParenthesis(mu, sigma);

            return top / GetDivisionBottom(CalculateRho(lambda, mu));
        }



        public double CalculatePZero(double lambda, double mu)
        {
            if (lambda <= 0)
                throw new ArgumentException("Arrival rate [lambda] must be greater than 0.");
            if (mu < 0)
                throw new ArgumentException("Service rate [mu] must be greater than 0.");
            if (mu is 0)
                throw new DivideByZeroException("Service rate [mu] cannot be 0.");

            return 1 - CalculateRho(lambda, mu);
        }

    }
}