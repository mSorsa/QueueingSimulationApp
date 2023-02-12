using MathematicalHelper;

namespace MMCKKQueueParameters.src
{
    public class MMCKKParametersCalculator : IMMCKK
    {
        private readonly FactorialCalculator _factorializer;

        public MMCKKParametersCalculator(FactorialCalculator factorializer) 
            { _factorializer = factorializer; }

        //public double CalculateWq(double lam, double mu, int c)
        //    => CalculateW(lam, CalculateL(lam, mu, c, K)) - (1 / mu);

        /// <summary>
        /// P0. Probability System is empty.
        /// </summary>
        /// <param name="lam"> Arrival Rate </param>
        /// <param name="mu"> Service Rate </param>
        /// <param name="c"> Number of Servers </param>
        /// <param name="K"> Calling Population </param>
        /// <returns>P0 ( probability of empty system. )</returns>
        public double CalculatePZero(double lam, double mu, int c, int K)
        {
            double sum = 0.0;

            for (int n = 0; n < c; n++)
                sum += _factorializer.Factorial(K) / (_factorializer.Factorial(n)
                        * _factorializer.Factorial(K - n))
                        * Math.Pow((lam / mu), n);

            for (int n = c; n <= K; n++)
                sum += (_factorializer.Factorial(K) / (_factorializer.Factorial(K - n)
                        * _factorializer.Factorial(c) * Math.Pow(c, n - c)))
                        * Math.Pow((lam / mu), n);

            return Math.Round(Math.Pow(sum, -1), 3);
        }

        /// <summary>
        /// CalculateL is the mean number in the system.
        /// </summary>
        /// <param name="lam"> Arrival Rate </param>
        /// <param name="mu"> Service Rate </param>
        /// <param name="c"> Number of Servers </param>
        /// <param name="K"> Calling Population </param>
        /// <returns>CalculateL ( mean number in system. )</returns>
        public double CalculateL(double lam, double mu, int c, int K)
        {
            double sum = 0.0;

            for (int n = 1; n <= K; n++)
                sum += Math.Round(n * CalculatePn(lam, mu, c, K, n), 4);

            return sum;
        }

        /// <summary>
        /// CalculatePn, where n is the number in system.
        /// </summary>
        /// <param name="lam"> Arrival Rate </param>
        /// <param name="mu"> Service Rate </param>
        /// <param name="c"> Number of Servers </param>
        /// <param name="K"> Calling Population </param>
        /// <param name="n"> Given number in system </param>
        /// <returns>The probability of n number in system</returns>
        public double CalculatePn(double lam, double mu, int c, int K, int n)
        {
            int kFact = _factorializer.Factorial(K);
            int knFact = _factorializer.Factorial(K - n);
            int cFact = _factorializer.Factorial(c);
            int nFact = _factorializer.Factorial(n);
            double cPownc = Math.Pow(c, n - c);
            double lamDivMuPown = Math.Pow((lam / mu), n);
            double p0 = CalculatePZero(lam, mu, c, K);


            if (n < c)
                return (kFact / (nFact * knFact))
                        * lamDivMuPown
                        * p0;


            return kFact / (knFact * cFact * cPownc)
                    * lamDivMuPown
                    * p0;
        }


    }
}