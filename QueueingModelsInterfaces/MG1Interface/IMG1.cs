namespace MM1QueueParameters
{
    /// <summary>
    /// Interface for MM1 queueing model
    /// </summary>
    public interface IMG1
    {
        /// <summary>
        /// Calculates the average number of customers in the system.
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="sigma">Variance of service time</param>
        /// <exception cref="ArgumentException">Thrown when lambda is greater than mu</exception>
        /// <returns></returns>
        double CalculateL(double lambda, double mu, double sigma = 0);
        
        /// <summary>
        /// Calculates the average time spent in the system.
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <returns></returns>
        double CalculateLq(double lambda, double mu);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <returns>The probability of n customers in system.</returns>
        /// <exception cref="ArgumentException">Mu must be greater than 0.</exception>
        /// <exception cref="ArgumentException">Lambda must be greater than 0.</exception>
        double CalculatePZero(double lambda, double mu);

        /// <summary>
        /// Calculates the mean time a customer is in the system.
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <returns>Mean customer time in system</returns>
        double CalculateW(double lambda, double mu, double sigma = 0);
        
        /// <summary>
        /// Calculates the mean time a customer is in the queue.
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">service rate</param>
        /// <returns>Mean customer time in queue</returns>
        double CalculateWq(double lambda, double mu);


        /// <summary>
        /// System utilization
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <returns>System Utilization</returns>
        /// <exception cref="DivideByZeroException">"Service rate [mu] cannot be zero when calculating Rho."</exception>
        /// <exception cref="ArgumentException">"Service rate [mu] must be greater than 0."</exception>
        double CalculateRho(double lambda, double mu);
    }
}