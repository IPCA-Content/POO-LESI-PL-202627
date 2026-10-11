namespace Lesson_3.Models;

/// <summary>
/// Represents an administrator.
/// </summary>
public class Admin : Entity
{
    #region Properties

    /// <summary>
    /// Gets or sets the administrator's permission level.
    /// </summary>
    public int LevelPermissions { get; set; }

    #endregion

    #region Methods

    /// <inheritdoc />
    public override void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id}, Admin Name: {Name}, Level Permissions: {LevelPermissions}, Age: {GetAge()}");
    }

    #endregion
}