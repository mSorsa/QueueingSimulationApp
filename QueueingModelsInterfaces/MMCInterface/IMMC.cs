namespace QueueingModelsInterfaces.MMCInterface
{
    public interface IMMC
    {
        /// <summary>
        /// Calculates server utilization
        /// </summary>
        /// <returns>Utilization</returns>
        double CalculateRho();

        /// <summary>
        /// Calculates the mean number of customers in system
        /// </summary>
        /// <returns>Mean number of customers in system</returns>
        double CalculateL();

        /// <summary>
        /// Calculates the mean team a customer spends in the system
        /// </summary>
        /// <returns>Mean time customers spends in system</returns>
        double CalculateW();

        /// <summary>
        /// Calculates the mean time customers spends in queue
        /// </summary>
        /// <returns>Mean time customers spend in queue</returns>
        double CalculateWq();


        /// <summary>
        /// Calculates the mean number of customers in the system
        /// </summary>
        /// <returns>Mean number of customers in system</returns>
        double CalculateLq();

        /// <summary>
        /// Calculates the time-average number of customers being served
        /// </summary>
        /// <returns>Mean number of customers being served (alt. average number of busy servers)</returns>
        double CalculateLminusLq();

        /// <summary>
        /// Calculates the probability of an empty system
        /// </summary>
        /// <returns>Probability of an empty system</returns>
        double CalculatePZero();
    }
}