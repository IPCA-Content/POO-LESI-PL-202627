//-----------------------------------------------------------------
//    <copyright file="Animal.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>22:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_5.Models
{
    /// <summary>
    /// Represents the base type for animals that can make a sound.
    /// </summary>
    public abstract class Animal
    {
        #region Properties

        /// <summary>
        /// Gets the animal's name.
        /// </summary>
        public string Name { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an animal with its name.
        /// </summary>
        /// <param name="name">The animal's name.</param>
        /// <exception cref="ArgumentException">The name is null, empty, or whitespace.</exception>
        protected Animal(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            Name = name;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Makes the sound associated with this animal.
        /// </summary>
        /// <returns>The animal's sound.</returns>
        public abstract string MakeSound();

        #endregion
    }
}
