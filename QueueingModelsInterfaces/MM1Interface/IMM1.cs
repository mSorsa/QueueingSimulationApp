namespace MM1QueueParameters
{
    /// <summary>
    /// Interface for MM1 queueing model
    /// </summary>
    public interface IMM1
    {
        /// <summary>
        /// Calculates the average number of customers in the system.
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <returns></returns>
        double CalculateL(double lambda, double mu);
        
        /// <summary>
        /// Calculates the average time spent in the system.
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <returns></returns>
        double CalculateLq(double lambda, double mu);
        
        /// <summary>
        /// Calculates the average time spent in the queue.
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <returns></returns>
        double CalculatePn(int n, double lambda, double mu);
        
        /// <summary>
        /// Calculates the average number of customers in the queue.
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <returns></returns>
        double CalculateW(double lambda, double mu);
        
        /// <summary>
        /// Calculates the probability of n customers in the system.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">service rate</param>
        /// <returns></returns>
        double CalculateWq(double lambda, double mu);


        /// <summary>
        /// System utilization
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <returns></returns>
        double CalculateRho(double lambda, double mu);
    }
}