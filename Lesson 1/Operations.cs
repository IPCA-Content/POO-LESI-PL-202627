namespace Lesson_1
{
    /// <summary>
    /// Class Operations
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// Sums two integers and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Sum(int a, int b)
        {
            return checked(a + b);
        }

        /// <summary>
        /// Subtracts two integers and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Sub(int a, int b)
        {
            return checked(a - b);
        }
        
        /// <summary>
        /// Multiplies two integers and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Mul(int a, int b)
        {
            return checked(a * b);
        }
        
        /// <summary>
        /// Divides two integers and returns the result.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Div(int a, int b)
        {
            return checked(a / b);
        }
    }
}
