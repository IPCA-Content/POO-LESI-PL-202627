//-----------------------------------------------------------------
//    <copyright file="Dog.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>22:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_5.Models
{
    /// <summary>
    /// Represents a dog.
    /// </summary>
    public class Dog : Animal
    {
        #region Constructors

        /// <summary>
        /// Initializes a dog with its name.
        /// </summary>
        /// <param name="name">The dog's name.</param>
        public Dog(string name)
            : base(name)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Makes the sound associated with a dog.
        /// </summary>
        /// <returns>The dog's bark.</returns>
        public sealed override string MakeSound()
        {
            return "Woof!";
        }

        #endregion
    }
}