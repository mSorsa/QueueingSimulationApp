namespace MathematicalHelper
{
    public class FactorialCalculator
    {
        private readonly factHelper helper;

        // ctor
        public FactorialCalculator() 
            => this.helper = new(); 

        /// <summary>
        /// Calculates the factorial of a number.
        /// Factorial (denoted with a number followed by '!'), 
        /// is the product of all positive (non-zero) integers less than or equal to number.
        /// </summary>
        /// <param name="number">Number to Factorialize.</param>
        /// <returns>Returns number factorial [number!]</returns>
        public int Factorial(int number)
        {
            // Verify number can be factorialized ( 0 <= number <= 12 )
            this.helper.validateNumber(number);

            // 0! = 1 by definition. Assume number is at least 0 since validateNumber().
            var fact = 1;

            // i.e.: 5! = 5 * 4 * 3 * 2 * 1 = 120.
            while (number > 0)
                fact *= number--;   // Count down after using number.

            return fact;
        }

        private class factHelper
        {
            /// <summary>
            /// Number validation.
            /// </summary>
            /// <param name="num">Number to validate.</param>
            /// <exception cref="InvalidDataException">num is negative.</exception>
            /// <exception cref="OverflowException">num cannot be held in datatype int.</exception>
            public void validateNumber(int num)
            {
                if (num < 0)
                    // Cannot factorialize negative numbers. 
                    throw new InvalidDataException("Cannot factorialize negative numbers!");

                if (num > 12)
                    // Number grows too big, int cannot hold.
                    throw new OverflowException("Number is too big to factorialize!");

                //return;
            }
        }
    }
}
