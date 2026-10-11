//-----------------------------------------------------------------
//    <copyright file="BankAccount.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>08-10-2026</date>
//    <time>23:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_4.Models
{
    /// <summary>
    /// Base type for bank accounts with a configurable minimum balance.
    /// </summary>
    public abstract class BankAccount
    {
        #region Properties

        /// <summary>
        /// Gets the account number.
        /// </summary>
        public int AccountNumber { get; }

        /// <summary>
        /// Gets the account holder's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the current balance.
        /// </summary>
        public decimal Balance { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a bank account and validates its opening balance.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="name">The account holder's name.</param>
        /// <param name="balance">The opening balance.</param>
        /// <param name="minimumBalance">The lowest balance this account may hold.</param>
        /// <exception cref="ArgumentOutOfRangeException">An account number or balance is invalid.</exception>
        /// <exception cref="ArgumentException">The account holder's name is blank.</exception>
        protected BankAccount(int accountNumber, string name, decimal balance, decimal minimumBalance)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(accountNumber);
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            if (balance < minimumBalance)
            {
                throw new ArgumentOutOfRangeException(nameof(balance), "Opening balance is below the account minimum.");
            }

            AccountNumber = accountNumber;
            Name = name;
            Balance = balance;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Withdraws a specified amount from the account.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        /// <exception cref="ArgumentOutOfRangeException">The amount is not positive.</exception>
        /// <exception cref="InvalidOperationException">The withdrawal would breach the account minimum.</exception>
        public abstract void Withdraw(decimal amount);

        /// <summary>
        /// Deposits a positive amount into the account.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        /// <exception cref="ArgumentOutOfRangeException">The amount is not positive.</exception>
        public void Deposit(decimal amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
            Balance = checked(Balance + amount);
        }

        /// <summary>
        /// Applies a withdrawal after validating the amount and minimum balance.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        /// <param name="minimumBalance">The lowest balance allowed after the withdrawal.</param>
        /// <returns>The new balance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The amount is not positive.</exception>
        /// <exception cref="InvalidOperationException">The withdrawal would breach the account minimum.</exception>
        protected decimal ApplyWithdrawal(decimal amount, decimal minimumBalance)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
            decimal newBalance = Balance - amount;
            if (newBalance < minimumBalance)
            {
                throw new InvalidOperationException("The withdrawal would breach the account's minimum balance.");
            }

            Balance = newBalance;
            return Balance;
        }

        #endregion
    }
}