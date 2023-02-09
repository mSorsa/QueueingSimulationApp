namespace MMCNQueueParameters
{
    public interface IMMCN
    {
        double CalculateL(double lambda, double mu, int c, int N);
        double CalculateLq(double lambda, double mu, int c, int N);
        double CalculateW(double lambda, double mu, int c, int N);
        double CalculateWq(double lambda, double mu, int c, int N);
    }
}