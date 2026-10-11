//-----------------------------------------------------------------
//    <copyright file="AccountLimits.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>08-10-2026</date>
//    <time>23:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_4.Constants
{
    /// <summary>
    /// Contains monetary balance and withdrawal limits for account types.
    /// </summary>
    public static class AccountLimits
    {
        /// <summary>The lowest balance allowed for a normal account.</summary>
        public const decimal NormalAccountMinimumBalance = -500m;

        /// <summary>The lowest balance allowed for a savings account.</summary>
        public const decimal SavingAccountMinimumBalance = 0m;

        /// <summary>The maximum amount a teen account may withdraw per day.</summary>
        public const decimal TeenAccountDailyWithdrawalLimit = 200m;
    }
}
