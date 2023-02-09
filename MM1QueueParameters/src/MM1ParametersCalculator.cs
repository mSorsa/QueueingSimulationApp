namespace MM1QueueParameters
{
    public class MM1ParametersCalculator : IMM1
    {

        public double CalculateL(double lambda, double mu)
        {
            if (lambda > mu)
                throw new ArgumentException("Lambda must be less than mu");
            
            return lambda / (mu - lambda);
        }


        public double CalculateW(double lambda, double mu)
            => 1 / (mu - lambda);


        public double CalculateWq(double lambda, double mu)
            => lambda / (mu * (mu - lambda));


        public double CalculateLq(double lambda, double mu)
            => lambda * lambda / (mu * (mu - lambda));


        public double CalculateRho(double lambda, double mu)
            => lambda / mu;

        public double CalculatePn(int n, double lambda, double mu)
        {
            double rho = CalculateRho(lambda, mu);
            return Math.Pow(rho, n) / (Math.Pow(1 - rho, n) + Math.Pow(rho, n) / (1 - rho));
        }

    }
}