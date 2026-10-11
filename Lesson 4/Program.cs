//-----------------------------------------------------------------
//    <copyright file="Program.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>08-10-2026</date>
//    <time>23:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_4.Models;

namespace Lesson_4
{
    /// <summary>
    /// Demonstrates bank account inheritance and withdrawal rules.
    /// </summary>
    internal static class Program
    {
        #region Entry point

        /// <summary>
        /// Runs the account examples.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        private static void Main(string[] args)
        {
            NormalAccount normalAccount = new(1, "John Doe", 1_000);
            SavingAccount savingAccount = new(2, "Jane Doe", 500);
            TeenAccount teenAccount = new(3, "Jimmy Doe", 200);

            normalAccount.Withdraw(100);
            savingAccount.Deposit(50);
            teenAccount.Withdraw(75);

            Console.WriteLine($"{normalAccount.Name}: {normalAccount.Balance:C}");
            Console.WriteLine($"{savingAccount.Name}: {savingAccount.Balance:C}");
            Console.WriteLine($"{teenAccount.Name}: {teenAccount.Balance:C}");
        }

        #endregion
    }
}