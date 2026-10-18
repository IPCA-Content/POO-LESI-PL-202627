//-----------------------------------------------------------------
//    <copyright file="Program.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>23:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_5.Models;

namespace Lesson_5
{
    /// <summary>
    /// Demonstrates animal inheritance and sound making.
    /// </summary>
    internal static class Program
    {
        #region Entry point

        /// <summary>
        /// Runs the animal examples.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        private static void Main(string[] args)
        {
            Dog dog = new("Buddy");
            Labrador labrador = new("Max");
            Cat cat = new("Misty");
            Persian persianCat = new("Luna");

            Animal[] animals = {dog, labrador, cat, persianCat};
            foreach (Animal animal in animals)
            {
                Console.WriteLine($"{animal.Name} says: {animal.MakeSound()}");
            }
        }

        #endregion
    }
}