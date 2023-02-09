namespace MGInfinityQueueParameters.src
{
    public interface IMGInfinity
    {
        double CalculateL(double lambda, double[] mu);
        double CalculateLq(double lambda, double[] mu);
        double CalculateW(double lambda, double[] mu);
        double CalculateWq(double lambda, double[] mu);
    }
}