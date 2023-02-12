namespace MMCKKQueueParameters.src
{
    public interface IMMCKK
    {
        double CalculatePZero(double lam, double mu, int c, int K);

        // ?????? What is that formula after P0 ????????
        
        double CalculateL(double lam, double mu, int c, int K);
        double CalculatePn(double lam, double mu, int c, int K, int n);
        
    }
}