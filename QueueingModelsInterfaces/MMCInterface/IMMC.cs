namespace MMCQueueParameters.src
{
    public interface IMMC
    {
        double CalculateRho(double lam, double mu, int c);
        double CalculatePZero(double lam, double mu, int c);
        double CalculateW(double lam, double L);
        double CalculateWq(double lam, double mu, int c);
        double CalculateL(double lam, double mu, int c);
        double CalculateLq(double lam, double Wq);
        double CalculateLminusLq(double c, double rho);
    }
}