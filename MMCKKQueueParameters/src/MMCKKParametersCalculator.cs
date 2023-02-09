namespace MMCKKQueueParameters.src
{
    public class MMCKKParametersCalculator : IMMCKK
    {
        public double CalculateL(double lambda, double mu, int c, int K)
            => lambda * (K + 1) / (c * mu - lambda);

        public double CalculateW(double lambda, double mu, int c, int K)
            => (K + 1) / (c * mu - lambda);

        public double CalculateWq(double lambda, double mu, int c, int K)
            => CalculateL(lambda, mu, c, K) / (c * mu);


        public double CalculateLq(double lambda, double mu, int c, int K)
            => CalculateL(lambda, mu, c, K) - lambda / mu;

        public double CalculatePn(double lambda, double mu, int c, int n, int K)
        {
            if (n >= K)
                return 0;

            return Math.Pow(lambda / (c * mu - lambda), n) * lambda / (c * mu);
        }
    }
}