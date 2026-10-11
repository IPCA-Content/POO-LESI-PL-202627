//-----------------------------------------------------------------
//    <copyright file="NormalAccount.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>08-10-2026</date>
//    <time>23:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_4.Constants;

namespace Lesson_4.Models
{
    /// <summary>
    /// Represents an account that may use an overdraft up to its configured minimum balance.
    /// </summary>
    public class NormalAccount : BankAccount
    {
        #region Constructors

        /// <summary>
        /// Initializes a normal account.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="name">The account holder's name.</param>
        /// <param name="balance">The opening balance.</param>
        public NormalAccount(int accountNumber, string name, decimal balance)
            : base(accountNumber, name, balance, (decimal)AccountLimits.NormalAccountMinimumBalance)
        {
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public override void Withdraw(decimal amount)
        {
            ApplyWithdrawal(amount, AccountLimits.NormalAccountMinimumBalance);
        }

        #endregion
    }
}
