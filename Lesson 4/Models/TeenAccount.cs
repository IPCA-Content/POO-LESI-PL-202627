//-----------------------------------------------------------------
//    <copyright file="TeenAccount.cs"    company="IPCA">
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
    /// Represents an account with a per-day withdrawal limit.
    /// </summary>
    public class TeenAccount : BankAccount
    {
        #region Fields

        /// <summary>
        /// The date of the last withdrawal. This field is used to reset the daily withdrawal limit when a new day starts.
        /// </summary>
        private DateOnly withdrawalDate = DateOnly.FromDateTime(DateTime.Today);
        
        /// <summary>
        /// The total amount withdrawn today. This field is used to enforce the daily withdrawal limit for teen accounts.
        /// </summary>
        private decimal withdrawnToday;
        
        /// <summary>
        /// The minimum value for the account balance, which is zero for a teen account.
        /// Defined as a readonly field to ensure it cannot be modified after initialization.
        /// Defined with suffix m to indicate that it is a decimal literal,
        ///     which is important for financial calculations to avoid precision issues.
        /// </summary>
        private readonly decimal minValue = 0m;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a teen account.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="name">The account holder's name.</param>
        /// <param name="balance">The opening balance.</param>
        public TeenAccount(int accountNumber, string name, decimal balance)
            : base(accountNumber, name, balance, (decimal)AccountLimits.SavingAccountMinimumBalance)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Withdraws an amount without exceeding the daily limit or available balance.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        /// <exception cref="ArgumentOutOfRangeException">The amount is not positive.</exception>
        /// <exception cref="InvalidOperationException">The balance is insufficient or the daily limit would be exceeded.</exception>
        public override void Withdraw(decimal amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            if (withdrawalDate != today)
            {
                withdrawalDate = today;
                withdrawnToday = minValue;
            }

            decimal dailyLimit = (decimal)AccountLimits.TeenAccountDailyWithdrawalLimit;
            if (amount > dailyLimit - withdrawnToday)
            {
                throw new InvalidOperationException("The daily withdrawal limit would be exceeded.");
            }

            ApplyWithdrawal(amount, AccountLimits.SavingAccountMinimumBalance);
            withdrawnToday += amount;
        }

        #endregion
    }
}
