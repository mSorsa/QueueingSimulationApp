namespace QueueingModelsInterfaces.MG1Interface
{
    /// <summary>
    /// Interface for MM1 queueing model
    /// </summary>
    public interface IMG1
    {
        /// <summary>
        /// Server utilization.
        /// </summary>
        /// <returns>System Utilization</returns>
        /// <exception cref="DivideByZeroException">"Service rate [mu] cannot be zero when calculating Rho."</exception>
        /// <exception cref="ArgumentException">"Service rate [mu] must be greater than 0."</exception>
        double CalculateRho();

        /// <summary>
        /// Calculates the mean number of customers in the system.
        /// </summary>
        /// <param name="variance">Variance of service time. Notice! This should be sigmasquared.</param>
        /// <exception cref="ArgumentException">Thrown when lambda is greater than mu</exception>
        /// <returns></returns>
        double CalculateL();

        /// <summary>
        /// Calculates the average time spent in system per customer.
        /// </summary>
        /// <param name="variance">Variance of service time. Notice! This should be sigmasquared.</param>
        /// <returns>Mean customer time in system</returns>
        /// <exception cref="ArgumentException">Thrown when lambda is greater than mu</exception>
        /// <exception cref="DivideByZeroException">Thrown when mu is 0</exception>
        double CalculateW();

        /// <summary>
        /// Calculates the mean time a customer is in the queue.
        /// </summary>
        /// <returns>Mean customer time in queue</returns>
        double CalculateWq();

        /// <summary>
        /// Calculates the average time customers spend in system.
        /// </summary>
        /// <returns>Average time customers spend in system</returns>
        double CalculateLq();

        /// <summary>
        /// Calculates the probability of an empty system.
        /// </summary>
        /// <returns>The probability of an empty system.</returns>
        /// <exception cref="ArgumentException">Mu must be greater than 0.</exception>
        /// <exception cref="ArgumentException">Lambda must be greater than 0.</exception>
        /// <exception cref="DivideByZeroException">Thrown when mu is 0</exception>
        double CalculatePZero();
    }
}