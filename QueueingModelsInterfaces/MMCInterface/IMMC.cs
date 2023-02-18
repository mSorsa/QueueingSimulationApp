namespace MMCQueueParameters.src
{
    public interface IMMC
    {
        /// <summary>
        /// Calculates server utilization
        /// </summary>
        /// <param name="lam">Arrival Rate</param>
        /// <param name="mu">Service Rate</param>
        /// <param name="c">Number of Servers</param>
        /// <returns>Utilization</returns>
        double CalculateRho(double lam, double mu, int c);

        /// <summary>
        /// Calculates the mean number of customers in system
        /// </summary>
        /// <param name="lam">Arrival Rate</param>
        /// <param name="mu">Service Rate</param>
        /// <param name="c">Number of Servers</param>
        /// <returns>Mean number of customers in system</returns>
        double CalculateL(double lam, double mu, int c);

        /// <summary>
        /// Calculates the mean team a customer spends in the system
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="L">Mean number in system. (Call IMMC.CalculateL)</param>
        /// <returns>Mean time customers spends in system</returns>
        double CalculateW(double lam, double L);

        /// <summary>
        /// Calculates the mean time customers spends in queue
        /// </summary>
        /// <param name="lam">Arrival Rate</param>
        /// <param name="mu">Service Rate</param>
        /// <param name="c">Number of Servers</param>
        /// <returns>Mean time customers spend in queue</returns>
        double CalculateWq(double lam, double mu, int c);


        /// <summary>
        /// Calculates the mean number of customers in the system
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="Wq">Mean time in queue. (Call IMMC.CalculateWq)</param>
        /// <returns>Mean number of customers in system</returns>
        double CalculateLq(double lam, double Wq);

        /// <summary>
        /// Calculates the time-average number of customers being served
        /// </summary>
        /// <param name="c">Number of Servers</param>
        /// <param name="rho">Server Utilization. (Call IMMC.CalculateRho)</param>
        /// <returns>Mean number of customers being served (alt. average number of busy servers)</returns>
        double CalculateLminusLq(double c, double rho);

        /// <summary>
        /// Calculates the probability of an empty system
        /// </summary>
        /// <param name="lam">Arrival Rate</param>
        /// <param name="mu">Service Rate</param>
        /// <param name="c">Number of Servers</param>
        /// <returns>Probability of an empty system</returns>
        double CalculatePZero(double lam, double mu, int c);
    }
}