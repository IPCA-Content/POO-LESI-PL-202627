//-----------------------------------------------------------------
//    <copyright file="SavingAccount.cs"    company="IPCA">
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
    /// Represents a savings account that cannot be overdrawn.
    /// </summary>
    public class SavingAccount : BankAccount
    {
        #region Constructors

        /// <summary>
        /// Initializes a savings account.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="name">The account holder's name.</param>
        /// <param name="balance">The opening balance.</param>
        public SavingAccount(int accountNumber, string name, decimal balance)
            : base(accountNumber, name, balance, (decimal)AccountLimits.SavingAccountMinimumBalance)
        {
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public override void Withdraw(decimal amount)
        {
            ApplyWithdrawal(amount, AccountLimits.SavingAccountMinimumBalance);
        }

        #endregion
    }
}