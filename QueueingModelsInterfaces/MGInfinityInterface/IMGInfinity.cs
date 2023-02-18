namespace QueueingModelsInterfaces.MGInfinityInterface
{
    public interface IMGInfinity
    {
        double CalculatePZero(double lambda, double mu);
        double CalculateW(double mu);
        double CalculateWq();
        double CalculateL(double lambda, double mu);
        double CalculateLq();
        double CalculatePn(double lambda, double mu, int n);
    }
}