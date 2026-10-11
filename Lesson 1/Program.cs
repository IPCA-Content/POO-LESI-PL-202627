//-----------------------------------------------------------------
//    <copyright file="Program.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>21-09-2026</date>
//    <time>23:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_1
{
    /// <summary>
    /// Demonstrates the arithmetic operations in <see cref="Operations"/>.
    /// </summary>
    internal static class Program
    {
        #region Entry point

        /// <summary>
        /// Runs the arithmetic examples.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        private static void Main(string[] args)
        {
            Console.WriteLine($"The result of the sum is: {Operations.Sum(10, 20)}");
            Console.WriteLine($"The result of the subtraction is: {Operations.Sub(10, 20)}");
            Console.WriteLine($"The result of the multiplication is: {Operations.Mul(10, 20)}");
            Console.WriteLine($"The result of the division is: {Operations.Div(10, 20)}");
        }

        #endregion
    }
}