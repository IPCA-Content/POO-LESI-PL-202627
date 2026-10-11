namespace Lesson_2.Models;

/// <summary>
/// Represents an administrative user.
/// </summary>
public class Admin : Entity
{
    #region Properties

    /// <summary>
    /// Gets or sets the administrator's permission level.
    /// </summary>
    public int PermissionsLevel { get; set; }

    #endregion

    #region Methods

    /// <inheritdoc />
    public override string GetDescription()
    {
        return $"Admin: {Name}\n" +
               $"Permission level: {PermissionsLevel}\n" +
               $"Age: {CalculateAge()}";
    }

    #endregion
}