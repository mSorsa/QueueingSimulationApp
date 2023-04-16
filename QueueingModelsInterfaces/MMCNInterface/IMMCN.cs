namespace QueueingModelsInterfaces.MMCNInterface
{
    public interface IMMCN
    {
        /// <summary>
        /// Probability of empty system
        /// </summary>
        /// <returns></returns>
        double CalculatePZero();

        /// <summary>
        /// Probability of N customers
        /// </summary>
        /// <returns></returns>
        double CalculatePN();

        /// <summary>
        /// Effective arrival rate
        /// </summary>
        /// <returns>lambdaE</returns>
        double CalculateLambdaEffective();

        /// <summary>
        /// Mean number in system
        /// </summary>
        /// <returns></returns>
        double CalculateL();

        /// <summary>
        /// Mean number in queue
        /// </summary>
        /// <returns></returns>
        double CalculateLQ();

        /// <summary>
        /// Mean time in queue
        /// </summary>
        /// <returns></returns>
        double CalculateWQ();

        /// <summary>
        /// mean time in system
        /// </summary>
        /// <returns></returns>
        double CalculateW();

        /// <summary>
        /// Utilization
        /// </summary>
        /// <returns></returns>
        double CalculateRho();


        double CalculateCapacityUtilization();
    }
}