namespace Lesson_3.Models;

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
    public override void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id}, User: {Name}, Email: {Email}, Age: {GetAge()}");
    }

    #endregion
}