namespace QueueingModelsInterfaces.MMCKKInterface
{
    public interface IMMCKK
    {
        /// <summary>
        /// Calculates the probability of an empty system.
        /// </summary>
        /// <returns></returns>
        double CalculatePZero();

        /// <summary>
        /// Calculates the mean number of customers in the system.
        /// </summary>
        /// <returns>Mean number in system</returns>
        double CalculateL();

        /// <summary>
        /// Calculates the mean number of customers in queue
        /// </summary>
        /// <returns>Mean number in queue</returns>
        /// <exception cref="ArgumentException">Thrown when n is not within acceptable range [0, K].</exception>
        double CalculateLq();

        /// <summary>
        /// Calculates the mean time customers spend in the system
        /// </summary>
        /// <returns>Mean time customers spend in system</returns>
        double CalculateW();

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
        /// <returns>Mean time customers spend in queue</returns>
        double CalculateWq();

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
        /// <returns>Effective arrival rate</returns>
        /// <exception cref="ArgumentException">Thrown when n is not within acceptable range [0, K].</exception>
        double CalculateLambdaE();

        /// <summary>
        /// System utilization
        /// </summary>
        /// <returns>Utilization of system</returns>
        double CalculateRho();

        /// <summary>
        /// Alternate formula for calculating Rho
        /// </summary>
        /// <param name="lambdaE">Effective arrival rate (Call IMMCKK.CalculateLambdaE)</param>
        /// <returns>Utilization of system</returns>
        double CalculateRho(double lambdaE);

        /// <summary>
        /// Alternate formula for calculating Rho
        /// </summary>
        /// <param name="L">Mean number of customers in system (Call IMMCKK.CalculateL)</param>
        /// <param name="Lq">Mean number of customers in queue (Call IMMCKK.CalculateLq)</param>
        /// <returns>Utilization of system</returns>
        double CalculateRho(double L, double Lq);
    }
}