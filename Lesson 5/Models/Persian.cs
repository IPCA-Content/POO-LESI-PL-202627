//-----------------------------------------------------------------
//    <copyright file="Persian.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>22:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_5.Models;

/// <summary>
/// Represents a Persian cat.
/// </summary>
public sealed class Persian : Cat
{
    #region Constructors

    /// <summary>
    /// Initializes a Persian cat with its name.
    /// </summary>
    /// <param name="name">The cat's name.</param>
    public Persian(string name)
        : base(name)
    {
    }

    #endregion
}
