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
    /// Class program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int result = Operations.Sum(10, 20);
            Console.WriteLine($"The result of the sum is: {result}");
            
            result = Operations.Sub(10, 20);
            Console.WriteLine($"The result of the subtraction is: {result}");
            
            result = Operations.Mul(10, 20);
            Console.WriteLine($"The result of the multiplication is: {result}");
            
            result = Operations.Div(10, 20);
            Console.WriteLine($"The result of the division is: {result}");
        }
    }
}