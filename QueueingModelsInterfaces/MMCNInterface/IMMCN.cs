namespace QueueingModelsInterfaces.MMCNInterface
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
        public double CalculateServerUtilization(double lambda, double mu, int c, int N);

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
        /// <param name="rho">lambda/(number of servers * service rate) (Call IMMCN.CalculateServerUtilization)</param>
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
        /// <param name="rho">System utilization (Call IMMCN.CalculateServerUtilization)</param>
        /// <param name="pZero">Probability of an empty system (Call IMMCN.CalculatePZero)</param>
        /// <returns>Mean number of customers in queue</returns>
        public double CalculateLq(double a, int c, int N, double rho, double pZero);

        /// <summary>
        /// Calculates the effective arrival rate
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="N">System capacity</param>
        /// <returns>Effective arrival rate</returns>
        public double CalculateLambdaE(double lam, double mu, int c, int N);

        /// <summary>
        /// Alternate method to calculates the effective arrival rate
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="probSystemFull">Probability system is full (Call IMMCN.CalculatePn)</param>
        /// <returns>Effective arrival rate</returns>
        public double CalculateLambdaE(double lam, double probSystemFull);

        /// <summary>
        /// Calculates the effective arrival rate
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="N">System capacity</param>
        /// <returns>Mean time customers spends in queue</returns>
        public double CalculateWq(double lam, double mu, int c, int N);

        /// <summary>
        /// Alternate method to calculate the mean time customers spends in queue
        /// </summary>
        /// <param name="Lq">Mean number of customers in queue (Call IMMCN.CalculateLq)</param>
        /// <param name="lambdaE">Effective arrival rate (Call IMMCN.CalculateLambdaE)</param>
        /// <returns>Mean time customers spends in queue</returns>
        public double CalculateWq(double Lq, double lambdaE);

        /// <summary>
        /// Calculates the mean time customers spends in system
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="N">System capacity</param>
        /// <returns>Mean time customers spends in system</returns>
        public double CalculateW(double lam, double mu, int c, int N);

        /// <summary>
        /// Alternate method to calculate the mean time customers spends in system
        /// </summary>
        /// <param name="Wq">Mean time customers spends in queue (Call IMMCN.CalculateWq)</param>
        /// <param name="mu">Service rate</param>
        /// <returns></returns>
        public double CalculateW(double Wq, double mu);

        /// <summary>
        /// Calculates the mean number of customers in the system
        /// </summary>
        /// <param name="lam">Arrival rate</param>
        /// <param name="mu">Service rate</param>
        /// <param name="c">Number of servers</param>
        /// <param name="N">System capacity</param>
        /// <returns>The mean number of customers in system</returns>
        public double CalculateL(double lam, double mu, int c, int N);

        /// <summary>
        /// Alternate method to calculate the mean number of customers in the system
        /// </summary>
        /// <param name="lambdaE">Effective arrival rate (Call IMMCN.CalculateLambdaE)</param>
        /// <param name="w">Mean time customers spends in queue (Call IMMCN.CalculateW)</param>
        /// <returns>The mean number of customers in system</returns>
        public double CalculateL(double lambdaE, double w);
    }
}