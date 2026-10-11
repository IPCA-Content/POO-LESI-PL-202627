namespace Lesson_1
{
    /// <summary>
    /// Provides checked integer arithmetic operations.
    /// </summary>
    public static class Operations
    {
        #region Methods

        /// <summary>
        /// Sums two integers and returns the result.
        /// </summary>
        /// <param name="a">The first addend.</param>
        /// <param name="b">The second addend.</param>
        /// <returns>The sum of <paramref name="a"/> and <paramref name="b"/>.</returns>
        public static int Sum(int a, int b)
        {
            return checked(a + b);
        }

        /// <summary>
        /// Subtracts two integers and returns the result.
        /// </summary>
        /// <param name="a">The value to subtract from.</param>
        /// <param name="b">The value to subtract.</param>
        /// <returns>The difference between <paramref name="a"/> and <paramref name="b"/>.</returns>
        public static int Sub(int a, int b)
        {
            return checked(a - b);
        }
        
        /// <summary>
        /// Multiplies two integers and returns the result.
        /// </summary>
        /// <param name="a">The first factor.</param>
        /// <param name="b">The second factor.</param>
        /// <returns>The product of <paramref name="a"/> and <paramref name="b"/>.</returns>
        public static int Mul(int a, int b)
        {
            return checked(a * b);
        }
        
        /// <summary>
        /// Divides two integers and returns the result.
        /// </summary>
        /// <param name="a">The dividend.</param>
        /// <param name="b">The divisor.</param>
        /// <returns>The integer quotient of <paramref name="a"/> divided by <paramref name="b"/>.</returns>
        /// <exception cref="DivideByZeroException"><paramref name="b"/> is zero.</exception>
        /// <exception cref="OverflowException">The quotient is outside the <see cref="int"/> range.</exception>
        public static int Div(int a, int b)
        {
            return checked(a / b);
        }

        #endregion
    }
}
