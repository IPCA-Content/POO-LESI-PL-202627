//-----------------------------------------------------------------
//    <copyright file="Labrador.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>22:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_5.Models
{
    /// <summary>
    /// Represents a Labrador dog.
    /// </summary>
    public class Labrador : Dog
    {
        #region Constructors

        /// <summary>
        /// Initializes a Labrador with its name.
        /// </summary>
        /// <param name="name">The Labrador's name.</param>
        public Labrador(string name)
            : base(name)
        {
        }

        #endregion

        // public override void MakeSound()
        // {
        //     Console.WriteLine("Woof!");
        // }
    }
}
