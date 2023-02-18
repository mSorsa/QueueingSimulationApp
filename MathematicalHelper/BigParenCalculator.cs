namespace MathematicalHelper
{
    public class BigParenCalculator
    {
        private readonly FactorialCalculator _factorializer;

        public BigParenCalculator(FactorialCalculator? factorializer)
        { _factorializer = factorializer ?? new(); }

        /// <summary>
        /// Calculates the awkward "big parenthesis".
        /// Transforms the expression to: n! / (x! * (n-x)!
        /// </summary>
        /// <param name="n">Nominator in parenthesis</param>
        /// <param name="x">Denominator in parenthesis</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Is thrown when n or x less than 0.</exception>
        public double CalculateBigParen(int n, int x)
        {
            if (n < 0 || x < 0)
                throw new ArgumentException($"n and x must be positive integers. Inputted values were: x = {x}, and n = {n}.");

            return _factorializer.Factorial(n) 
                / (_factorializer.Factorial(x) * ( (double) _factorializer.Factorial(n - x)) );
            
        }
    }
}
