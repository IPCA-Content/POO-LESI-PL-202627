//-----------------------------------------------------------------
//    <copyright file="Program.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>21-09-2026</date>
//    <time>23:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_3.Models;

namespace Lesson_3
{
    /// <summary>
    /// Demonstrates abstract classes and method overriding.
    /// </summary>
    internal static class Program
    {
        #region Entry point

        /// <summary>
        /// Runs the lesson examples.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        private static void Main(string[] args)
        {
            User user = new()
            {
                Id = 1,
                Name = "John Doe",
                Email = "john@company.com"
            };
            user.SetDateOfBirth(new DateOnly(2001, 5, 15));

            Admin admin = new()
            {
                Id = 2,
                Name = "Admin User",
                LevelPermissions = 5
            };
            admin.SetDateOfBirth(new DateOnly(1988, 10, 20));

            user.DisplayInfo();
            admin.DisplayInfo();
        }

        #endregion
    }
}