using MathematicalHelper;

namespace MMCKKQueueParameters.src
{
    public class MMCKKParametersCalculator : IMMCKK
    {
        private readonly FactorialCalculator _factorializer;
        private readonly BigParenCalculator _bigParenCalculator;

        public MMCKKParametersCalculator(FactorialCalculator factorializer, 
            BigParenCalculator bigParenCalculator)
        { 
            _factorializer = factorializer;
            _bigParenCalculator = bigParenCalculator;
        }

        //public double CalculateWq(double lam, double mu, int c)
        //    => this.CalculateW(lam, CalculateL(lam, mu, c, K)) - (1 / mu);

        //public double CalculateW(double lam, double mu, int c)
        //    => CalculateL(lam, mu, c, K) / lam;

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
                sum += _bigParenCalculator.CalculateBigParen(K, n)
                        * Math.Pow((lam / mu), n);

            for (int n = c; n <= K; n++)
                sum += (_factorializer.Factorial(K) / (_factorializer.Factorial(K - n)
                        * _factorializer.Factorial(c) * Math.Pow(c, n - c)))
                        * Math.Pow((lam / mu), n);

            return Math.Pow(sum, -1);
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
        /// <exception cref="ArgumentException">Thrown when n is not within acceptable range [0, K].</exception>
        public double CalculatePn(double lam, double mu, int c, int K, int n)
        {
            if (n > 0 && n < c)
                return _bigParenCalculator.CalculateBigParen(K, n)
                        * Math.Pow((lam / mu), n)
                        * CalculatePZero(lam, mu, c, K);

            if (n >= c && n <= K)
                return  _factorializer.Factorial(K) 
                        / (_factorializer.Factorial(K - n) * _factorializer.Factorial(c) * Math.Pow(c, n - c))
                  * Math.Pow((lam / mu), n)
                  * CalculatePZero(lam, mu, c, K);

            throw new ArgumentException("n must be greater than 0 and less than K");
        }


    }
}