using MathematicalHelper;

namespace MGInfinityQueueParameters.src
{
    public class MGInfinityParametersCalculator
    {
        private readonly ExpectedValueCalculator _ev;
        public MGInfinityParametersCalculator(ExpectedValueCalculator? evc)
        { _ev = evc ?? new(); }


        public double CalculateL(double lambda, double[] mu)
            => lambda / (_ev.CalculateExpectedValue(mu) - lambda);

        public double CalculateW(double lambda, double[] mu)
            => 1 / (_ev.CalculateExpectedValue(mu) - lambda);

        public double CalculateWq(double lambda, double[] mu)
            => lambda / (_ev.CalculateExpectedValue(mu) * (_ev.CalculateExpectedValue(mu) - lambda));

        public double CalculateLq(double lambda, double[] mu)
            => lambda * lambda / (_ev.CalculateExpectedValue(mu) * (_ev.CalculateExpectedValue(mu) - lambda));
    }
}