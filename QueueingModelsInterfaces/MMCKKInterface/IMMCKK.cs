namespace MMCKKQueueParameters.src
{
    public interface IMMCKK
    {
        /// <summary>
        /// Calculates the probability of an empty system.
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="K">Size of calling population</param>
        /// <returns></returns>
        double CalculatePZero(double lam, double mu, int c, int K);

        /// <summary>
        /// Calculates the mean number of customers in the system.
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="K">Size of calling population</param>
        /// <returns>Mean number in system</returns>
        double CalculateL(double lam, double mu, int c, int K);

        /// <summary>
        /// Calculates the mean number of customers in queue
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="K">Size of calling population</param>
        /// <returns>Mean number in queue</returns>
        /// <exception cref="ArgumentException">Thrown when n is not within acceptable range [0, K].</exception>
        double CalculateLq(double lam, double mu, int c, int K);

        /// <summary>
        /// Calculates the mean time customers spend in the system
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="K">Size of calling population</param>
        /// <returns>Mean time customers spend in system</returns>
        double CalculateW(double lam, double mu, int c, int K);

        /// <summary>
        /// Alternate formula for calculating W.
        /// </summary>
        /// <param name="L">Mean number in system (Call IMMCKK.CalculateL)</param>
        /// <param name="lambdaE">Effective arrival rate (Call IMMCKK.CalculateLambdaE)</param>
        /// <returns>Mean time customers spend in system</returns>
        double CalculateW(double L, double lambdaE);

        /// <summary>
        /// Calculates the mean time customers spends in queue
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="K">Size of calling population</param>
        /// <returns>Mean time customers spend in queue</returns>
        double CalculateWq(double lam, double mu, int c, int K);

        /// <summary>
        /// Alternate formula for calculating Wq.
        /// </summary>
        /// <param name="lq">Mean number of customers in queue (Call IMMCKK.CalculateLq)</param>
        /// <param name="lambdaE">Effective arrivalrate (Call IMMCKK.CalculateLambdaE)</param>
        /// <returns>Mean time customers spend in queue</returns>
        double CalculateWq(double lq, double lambdaE);

        /// <summary>
        /// Calculates the effective arrival rate
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="K">Size of calling population</param>
        /// <returns>Effective arrival rate</returns>
        /// <exception cref="ArgumentException">Thrown when n is not within acceptable range [0, K].</exception>
        double CalculateLambdaE(double lam, double mu, int c, int K);

        /// <summary>
        /// System utilization
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="K">Size of calling population</param>
        /// <returns>Utilization of system</returns>
        double CalculateRho(double lam, double mu, int c, int K);

        /// <summary>
        /// Alternate formula for calculating Rho
        /// </summary>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="lambdaE">Effective arrival rate (Call IMMCKK.CalculateLambdaE)</param>
        /// <returns>Utilization of system</returns>
        double CalculateRho(double mu, int c, double lambdaE);

        /// <summary>
        /// Alternate formula for calculating Rho
        /// </summary>
        /// <param name="L">Mean number of customers in system (Call IMMCKK.CalculateL)</param>
        /// <param name="Lq">Mean number of customers in queue (Call IMMCKK.CalculateLq)</param>
        /// <param name="c">Number of servers</param>
        /// <returns>Utilization of system</returns>
        double CalculateRho(double L, double Lq, int c);
    }
}