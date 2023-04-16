namespace QueueingModelsInterfaces.MGInfinityInterface
{
    public interface IMGInfinity
    {
        /// <summary>
        /// Probability of empty system
        /// </summary>
        /// <param name="lambda"></param>
        /// <param name="mu"></param>
        /// <returns></returns>
        double CalculatePZero(double lambda, double mu);

        /// <summary>
        /// Mean time in system
        /// </summary>
        /// <param name="mu"></param>
        /// <returns></returns>
        double CalculateW(double mu);

        /// <summary>
        /// Mean time in queue
        /// </summary>
        /// <returns></returns>
        double CalculateWq();

        /// <summary>
        /// Mean number in system
        /// </summary>
        /// <param name="lambda"></param>
        /// <param name="mu"></param>
        /// <returns></returns>
        double CalculateL(double lambda, double mu);

        /// <summary>
        /// Mean number in queue
        /// </summary>
        /// <returns></returns>
        double CalculateLq();

        /// <summary>
        /// Probability of n customers in system
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="n"></param>
        /// <returns></returns>
        double CalculatePn(double lambda, double mu, int n);
    }
}