namespace MMCNQueueParameters
{
    public class MMCNParametersCalculator : IMMCN
    {
        public double CalculateL(double lambda, double mu, int c, int N)
            => (Math.Pow(lambda / mu, N + 1) + c * lambda / mu * (1 - Math.Pow(lambda / (c * mu), N)) / (1 - lambda / (c * mu)))
                / (1 - Math.Pow(lambda / (c * mu), N + 1));

        public double CalculateW(double lambda, double mu, int c, int N)
            => 1 / (mu - lambda / c * (1 - Math.Pow(lambda / (c * mu), N + 1)) / (1 - Math.Pow(lambda / (c * mu), N)));

        public double CalculateWq(double lambda, double mu, int c, int N)
            => CalculateL(lambda, mu, c, N) / (c * mu);

        public double CalculateLq(double lambda, double mu, int c, int N)
            => CalculateL(lambda, mu, c, N) - lambda / mu;
    }
}