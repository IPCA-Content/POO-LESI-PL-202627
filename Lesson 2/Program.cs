//-----------------------------------------------------------------
//    <copyright file="Program.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>21-09-2026</date>
//    <time>22:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_2.Models;

namespace Lesson_2
{
    /// <summary>
    /// Demonstrates inheritance, encapsulation, and polymorphism.
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
                Name = "John Smith",
                Email = "john@company.com"
            };
            user.SetBirthDate(new DateOnly(2001, 5, 12));

            Admin admin = new()
            {
                Id = 2,
                Name = "Mary Jones",
                PermissionsLevel = 5
            };
            admin.SetBirthDate(new DateOnly(1988, 10, 20));

            Console.WriteLine(user.GetDescription());
            Console.WriteLine(admin.GetDescription());

            Car car = new("Toyota", "Corolla", 4);
            car.ShowInfo();

            Moto moto = new("Honda", "CBR500R", 2);
            moto.Info();
        }

        #endregion
    }
}