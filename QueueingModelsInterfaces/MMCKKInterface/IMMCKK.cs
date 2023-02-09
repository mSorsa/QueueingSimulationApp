namespace MMCKKQueueParameters.src
{
    public interface IMMCKK
    {
        double CalculateL(double lambda, double mu, int c, int K);
        double CalculateLq(double lambda, double mu, int c, int K);
        double CalculatePn(double lambda, double mu, int c, int n, int K);
        double CalculateW(double lambda, double mu, int c, int K);
        double CalculateWq(double lambda, double mu, int c, int K);
    }
}