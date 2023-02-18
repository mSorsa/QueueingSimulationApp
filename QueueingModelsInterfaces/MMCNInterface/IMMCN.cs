using System.Linq.Expressions;

namespace MMCNQueueParameters
{
    public interface IMMCN
    {
        /// <summary>
        /// Calculate server utilization
        /// </summary>
        /// <param name="lambda">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <returns></returns>
        public double CalculateRho(double lambda, double mu, int c);

        /// <summary>
        /// Calculates the probability of an empty system.
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="N">System capacity</param>
        /// <returns></returns>
        public double CalculatePZero(double lam, double mu, int c, int N);

        /// <summary>
        /// Alternate method to calculate the probability of an empty system.
        /// </summary>
        /// <param name="c">Number of Servers</param>
        /// <param name="N">System Capacity</param>
        /// <param name="a">Arrival rate / Service rate</param>
        /// <param name="rho">lambda/(number of servers * service rate) (Call IMMCN.CalculateRho)</param>
        /// <returns></returns>
        public double CalculatePZero(int c, int N, double a, double rho);

        /// <summary>
        /// Calculates the probability of a FULL system
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="N">System capacity</param>
        /// <returns>The probability the system is full</returns>
        public double CalculatePn(double lam, double mu, int c, int N);

        /// <summary>
        /// Alternate method to calculate the probability of a FULL system
        /// </summary>
        /// <param name="a">Arrival rate / Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="pZero">Probability of an empty system (Call IMMCN.CalculatePZero)</param>
        /// <returns>The probability the system is full</returns>
        public double CalculatePn(double a, int c, double pZero);

        /// <summary>
        /// Calculates the mean number in queue
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="N">System capacity</param>
        /// <returns>Mean number in queue</returns>
        public double CalculateLq(double lam, double mu, int c, int N);

        /// <summary>
        /// Alternate method to calculate the mean number in queue
        /// </summary>
        /// <param name="a">Arrival rate / Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="N">System capacity</param>
        /// <param name="rho">System utilization (Call IMMCN.CalculateRho)</param>
        /// <param name="pZero">Probability of an empty system (Call IMMCN.CalculatePZero)</param>
        /// <returns></returns>
        public double CalculateLq(double a, int c, int N, double rho, double pZero);

        public double CalculateLambdaE(double lam, double mu, int c, int N);

        public double CalculateLambdaE(double lam, double probSystemFull);
    }
}