namespace Lesson_2.Models;

/// <summary>
/// Represents a regular user.
/// </summary>
public class User : Entity
{
    #region Properties

    /// <summary>
    /// Gets or sets the user's email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    #endregion

    #region Methods

    /// <inheritdoc />

    public override string GetDescription()
    {
        return $"User: {Name}\n" +
               $"Email: {Email}\n" +
               $"Age: {CalculateAge()}";
    }

    #endregion
}