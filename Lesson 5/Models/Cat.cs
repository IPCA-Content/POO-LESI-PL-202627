//-----------------------------------------------------------------
//    <copyright file="Cat.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>22:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_5.Models;

/// <summary>
/// Represents a cat.
/// </summary>
public class Cat : Animal
{
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Cat"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the cat.</param>
    public Cat(string name)
        : base(name)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Makes the cat sound.
    /// </summary>
    /// <returns>A string representing the sound made by the cat.</returns>
    public override string MakeSound()
    {
        return "Meow";
    }

    #endregion
}
