namespace MMCQueueParameters.src
{
    public interface IMMC
    {
        double CalculateL(double lambda, double mu, int c);
        double CalculateLq(double lambda, double mu, int c);
        double CalculatePn(int n, double lambda, double mu, int c);
        double CalculateW(double lambda, double mu, int c);
        double CalculateWq(double lambda, double mu, int c);
    }
}